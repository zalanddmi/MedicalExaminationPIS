using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Controllers;
using MedicalExamination.Data;
using MedicalExamination.Services;

namespace MedicalExamination.Views
{
    public partial class AnimalsCardView : Form
    {
        private string Function;
        private string ChoosedAnimal;
        public AnimalsCardView(string function)
        {
            InitializeComponent();
            Function = function;
            SetParametersAndValues();
        }

        public AnimalsCardView(string function, string choosedAnimal)
        {
            InitializeComponent();
            Function = function;
            ChoosedAnimal = choosedAnimal;
            SetParametersAndValues();
            OpenAnimalCard();
        }

        private void SetVisibleExamination()
        {
            var check = new PrivilegeService().CheckUserForExamination();
            Осмотр.Visible = check;
            Осмотр.Enabled = check;
        }

        private void SetParametersAndValues()
        {
            switch (Function)
            {
                case "View":
                    SetParameters(true);
                    SetVisibleExamination();
                    var animalCardToView = new AnimalsController().ShowAnimalsCardToView(ChoosedAnimal);                   
                    textBoxRegNumber.Text = animalCardToView[0];
                    textBoxCategory.Text = animalCardToView[1];
                    textBoxSexAnimal.Text = animalCardToView[2];
                    textBoxYearBirthday.Text = animalCardToView[3];
                    textBoxNumberElectronicChip.Text = animalCardToView[4];
                    textBoxName.Text = animalCardToView[5];
                    textBoxSignsAnimal.Text = animalCardToView[6];
                    textBoxSignsOwner.Text = animalCardToView[7];
                    textBoxLocality.Text = animalCardToView[8];
                    break;
                case "Add":
                    SetParameters(false);
                    Осмотр.Visible = false;
                    Осмотр.Enabled = false;
                    comboBoxLocality.DataSource = new BindingSource(
                        TestData.Localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";

                    break;
                case "Edit":
                    SetParameters(false);
                    Осмотр.Visible = false;
                    Осмотр.Enabled = false;
                    comboBoxLocality.DataSource = new BindingSource(
                        TestData.Localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";
                    var animalCardToEdit = new AnimalsController().ShowAnimalsCardToEdit(ChoosedAnimal);
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
            var animal = new AnimalsController().ShowAnimalsCardToView(ChoosedAnimal);
            List<string> photos = animal[animal.Length - 1].Split(';').ToList();
            ShowPhotos(photos);
        }

        public void ShowPhotos(List<string> photos)
        {
            panel.Controls.Clear();
            for (int i = 0; i < photos.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = photos[i];
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = i * (pictureBox.Height + 10);
                panel.Controls.Add(pictureBox);
            }
            panel.Height = photos.Count * (pictureBox.Height + 10);
        }
        
        private void Ок_Click(object sender, EventArgs e)
        {
            switch (Function)
            {
                case "View":
                    Close();
                    break;
                case "Add":
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
                    new AnimalsController().AddAnimal(animalData.ToArray(),Photos);
                    Close();
                    break;
                case "Edit":
                    animalData = new List<string>
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
                    Photos = new List<string>
                    {
                         pictureBox.ImageLocation
                    };
                    new AnimalsController().EditAnimal(ChoosedAnimal, animalData.ToArray(), Photos);
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
        }

        private void Отмена_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Осмотр_Click(object sender, EventArgs e)
        {
            ExaminationCard examination = new ExaminationCard(ChoosedAnimal);
            examination.Show();
        }

        private void AddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = openFile.FileName;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = panel.Controls.Count * (pictureBox.Height + 10);
                panel.Controls.Add(pictureBox);
            }
        }

        private void DeletePhoto_Click(object sender, EventArgs e)
        {
            if (panel.Controls.Count>0)
            {
                PictureBox pictureBox = panel.Controls[panel.Controls.Count - 1] as PictureBox;
                if (pictureBox != null)
                {
                    panel.Controls.Remove(pictureBox);
                }
            }
        }
    }
}
