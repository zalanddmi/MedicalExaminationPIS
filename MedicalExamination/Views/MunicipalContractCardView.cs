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
using MedicalExamination.ViewModels;

namespace MedicalExamination.Views
{
    public partial class MunicipalContractCardView : Form
    {
        private string cardState;
        private readonly int currentMunicipalContractId;
        private readonly MunicipalContractsController controller;
        MunicipalContractView currentMunicipalContractCard;
        List<ViewModels.Image> scanCard;
        List<Cost> costs;
        int currentImage = 0;

        public MunicipalContractCardView(string cardState)
        {
            InitializeComponent();
            this.cardState = cardState;
            controller = new MunicipalContractsController();
            SetParametersAndValues();
        }

        public MunicipalContractCardView(string cardState, int municipalContractId)
        {
            InitializeComponent();
            this.cardState = cardState;
            controller = new MunicipalContractsController();
            currentMunicipalContractId = municipalContractId;
            currentMunicipalContractCard = controller.GetMunicipalContractCard(municipalContractId);
            costs = controller.GetCosts(municipalContractId);
            SetParametersAndValues();
            OpenMunicipalContractCard();
        }

        private void SetParametersAndValues()
        {
            switch (cardState)
            {
                case "View":
                    SetParameters(true);
                    FillFields();
                    dataGridViewCost.Rows.Clear();
                    foreach(var cost in costs)
                    {
                        dataGridViewCost.Rows.Add(cost.IdCost, cost.Locality.Name, cost.Value);
                    }
                    break;
                case "Add":
                    SetParameters(false);
                    FillComboBoxes();
                    break;
                case "Edit":
                    SetParameters(false);
                    FillComboBoxes();
                    break;
            }
        }

        private void FillFields()
        {
            textBoxNumber.Text = currentMunicipalContractCard.Number;
            textBoxDateConclusion.Text = currentMunicipalContractCard.DateConclusion.ToShortDateString();
            textBoxDateAction.Text = currentMunicipalContractCard.DateAction.ToShortDateString();
            textBoxExecutor.Text = currentMunicipalContractCard.Executor.Name;
            textBoxCustomer.Text = currentMunicipalContractCard.Customer.Name;

            ShowScan(currentMunicipalContractCard.Scan);
        }

        public void ShowScan(List<ViewModels.Image> scan)
        {
            scanCard = scan;

            if (scanCard.Count != 0)
            {
                ChangeImage(0);
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
            using (MemoryStream stream = new MemoryStream(scanCard[index].data))
            {
                bitmap = new Bitmap(stream);
            }
            pictureBox.Image = bitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void ShowPrevImage()
        {
            if (scanCard.Count == 0)
            {
                ChangeImage(-1);
                return;
            }

            if (currentImage < 0)
                currentImage = scanCard.Count - 1;

            if (scanCard[currentImage].data != null)
            {
                ChangeImage(currentImage);
                return;
            }


            for (int i = currentImage; i >= 0; i--)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            for (int i = scanCard.Count - 1; i > currentImage; i--)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            ChangeImage(-1);
        }

        private void ShowNextImage()
        {
            if (scanCard.Count == 0)
            {
                ChangeImage(-1);
                return;
            }


            if (currentImage > scanCard.Count - 1)
                currentImage = 0;
            if (scanCard[currentImage].data != null)
            {
                ChangeImage(currentImage);
                return;
            }


            for (int i = currentImage; i < scanCard.Count; i++)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }
            for (int i = 0; i < currentImage; i++)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            ChangeImage(-1);
        }

        private void SetParameters(bool value)
        {
            textBoxNumber.ReadOnly = value;
            textBoxDateConclusion.ReadOnly = value;
            textBoxDateAction.ReadOnly = value;
            textBoxExecutor.ReadOnly = value;
            textBoxExecutor.Visible = value;
            comboBoxExecutor.Visible = !value;
            textBoxCustomer.ReadOnly = value;
            textBoxCustomer.Visible = value;
            comboBoxCustomer.Visible = !value;       
        }

        private void FillComboBoxes()
        {
            var organizations = new List<Organization>();
            organizations = TestData.Organizations;
            comboBoxExecutor.DataSource = new BindingSource(organizations, null);
            comboBoxExecutor.DisplayMember = "Name";
            comboBoxExecutor.ValueMember = "IdOrganization";
            comboBoxCustomer.DataSource = new BindingSource(organizations, null);
            comboBoxCustomer.ValueMember = "IdOrganization";
            comboBoxCustomer.DisplayMember = "Name";
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenMunicipalContractCard()
        {
            //var municipalcontract = controller.ShowMunicipalContractCardToView(currentMunicipalContractId);
            //List<string> photos = municipalcontract[municipalcontract.Length - 1].Split(';').ToList();
            //ShowPhotos(photos);
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            switch (cardState)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var municipalcontractData = new List<string>
                    {
                        textBoxNumber.Text,
                        textBoxDateConclusion.Text,
                        textBoxDateAction.Text,
                        comboBoxExecutor.SelectedValue.ToString(),
                        comboBoxCustomer.SelectedValue.ToString()                      
                    };
                    var Photos = new List<string>
                    {
                         pictureBox.ImageLocation
                    };
                    controller.AddMunicipalContract(municipalcontractData.ToArray(), Photos);                    
                    break;
                case "Edit":
                    municipalcontractData = new List<string>
                    {
                        textBoxNumber.Text,
                        textBoxDateConclusion.Text,
                        textBoxDateAction.Text,
                        comboBoxExecutor.SelectedValue.ToString(),
                        comboBoxCustomer.SelectedValue.ToString()
                    };
                    Photos = new List<string>
                    {
                         pictureBox.ImageLocation
                    };
                    //controller.EditMunicipalContract(currentMunicipalContractId, municipalcontractData.ToArray(), Photos);
                    Close();
                    break;
            }
        }
        public void ShowPhotos(List<string> photos)
        {
            panelScan.Controls.Clear();
            for (int i = 0; i < photos.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = photos[i];
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = i * (pictureBox.Height + 10);
                panelScan.Controls.Add(pictureBox);
            }
            panelScan.Height = photos.Count * (pictureBox.Height + 10);
        }

        private void AddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = openFile.FileName;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = panelScan.Controls.Count * (pictureBox.Height + 10);
                panelScan.Controls.Add(pictureBox);
            }
        }

        private void DeletePhoto_Click(object sender, EventArgs e)
        {
            if (panelScan.Controls.Count > 0)
            {
                PictureBox pictureBox = panelScan.Controls[panelScan.Controls.Count - 1] as PictureBox;
                if (pictureBox != null)
                {
                    panelScan.Controls.Remove(pictureBox);
                }
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            currentImage--;
            ShowPrevImage();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            currentImage++;
            ShowNextImage();
        }
    }
}
