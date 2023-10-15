using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Controllers;
using MedicalExamination.Data;
using MedicalExamination.Models;
using MedicalExamination.Services;
using Newtonsoft.Json;

namespace MedicalExamination.Views
{
    public partial class AnimalsCardView : Form
    {
        private string cardState;
        private readonly string currentAnimalId;
        private readonly AnimalsController controller;
        List<byte[]> photosCard; 
        public AnimalsCardView(string cardState)
        {
            InitializeComponent();
            this.cardState = cardState;
            controller = new AnimalsController(); 
            photosCard = new List<byte[]>();
            SetParametersAndValues();
        }

        public AnimalsCardView(string cardState, string animalId)
        {
            InitializeComponent();
            controller = new AnimalsController(); 
            this.cardState = cardState;
            currentAnimalId = animalId;
            photosCard = new List<byte[]>();
            SetParametersAndValues();
            //OpenAnimalCard();
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
                    var animalCardToView = controller.ShowAnimalsCardToView(currentAnimalId);                   
                    textBoxRegNumber.Text = animalCardToView[0].ToString();
                    textBoxCategory.Text = animalCardToView[1].ToString();
                    textBoxSexAnimal.Text = animalCardToView[2].ToString();
                    textBoxYearBirthday.Text = animalCardToView[3].ToString();
                    textBoxNumberElectronicChip.Text = animalCardToView[4].ToString();
                    textBoxName.Text = animalCardToView[5].ToString();
                    textBoxSignsAnimal.Text = animalCardToView[6].ToString();
                    textBoxSignsOwner.Text = animalCardToView[7].ToString();
                    textBoxLocality.Text = animalCardToView[8].ToString();
                    var photos = JsonConvert.DeserializeObject<List<byte[]>>(animalCardToView[10].ToString());
                    ShowPhotos(photos);
                    break;
                case "Add":
                    SetParameters(false);
                    ButtonExamination.Visible = false;
                    ButtonExamination.Enabled = false;
                    comboBoxLocality.DataSource = new BindingSource(
                        TestData.Localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";

                    break;
                case "Edit":
                    SetParameters(false);
                    ButtonExamination.Visible = false;
                    ButtonExamination.Enabled = false;
                    comboBoxLocality.DataSource = new BindingSource(
                        TestData.Localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";
                    var animalCardToEdit = controller.ShowAnimalsCardToEdit(currentAnimalId);
                    textBoxRegNumber.Text = animalCardToEdit[0];
                    textBoxCategory.Text = animalCardToEdit[1];
                    textBoxSexAnimal.Text = animalCardToEdit[2];
                    textBoxYearBirthday.Text = animalCardToEdit[3];
                    textBoxNumberElectronicChip.Text = animalCardToEdit[4];
                    textBoxName.Text = animalCardToEdit[5];
                    textBoxSignsAnimal.Text = animalCardToEdit[6];
                    textBoxSignsOwner.Text = animalCardToEdit[7];
                    comboBoxLocality.Text = animalCardToEdit[8];
                    break;
            }
        }

        private void OpenAnimalCard()
        {
            var animal = controller.ShowAnimalsCardToEdit(currentAnimalId);
            List<string> photos = animal[animal.Length - 1].Split(';').ToList();
            ShowPhotos(photos);
        }
        public void ShowPhotos(List<byte[]> photos)
        {
            panelPhoto.Controls.Clear();
            for (int i = 0; i < photos.Count; i++)
            {
                photosCard.Add(photos[i]);
                PictureBox pictureBox = new PictureBox();
                Bitmap bitmap;
                using (MemoryStream stream = new MemoryStream(photos[i]))
                {
                    bitmap = new Bitmap(stream);
                }
                pictureBox.Image = bitmap;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = i * (pictureBox.Height + 10);
                panelPhoto.Controls.Add(pictureBox);
            }
            panelPhoto.Height = photos.Count * (pictureBox.Height + 10);
        }
        public void ShowPhotos(List<string> photos)
        {
            panelPhoto.Controls.Clear();
            for (int i = 0; i < photos.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = photos[i];
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = i * (pictureBox.Height + 10);
                panelPhoto.Controls.Add(pictureBox);
            }
            panelPhoto.Height = photos.Count * (pictureBox.Height + 10);
        }
        
        private void OK_Click(object sender, EventArgs e)
        {
            switch (cardState)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var animalObjArray = new object[]
                    {                      
                        textBoxRegNumber.Text,
                        textBoxCategory.Text,
                        textBoxSexAnimal.Text,
                        textBoxYearBirthday.Text,
                        textBoxNumberElectronicChip.Text,
                        textBoxName.Text,
                        textBoxSignsAnimal.Text,
                        textBoxSignsOwner.Text,
                        comboBoxLocality.SelectedValue.ToString(),
                        photosCard
                    };
                    controller.AddAnimal(animalObjArray);
                    Close();
                    break;
                case "Edit":
                    var animalData = new List<string>
                    {
                        textBoxRegNumber.Text,
                        textBoxCategory.Text,
                        textBoxSexAnimal.Text,
                        textBoxYearBirthday.Text,
                        textBoxNumberElectronicChip.Text,
                        textBoxName.Text,
                        textBoxSignsAnimal.Text,
                        textBoxSignsOwner.Text,
                        comboBoxLocality.SelectedValue.ToString()
                    };
                    var Photos = new List<string>
                    {
                         pictureBox.ImageLocation
                    };
                    controller.EditAnimal(currentAnimalId, animalData.ToArray(), Photos);
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
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = openFile.FileName;
                var photoB = File.ReadAllBytes(openFile.FileName);
                photosCard.Add(photoB);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = panelPhoto.Controls.Count * (pictureBox.Height + 10);
                panelPhoto.Controls.Add(pictureBox);
            }
        }

        private void DeletePhoto_Click(object sender, EventArgs e)
        {
            if (panelPhoto.Controls.Count>0)
            {
                PictureBox pictureBox = panelPhoto.Controls[panelPhoto.Controls.Count - 1] as PictureBox;
                if (pictureBox != null)
                {
                    panelPhoto.Controls.Remove(pictureBox);
                    photosCard.RemoveAt(photosCard.Count - 1);
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
