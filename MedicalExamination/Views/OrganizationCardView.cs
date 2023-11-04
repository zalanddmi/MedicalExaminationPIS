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
        private void OrganizationCardView_Load(object sender, EventArgs e)
        {
            warningLabelName.Visible = false;
            warningLabelINN.Visible = false;
            warningLabelKPP.Visible = false;
            warningLabelAddress.Visible = false;
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
                    comboBoxLocality.Text = currentOrganization.Locality.Name;
                    break;
            }
        }

        private void SetParameters(bool value)
        {
            textBoxName.Enabled = !value;
            textBoxName.BackColor = Color.White; 

            textBoxTaxIdNumber.Enabled = !value;
            textBoxTaxIdNumber.BackColor = Color.White;

            textBoxCodeReason.Enabled = !value;
            textBoxCodeReason.BackColor = Color.White;

            textBoxAddress.Enabled = !value;
            textBoxAddress.BackColor = Color.White;

            textBoxTypeOrganization.Enabled = !value;
            textBoxTypeOrganization.Visible = value;
            textBoxTypeOrganization.BackColor = Color.White;

            comboBoxTypeOrganization.Visible = !value;
            comboBoxTypeOrganization.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTypeOrganization.BackColor = Color.White;

            textBoxFormOrganization.Enabled = !value;
            textBoxFormOrganization.Visible = value;
            textBoxFormOrganization.BackColor = Color.White;

            radioButtonIndividual.Visible = !value;
            radioButtonJuridical.Visible = !value;

            comboBoxLocality.Visible = !value;
            comboBoxLocality.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLocality.BackColor = Color.White;

            textBoxLocality.Enabled = !value;
            textBoxLocality.Visible = value;
            textBoxLocality.BackColor = Color.White;
        }

        private void FillComboBoxes()
        {
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
                    try
                    {
                        if (IsValidData())
                        {
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
                        MessageBox.Show("Некоторые поля некорретно заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }
        private bool IsValidData()
        {
            bool isValid = !(textBoxName.TextLength == 0 || textBoxTaxIdNumber.TextLength == 0 || textBoxCodeReason.TextLength == 0 || textBoxAddress.TextLength == 0
                || warningLabelName.Visible || warningLabelINN.Visible || warningLabelKPP.Visible || warningLabelAddress.Visible
                || comboBoxTypeOrganization.SelectedItem is null || comboBoxLocality.SelectedItem is null); 

            return isValid;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        #region textboxName
        private void textBoxName_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;    
            ShowWarninglabel(textBox, warningLabelName, "Не менее 7 символов", textBox.TextLength < 7);
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

        #region textBoxTaxIdNumber
        private void textBoxTaxIdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            var symbol = e.KeyChar;
            e.Handled = !char.IsControl(symbol) && !char.IsDigit(symbol);
        }

        private void textBoxTaxIdNumber_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            var countTaxIdNum = radioButtonIndividual.Checked ? 12 : 10;
            ShowWarninglabel(textBox, warningLabelINN, $"Должно быть из {countTaxIdNum} цифр", textBox.TextLength < countTaxIdNum);
        }

        private void textBoxTaxIdNumber_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelINN.Visible = false;
        }

        private void warningLabelINN_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxTaxIdNumber.Focus();
        }
        #endregion

        #region textBoxCodeReason
        private void textBoxCodeReason_KeyPress(object sender, KeyPressEventArgs e)
        {
            var symbol = e.KeyChar;
            e.Handled = !char.IsControl(symbol) && !char.IsDigit(symbol);
        }

        private void textBoxCodeReason_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            ShowWarninglabel(textBox, warningLabelKPP, $"Должно быть из 9 цифр", textBox.TextLength < 9);
        }

        private void textBoxCodeReason_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelKPP.Visible = false;
        }

        private void warningLabelKPP_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxCodeReason.Focus();
        }
        #endregion

        #region textBoxAddress
        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            ShowWarninglabel(textBox, warningLabelAddress, $"Укажите город, район, улицу", textBox.TextLength < 10);
        }

        private void textBoxAddress_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.BackColor = Color.White;
            warningLabelAddress.Visible = false;
        }

        private void warningLabelAddress_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxAddress.Focus();
        }
        #endregion

        private void radioButtonIndividual_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                textBoxTaxIdNumber.MaxLength = 12;
                textBoxTaxIdNumber.Focus();
                radioButton.Focus();
            }
            else
            {
                textBoxTaxIdNumber.MaxLength = 10;
                warningLabelINN.Visible = false;
                if (textBoxTaxIdNumber.TextLength > 10)
                {
                    var text = textBoxTaxIdNumber.Text.Substring(0,10);
                    textBoxTaxIdNumber.Text = text;
                }
            }
        }
    }
}
