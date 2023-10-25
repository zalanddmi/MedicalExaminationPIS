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

        public MunicipalContractCardView(string function)
        {
            InitializeComponent();
            cardState = function;
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
                    //var municipalcontractCardToView = controller.ShowMunicipalContractCardToView(currentMunicipalContractId);
                    //textBoxNumber.Text = municipalcontractCardToView[0];
                    //textBoxDateConclusion.Text = municipalcontractCardToView[1];
                    //textBoxDateAction.Text = municipalcontractCardToView[2];
                    //textBoxExecutor.Text = municipalcontractCardToView[3];
                    //textBoxCustomer.Text = municipalcontractCardToView[4];
                    //textBoxValue.Text = municipalcontractCardToView[5]; НАДО РАЗОБРАТЬСЯ С COST
                    //textBoxLocality.Text = municipalcontractCardToView[6];
                    break;
                case "Add":
                    SetParameters(false);
                    FillComboBoxes();
                    break;
                case "Edit":
                    SetParameters(false);
                    FillComboBoxes();
                    //var municipalcontractCardToEdit = controller.ShowMunicipalContractCardToEdit(currentMunicipalContractId);
                    //textBoxNumber.Text = municipalcontractCardToEdit[0];
                    //textBoxDateConclusion.Text = municipalcontractCardToEdit[1];
                    //textBoxDateAction.Text = municipalcontractCardToEdit[2];
                    //comboBoxExecutor.Text = municipalcontractCardToEdit[3];
                    //comboBoxCustomer.Text = municipalcontractCardToEdit[4];                   
                    //textBoxValue.Text = municipalcontractCardToEdit[5]; НАДО РАЗОБРАТЬСЯ С COST
                    //textBoxLocality.Text = municipalcontractCardToEdit[6];
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
            //textBoxValue.Text  НАДО РАЗОБРАТЬСЯ С COST
            //textBoxLocality.Text           
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
                pictureBox.Top = panel.Controls.Count * (pictureBox.Height + 10);
                panel.Controls.Add(pictureBox);
            }
        }

        private void DeletePhoto_Click(object sender, EventArgs e)
        {
            if (panel.Controls.Count > 0)
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
