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

namespace MedicalExamination.Views
{
    public partial class MunicipalContractCardView : Form
    {
        private string Function;
        private string ChoosedMunicipalContract;
        public MunicipalContractCardView(string function)
        {
            InitializeComponent();
            Function = function;
            SetParametersAndValues();
        }
        public MunicipalContractCardView(string function, string choosedMunicipalContract)
        {
            InitializeComponent();
            Function = function;
            ChoosedMunicipalContract = choosedMunicipalContract;
            SetParametersAndValues();
            OpenMunicipalContractCard();
        }
        private void SetParametersAndValues()
        {
            switch (Function)
            {
                case "View":
                    SetParameters(true);
                    var municipalcontractCardToView = new MunicipalContractsController().ShowMunicipalContractCardToView(ChoosedMunicipalContract);
                    textBoxNumber.Text = municipalcontractCardToView[0];
                    textBoxDateConclusion.Text = municipalcontractCardToView[1];
                    textBoxDateAction.Text = municipalcontractCardToView[2];
                    textBoxExecutor.Text = municipalcontractCardToView[3];
                    textBoxCustomer.Text = municipalcontractCardToView[4];
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
                    var municipalcontractCardToEdit = new MunicipalContractsController().ShowMunicipalContractCardToEdit(ChoosedMunicipalContract);
                    textBoxNumber.Text = municipalcontractCardToEdit[0];
                    textBoxDateConclusion.Text = municipalcontractCardToEdit[1];
                    textBoxDateAction.Text = municipalcontractCardToEdit[2];
                    comboBoxExecutor.Text = municipalcontractCardToEdit[3];
                    comboBoxCustomer.Text = municipalcontractCardToEdit[4];                   
                    //textBoxValue.Text = municipalcontractCardToEdit[5]; НАДО РАЗОБРАТЬСЯ С COST
                    //textBoxLocality.Text = municipalcontractCardToEdit[6];
                    break;
            }
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
            var municipalcontract = new MunicipalContractsController().ShowMunicipalContractCardToView(ChoosedMunicipalContract);
            List<string> photos = municipalcontract[municipalcontract.Length - 1].Split(';').ToList();
            ShowPhotos(photos);
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            switch (Function)
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
                    new OrganizationsController().AddOrganization(municipalcontractData.ToArray());
                    Close();
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
                    new OrganizationsController().EditOrganization(ChoosedMunicipalContract, municipalcontractData.ToArray());
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
    }
}
