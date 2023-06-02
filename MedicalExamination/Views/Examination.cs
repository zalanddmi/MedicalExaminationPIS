using MedicalExamination.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalExamination.Views
{
    public partial class Examination : Form
    {
        private string Function;
        private string ChoosedExamination;
        public Examination(string function)
        {
            InitializeComponent();
            Function = function;
        }
        public Examination(string function, string choosedExamination)
        {
            InitializeComponent();
            Function = function;
            ChoosedExamination = choosedExamination;
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
            comboBoxOrganization.Visible = !value;
            comboBoxMunicipalContract.Visible = !value;
            textBoxOrganization.ReadOnly = value;
            textBoxOrganization.Visible = value;
            textBoxMunicipalContract.ReadOnly = value;
            textBoxMunicipalContract.Visible = value;
            radioButtonYes.Visible = !value;
            radioButtonNo.Visible = !value;
        }

        private void ОК_Click(object sender, EventArgs e)
        {
            switch (Function)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    var examinationData = new List<string>
                    {
                        textBoxConditionAnimal.Text,
                    textBoxDamage.Text,
                    textBoxDiagnosis.Text,
                    textBoxManipulations.Text,
                    textBoxNameSpecialist.Text,
                    textBoxPostSpecialist.Text,
                    textBoxSkin.Text,
                    textBoxTemperature.Text,
                    textBoxWool.Text,
                    textBoxTreatment.Text,
                    textBoxPeculiaritiesBehavior.Text,
                    radioButtonNo.Checked ? "Нет" : "Да",
                        comboBoxOrganization.SelectedValue.ToString(),
                        comboBoxMunicipalContract.SelectedValue.ToString()
                    };
                    new ExaminationController().AddExamination(examinationData.ToArray());
                    Close();
                    break;
            }
        }
    }
}
