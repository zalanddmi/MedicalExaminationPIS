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
    public partial class OrganizationCardView : Form
    {
        private string cardState;
        private int currentOrganizationId;
        private OrganizationsController controller;
        List<Locality> localities;
        List<TypeOrganization> typeOrganizations;
        Organization currentOrganization;
        public OrganizationCardView(string cardState)
        {
            InitializeComponent();
            controller = new OrganizationsController();
            this.cardState = cardState;
            localities = controller.GetLocalities();
            typeOrganizations = controller.GetTypeOrganizations();
            SetParametersAndValues();
        }
        public OrganizationCardView(string cardState, int organizationId)
        {
            InitializeComponent();
            controller = new OrganizationsController();
            this.cardState = cardState;
            currentOrganizationId = organizationId;
            currentOrganization = controller.ShowOrganizationCardToView(organizationId);
            localities = controller.GetLocalities();
            typeOrganizations = controller.GetTypeOrganizations();
            SetParametersAndValues();
        }

        private void SetParametersAndValues()
        {
            switch (cardState)
            {
                case "Add":
                    SetParameters(false);
                    FillComboBoxes();
                    break;
                case "View":
                    SetParameters(true);
                    textBoxName.Text = currentOrganization.Name;
                    textBoxTaxIdNumber.Text = currentOrganization.TaxIdNumber;
                    textBoxCodeReason.Text = currentOrganization.CodeReason;
                    textBoxAddress.Text = currentOrganization.Address;
                    textBoxTypeOrganization.Text = currentOrganization.TypeOrganization.Name;
                    textBoxFormOrganization.Text = currentOrganization.IsJuridicalPerson ? "Юридическое лицо" : "ИП";
                    textBoxLocality.Text = currentOrganization.Locality.Name;
                    break;
                
                case "Edit":
                    SetParameters(false);
                    FillComboBoxes();
                    textBoxName.Text = currentOrganization.Name;
                    textBoxTaxIdNumber.Text = currentOrganization.TaxIdNumber;
                    textBoxCodeReason.Text = currentOrganization.CodeReason;
                    textBoxAddress.Text = currentOrganization.Address;
                    comboBoxTypeOrganization.Text = currentOrganization.TypeOrganization.Name;
                    radioButtonJuridical.Checked = currentOrganization.IsJuridicalPerson;
                    radioButtonIndividual.Checked = currentOrganization.IsJuridicalPerson;
                    comboBoxLocality.Text = currentOrganization.Locality.Name;
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

        private void FillComboBoxes()
        {
            /*var privilege = UserSession.Privileges["Organization"];
            var typeOrg = new List<TypeOrganization>();
            var locs = new List<Locality>();
            var priv = privilege.Split(';');
            var typesPriv = priv[1].Split(',');
            foreach (var tp in typesPriv)
            {
                var tpid = int.Parse(tp);
                typeOrg.Add(TestData.TypeOrganizations.First(to => to.IdTypeOrganization == tpid));
            }
            if (priv[0] == "All")
            {
                locs = TestData.Localities;
            }
            else
            {
                var munid = int.Parse(priv[0].Split('=')[1]);
                locs = TestData.Localities.Where(loc => loc.Municipality.IdMunicipality == munid).ToList();
            }*/
            comboBoxTypeOrganization.DataSource = new BindingSource(typeOrganizations, null);
            comboBoxTypeOrganization.DisplayMember = "Name";
            comboBoxTypeOrganization.ValueMember = "IdTypeOrganization";
            comboBoxLocality.DataSource = new BindingSource(localities, null);
            comboBoxLocality.DisplayMember = "Name";
            comboBoxLocality.ValueMember = "IdLocality";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            switch (cardState)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var orgNew = new Organization
                    (
                        textBoxName.Text,
                        textBoxTaxIdNumber.Text,
                        textBoxCodeReason.Text,
                        textBoxAddress.Text,
                        radioButtonJuridical.Checked,
                        (TypeOrganization)comboBoxTypeOrganization.SelectedItem,
                        (Locality)comboBoxLocality.SelectedItem
                    );
                    controller.AddOrganization(orgNew);
                    Close();
                    break;
                case "Edit":
                    currentOrganization.Name = textBoxName.Text;
                    currentOrganization.TaxIdNumber = textBoxTaxIdNumber.Text;
                    currentOrganization.CodeReason = textBoxCodeReason.Text;
                    currentOrganization.Address = textBoxAddress.Text;
                    currentOrganization.IsJuridicalPerson = radioButtonJuridical.Checked;
                    currentOrganization.TypeOrganization = (TypeOrganization)comboBoxTypeOrganization.SelectedItem;
                    currentOrganization.Locality = (Locality)comboBoxLocality.SelectedItem;
                    controller.UpdateOrganization(currentOrganization);
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
