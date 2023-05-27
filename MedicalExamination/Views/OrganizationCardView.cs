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

namespace MedicalExamination.Views
{
    public partial class OrganizationCardView : Form
    {
        private string Function;
        private string ChoosedOrganization;

        public OrganizationCardView(string function)
        {
            InitializeComponent();
            Function = function;
            SetParametersAndValues();
        }
        public OrganizationCardView(string function, string choosedOrganization)
        {
            InitializeComponent();
            Function = function;
            ChoosedOrganization = choosedOrganization;
            SetParametersAndValues();
        }

        private void SetParametersAndValues()
        {
            switch (Function)
            {
                case "View":
                    SetParameters(true);
                    var organizationCardToView = new OrganizationsController().ShowOrganizationCardToView(ChoosedOrganization);
                    textBoxName.Text = organizationCardToView[0];
                    textBoxTaxIdNumber.Text = organizationCardToView[1];
                    textBoxCodeReason.Text = organizationCardToView[2];
                    textBoxAddress.Text = organizationCardToView[3];
                    textBoxTypeOrganization.Text = organizationCardToView[4];
                    textBoxFormOrganization.Text = organizationCardToView[5];
                    textBoxLocality.Text = organizationCardToView[6];
                    break;
                case "Add":
                    SetParameters(false);
                    comboBoxTypeOrganization.DataSource = new BindingSource(
                        TestData.TypeOrganizations, null);
                    comboBoxTypeOrganization.DisplayMember = "Name";
                    comboBoxTypeOrganization.ValueMember = "IdTypeOrganization";
                    comboBoxLocality.DataSource = new BindingSource(
                        TestData.Localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";
                    break;
                case "Edit":
                    SetParameters(false);
                    comboBoxTypeOrganization.DataSource = new BindingSource(
                        TestData.TypeOrganizations, null);
                    comboBoxTypeOrganization.DisplayMember = "Name";
                    comboBoxTypeOrganization.ValueMember = "IdTypeOrganization";
                    comboBoxLocality.DataSource = new BindingSource(
                        TestData.Localities, null);
                    comboBoxLocality.DisplayMember = "Name";
                    comboBoxLocality.ValueMember = "IdLocality";
                    var organizationCardToEdit = new OrganizationsController().ShowOrganizationCardToEdit(ChoosedOrganization);
                    textBoxName.Text = organizationCardToEdit[0];
                    textBoxTaxIdNumber.Text = organizationCardToEdit[1];
                    textBoxCodeReason.Text = organizationCardToEdit[2];
                    textBoxAddress.Text = organizationCardToEdit[3];
                    comboBoxTypeOrganization.Text = organizationCardToEdit[4];
                    radioButtonJuridical.Checked = organizationCardToEdit[5] == "Юрлицо";
                    radioButtonIndividual.Checked = organizationCardToEdit[5] == "ИП";
                    comboBoxLocality.Text = organizationCardToEdit[6];
                    break;
            }
        }

        private void SetParameters(bool value)
        {
            textBoxName.ReadOnly = value;
            textBoxTaxIdNumber.ReadOnly = value;
            textBoxCodeReason.ReadOnly = value;
            textBoxAddress.ReadOnly = value;
            textBoxTypeOrganization.ReadOnly = value;
            textBoxTypeOrganization.Visible = value;
            comboBoxTypeOrganization.Visible = !value;
            textBoxFormOrganization.ReadOnly = value;
            textBoxFormOrganization.Visible = value;
            radioButtonIndividual.Visible = !value;
            radioButtonJuridical.Visible = !value;
            textBoxLocality.ReadOnly = value;
            textBoxLocality.Visible = value;
            comboBoxLocality.Visible = !value;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            switch (Function)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var organizationData = new List<string>
                    {
                        textBoxName.Text,
                        textBoxTaxIdNumber.Text,
                        textBoxCodeReason.Text,
                        textBoxAddress.Text,
                        radioButtonJuridical.Checked ? "Юрлицо" : "ИП",
                        comboBoxTypeOrganization.SelectedValue.ToString(),
                        comboBoxLocality.SelectedValue.ToString()
                    };
                    new OrganizationsController().AddOrganization(organizationData.ToArray());
                    Close();
                    break;
                case "Edit":
                    organizationData = new List<string>
                    {
                        textBoxName.Text,
                        textBoxTaxIdNumber.Text,
                        textBoxCodeReason.Text,
                        textBoxAddress.Text,
                        radioButtonJuridical.Checked ? "Юрлицо" : "ИП",
                        comboBoxTypeOrganization.SelectedValue.ToString(),
                        comboBoxLocality.SelectedValue.ToString()
                    };
                    new OrganizationsController().EditOrganization(ChoosedOrganization, organizationData.ToArray());
                    Close();
                    break;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
