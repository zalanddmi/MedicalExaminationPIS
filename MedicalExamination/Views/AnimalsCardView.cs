using MedicalExamination.Controllers;
using MedicalExamination.Models;
using MedicalExamination.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
        private void AnimalsCardView_Load(object sender, EventArgs e)
        {
            warningLabelRegNumber.Visible = false;
            warningLabelName.Visible = false;
            warningLabelSignsOwner.Visible = false;
            warningLabelNumberChip.Visible = false;
            warningLabelSignsAnimal.Visible = false;
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
                    SetEditableForm();
                    break;
                case "Edit":
                    SetEditableForm();

                    FillFields();
                    comboBoxLocality.Text = currentAnimalCard.Locality.Name;
                    comboBoxCategory.Text = currentAnimalCard.Category;
                    comboBoxSex.Text = currentAnimalCard.SexAnimal;
                    comboBoxYearBirthDay.Text = currentAnimalCard.YearBirthday.ToString();
                    break;
            }
        }

        private void SetEditableForm()
        {
            SetParameters(false);
            ButtonExamination.Visible = false;
            ButtonExamination.Enabled = false;

            comboBoxLocality.DataSource = new BindingSource(localities, null);
            comboBoxLocality.DisplayMember = "Name";
            comboBoxLocality.ValueMember = "IdLocality";

            comboBoxCategory.Items.AddRange(new object[] { "Собака", "Кошка" });
            comboBoxCategory.SelectedIndex = 0;
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxSex.Items.AddRange(new object[] { "М", "Ж" });
            comboBoxSex.SelectedIndex = 0;
            comboBoxSex.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                comboBoxYearBirthDay.Items.Add(i);
            }
            comboBoxYearBirthDay.SelectedIndex = comboBoxYearBirthDay.Items.Count - 1;
            comboBoxYearBirthDay.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void SetParameters(bool value)
        {
            textBoxRegNumber.Enabled = !value;
            textBoxRegNumber.BackColor = Color.White;

            textBoxCategory.Enabled = !value;
            textBoxCategory.BackColor = Color.White;
            comboBoxCategory.Visible = !value;

            textBoxSexAnimal.Enabled = !value;
            textBoxSexAnimal.BackColor = Color.White;
            comboBoxSex.Visible = !value;

            textBoxYearBirthday.Enabled = !value;
            textBoxYearBirthday.BackColor = Color.White;
            comboBoxYearBirthDay.Visible = !value;

            textBoxNumberElectronicChip.Enabled = !value;
            textBoxNumberElectronicChip.BackColor = Color.White;

            textBoxName.Enabled = !value;
            textBoxName.BackColor = Color.White;

            textBoxSignsAnimal.Enabled = !value;
            textBoxSignsAnimal.BackColor = Color.White;

            textBoxSignsOwner.Enabled = !value;
            textBoxSignsOwner.BackColor = Color.White;

            comboBoxLocality.Visible = !value;
            textBoxLocality.Enabled = !value;
            textBoxLocality.BackColor = Color.White;
            textBoxLocality.Visible = value;

            ButtonAddPhoto.Visible = !value;
            ButtonDeletePhoto.Visible = !value;

        }
        
        private void OK_Click(object sender, EventArgs e)
        {
            switch (cardState)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    try
                    {
                        if (IsValidData())
                        {
                            var animalNew = new AnimalView
                            (
                                textBoxRegNumber.Text,
                                comboBoxCategory.Text,
                                comboBoxSex.Text,
                                int.Parse(comboBoxYearBirthDay.Text),
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
                        }
                        MessageBox.Show("Некоторые поля некорретно заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Edit":
                    try
                    {
                        if (IsValidData())
                        {
                            currentAnimalCard.RegNumber = textBoxRegNumber.Text;
                            currentAnimalCard.Category = comboBoxCategory.Text;
                            currentAnimalCard.SexAnimal = comboBoxSex.Text;
                            currentAnimalCard.YearBirthday = Convert.ToInt32(comboBoxYearBirthDay.Text);
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
                        MessageBox.Show("Некоторые поля некорретно заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsValidData()
        {
            bool isValid = !(textBoxName.TextLength == 0 || textBoxRegNumber.TextLength == 0
                || textBoxSignsAnimal.TextLength == 0 || textBoxSignsOwner.TextLength == 0
                || warningLabelName.Visible || warningLabelSignsAnimal.Visible || warningLabelSignsOwner.Visible
                || warningLabelRegNumber.Visible || warningLabelNumberChip.Visible
                || comboBoxLocality.SelectedItem is null);

            return isValid;
        }

        

        private void Examination_Click(object sender, EventArgs e)
        {
            Hide();
            ExaminationCard examination = new ExaminationCard(currentAnimalId);
            examination.ShowDialog();
            Show();
        }

        public void ShowPhotos(List<ViewModels.Image> photos)
        {
            photosCard = photos;

            if (photosCard.Count != 0)
            {
                ChangeImage(0);
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

        private void ShowWarninglabel(TextBox textBox, Label label, string warningText, bool check)
        {
            if (check)
            {
                label.Text = textBox.TextLength != 0 ? warningText : "Заполните поле";
                label.Visible = true;
                label.BackColor = Color.Pink;
                textBox.BackColor = Color.Pink;
            }
        }

        #region textBoxRegNumber
        private void textBoxRegNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            var symbol = e.KeyChar;
            e.Handled = !char.IsControl(symbol) && !char.IsDigit(symbol);
        }

        private void textBoxRegNumber_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            ShowWarninglabel(textBox, warningLabelRegNumber, $"Должно быть из 5 цифр", textBox.TextLength < 5);
        }

        private void textBoxRegNumber_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelRegNumber.Visible = false;
        }

        private void warningLabelRegNumber_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxRegNumber.Focus();
        }
        #endregion

        #region textBoxNumberElectronicChip
        private void textBoxNumberElectronicChip_KeyPress(object sender, KeyPressEventArgs e)
        {
            var symbol = e.KeyChar;
            e.Handled = !char.IsControl(symbol) && !char.IsDigit(symbol);
        }

        private void textBoxNumberElectronicChip_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            ShowWarninglabel(textBox, warningLabelNumberChip, $"Должно быть из 6 цифр", textBox.TextLength < 6);
        }

        private void textBoxNumberElectronicChip_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelNumberChip.Visible = false;
        }

        private void warningLabelNumberChip_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxNumberElectronicChip.Focus();
        }
        #endregion

        #region textBoxName
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var symbol = e.KeyChar;
            e.Handled = !char.IsLetter(symbol) && !char.IsDigit(symbol) && !char.IsControl(symbol);
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            ShowWarninglabel(textBox, warningLabelName, $"Минимум из 3 символов", textBox.TextLength < 3);
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelName.Visible = false;
        }

        private void warningLabelName_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxName.Focus();
        }
        #endregion

        #region textBoxSingnsAnimal
        private void textBoxSignsAnimal_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            ShowWarninglabel(textBox, warningLabelSignsAnimal, "Заполните поле!", textBox.TextLength == 0);
        }

        private void textBoxSignsAnimal_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelSignsAnimal.Visible = false;
        }

        private void warningLabelSignsAnimal_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxSignsAnimal.Focus();
        }
        #endregion

        #region textBoxSingsOwner
        private void textBoxSignsOwner_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxSignsOwner_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            ShowWarninglabel(textBox, warningLabelSignsOwner, "Заполните поле!", textBox.TextLength == 0);
        }

        private void textBoxSignsOwner_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelSignsOwner.Visible = false;
        }

        private void warningLabelSignsOwner_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxSignsOwner.Focus();
        }
        #endregion
    }
}
