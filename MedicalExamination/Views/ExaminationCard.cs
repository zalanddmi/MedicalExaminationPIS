using MedicalExamination.Controllers;
using MedicalExamination.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Models;

namespace MedicalExamination.Views
{
    public partial class ExaminationCard : Form
    {
        private string ChoosedAnimal;

        public ExaminationCard(int choosedAnimal)
        {
            InitializeComponent();
            ChoosedAnimal = choosedAnimal.ToString();
            SetParametersAndValues();
        }

        private void Отмена_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetParameters(bool value)
        {
            textBoxConditionAnimal.ReadOnly = value;
            textBoxDamage.ReadOnly = value;
            textBoxDiagnosis.ReadOnly = value;
            textBoxManipulations.ReadOnly = value;
            textBoxNameSpecialist.ReadOnly = value;
            textBoxPostSpecialist.ReadOnly = value;
            textBoxSkin.ReadOnly = value;
            textBoxTemperature.ReadOnly = value;
            textBoxWool.ReadOnly = value;
            textBoxTreatment.ReadOnly = value;
            textBoxPeculiaritiesBehavior.ReadOnly = value;
            comboBoxMunicipalContract.Visible = !value;
            textBoxMunicipalContract.ReadOnly = value;
            textBoxMunicipalContract.Visible = value;
            radioButtonYes.Visible = !value;
            radioButtonNo.Visible = !value;
        }

        private void ОК_Click(object sender, EventArgs e)
        {
            var examinationData = new List<string>
                {
                    textBoxPeculiaritiesBehavior.Text,
                    textBoxConditionAnimal.Text,
                    textBoxTemperature.Text,
                    textBoxSkin.Text,
                    textBoxWool.Text,
                    textBoxDamage.Text,
                    radioButtonNo.Checked ? "Да" : "Нет",
                    textBoxDiagnosis.Text,
                    textBoxManipulations.Text,
                    textBoxTreatment.Text,
                    dateTimePickerDateExamination.Value.ToShortDateString(),
                    UserSession.User.Organization.IdOrganization.ToString(),
                    ChoosedAnimal,
                    UserSession.User.IdUser.ToString(),
                    comboBoxMunicipalContract.SelectedValue.ToString()
                };
            new ExaminationController().AddExamination(examinationData.ToArray());
            Close();
        }
        private void SetParametersAndValues()
        {
            SetParameters(false);
            comboBoxMunicipalContract.DataSource = new BindingSource(
                TestData.MunicipalContracts
                .Where(munC => munC.Executor.IdOrganization == UserSession.User.Organization.IdOrganization),
                null);
            comboBoxMunicipalContract.DisplayMember = "Number";
            comboBoxMunicipalContract.ValueMember = "IdMunicipalContract";
        }

        private void Examination_Load(object sender, EventArgs e)
        {

        }
    }
}
