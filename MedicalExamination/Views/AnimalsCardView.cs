using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MedicalExamination.Controllers;
using MedicalExamination.Models;
using MedicalExamination.Services;
using Newtonsoft.Json;
using MedicalExamination.ViewModels;
using System.Drawing;

namespace MedicalExamination.Views
{
    public partial class AnimalsCardView : Form
    {
        private string cardState;
        private readonly int currentAnimalId;
        private readonly AnimalsController controller;
        List<Locality> localities;
        AnimalView currentAnimalCard;
        List<ViewModels.Image> photosCard;
        int currentImage = 0;
        public AnimalsCardView(string cardState)
        {
            InitializeComponent();
            this.cardState = cardState;
            controller = new AnimalsController(); 
            photosCard = new List<ViewModels.Image>();
            localities = controller.GetLocalities();
            SetParametersAndValues();
        }

        public AnimalsCardView(string cardState, int animalId)
        {
            InitializeComponent();
            controller = new AnimalsController(); 
            this.cardState = cardState;
            currentAnimalId = animalId;
            photosCard = new List<ViewModels.Image>();
            localities = controller.GetLocalities();
            currentAnimalCard = controller.GetAnimalCard(animalId);
            SetParametersAndValues();
        }

        private void SetVisibleExamination()
        {
            var privileges = UserSession.Privileges;
            bool check = false;
            if (privileges.ContainsKey("Examination"))
            {
                check = privileges["Examination"].Split(';')[0] == "All";
            }

            ButtonExamination.Visible = check;
            ButtonExamination.Enabled = check;  
        }

        private void SetParametersAndValues()
        {
            switch (cardState)
            {
                case "View":
                    SetParameters(true);
                    SetVisibleExamination();

                    FillFields();
                    textBoxLocality.Text = currentAnimalCard.Locality.Name;

                    break;
                case "Add":
                    SetParameters(false);
                    ButtonExamination.Visible = false;
                    ButtonExamination.Enabled = false;
                    comboBoxLocality.DataSource = new BindingSource(
                        localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";

                    break;
                case "Edit":
                    SetParameters(false);
                    ButtonExamination.Visible = false;
                    ButtonExamination.Enabled = false;
                    comboBoxLocality.DataSource = new BindingSource(
                        localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";

                    FillFields();
                    comboBoxLocality.Text = currentAnimalCard.Locality.Name;

                    break;
            }
        }

        private void FillFields()
        {
            textBoxRegNumber.Text = currentAnimalCard.RegNumber;
            textBoxCategory.Text = currentAnimalCard.Category;
            textBoxSexAnimal.Text = currentAnimalCard.SexAnimal;
            textBoxYearBirthday.Text = currentAnimalCard.YearBirthday.ToString();
            textBoxNumberElectronicChip.Text = currentAnimalCard.NumberElectronicChip;
            textBoxName.Text = currentAnimalCard.Name;
            textBoxSignsAnimal.Text = currentAnimalCard.SignsAnimal;
            textBoxSignsOwner.Text = currentAnimalCard.SignsOwner;

            ShowPhotos(currentAnimalCard.Photos);
        }


        public void ShowPhotos(List<ViewModels.Image> photos)
        {
            photosCard = photos;

            if (photosCard.Count != 0)
            {
                ChangeImage(0);
            }
        }
        
        private void OK_Click(object sender, EventArgs e)
        {
            switch (cardState)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var animalNew = new AnimalView
                    (
                        textBoxRegNumber.Text,
                        textBoxCategory.Text,
                        textBoxSexAnimal.Text,
                        int.Parse(textBoxYearBirthday.Text),
                        textBoxNumberElectronicChip.Text,
                        textBoxName.Text,
                        photosCard,
                        textBoxSignsAnimal.Text,
                        textBoxSignsOwner.Text,
                        (Locality)comboBoxLocality.SelectedItem
                    );

                    controller.AddAnimal(animalNew);
                    Close();
                    break;
                case "Edit":
                    currentAnimalCard.RegNumber = textBoxRegNumber.Text;
                    currentAnimalCard.Category = textBoxCategory.Text;
                    currentAnimalCard.SexAnimal = textBoxSexAnimal.Text;
                    currentAnimalCard.YearBirthday = Convert.ToInt32(textBoxYearBirthday.Text);
                    currentAnimalCard.NumberElectronicChip = textBoxNumberElectronicChip.Text;
                    currentAnimalCard.Name = textBoxName.Text;
                    currentAnimalCard.Photos = photosCard;
                    currentAnimalCard.SignsAnimal = textBoxSignsAnimal.Text;
                    currentAnimalCard.SignsOwner = textBoxSignsOwner.Text;
                    currentAnimalCard.Locality = (Locality)comboBoxLocality.SelectedItem;

                    controller.UpdateAnimal(currentAnimalCard);
                    Close();
                    break;
            }
        }

        private void SetParameters(bool value)
        {
            textBoxRegNumber.ReadOnly = value;
            textBoxCategory.ReadOnly = value;
            textBoxSexAnimal.ReadOnly = value;
            textBoxYearBirthday.ReadOnly = value;
            textBoxNumberElectronicChip.ReadOnly = value;
            textBoxName.ReadOnly = value;
            textBoxSignsAnimal.ReadOnly = value;
            textBoxSignsOwner.ReadOnly = value;
            comboBoxLocality.Visible = !value;
            textBoxLocality.ReadOnly = value;
            textBoxLocality.Visible = value;
            ButtonAddPhoto.Visible = !value;
            ButtonDeletePhoto.Visible = !value;
        }

        private void Examination_Click(object sender, EventArgs e)
        {
            List<string[]> munContracts = new MunicipalContractsController().ShowMunicipalContracts("IdMunicipalContract=Ascending;", "", 1, int.MaxValue);
            if (munContracts.Count != 0)
            {
                ExaminationCard examination = new ExaminationCard(currentAnimalId);
                examination.Show();
            }
            else
            {
                MessageBox.Show("Контракты на осмотры отсутствуют");
            }
        }

        private void AddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                var photoB = File.ReadAllBytes(openFile.FileName);
                photosCard.Add(new ViewModels.Image(photoB));
                currentImage = photosCard.Count - 1;
                ChangeImage(currentImage);
            }
        }

        private void DeletePhoto_Click(object sender, EventArgs e)
        {
            if (currentImage >= 0 && currentImage < photosCard.Count)
            {
                if (photosCard[currentImage].filePath == null)
                {
                    photosCard.RemoveAt(currentImage);
                    currentImage--;
                    ShowPrevImage();
                    return;
                }
                photosCard[currentImage].data = null;
                currentImage--;
                ShowPrevImage();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ChangeImage(int index)
        {
            if (index == -1)
            {
                pictureBox.Image = null;
                return;
            }
            Bitmap bitmap;
            using (MemoryStream stream = new MemoryStream(photosCard[index].data))
            {
                bitmap = new Bitmap(stream);
            }
            pictureBox.Image = bitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            currentImage--;
            ShowPrevImage();
        }

        private void ShowPrevImage()
        {
            if (photosCard.Count == 0)
            {
                ChangeImage(-1);
                return;
            }

            if (currentImage < 0)
                currentImage = photosCard.Count - 1;

            if (photosCard[currentImage].data != null)
            {
                ChangeImage(currentImage);
                return;
            }


            for (int i = currentImage; i >= 0; i--)
            {
                if (photosCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            for (int i = photosCard.Count - 1; i > currentImage; i--)
            {
                if (photosCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            ChangeImage(-1);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            currentImage++;
            ShowNextImage();

        }

        private void ShowNextImage()
        {
            if (photosCard.Count == 0)
            {
                ChangeImage(-1);
                return;
            }


            if (currentImage > photosCard.Count - 1)
                currentImage = 0;
            if (photosCard[currentImage].data != null)
            {
                ChangeImage(currentImage);
                return;
            }


            for (int i = currentImage; i < photosCard.Count; i++)
            {
                if (photosCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }
            for (int i = 0; i < currentImage; i++)
            {
                if (photosCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            ChangeImage(-1);
        }
    }
}
