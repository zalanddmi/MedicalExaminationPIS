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
                    break;
                case "Edit":
                    SetParameters(false);

                    var municipalcontractCardToEdit = new MunicipalContractsController().ShowMunicipalContractCardToEdit(ChoosedMunicipalContract);
                    textBoxNumber.Text = municipalcontractCardToEdit[0];
                    textBoxDateConclusion.Text = municipalcontractCardToEdit[1];
                    textBoxDateAction.Text = municipalcontractCardToEdit[2];
                    textBoxExecutor.Text = municipalcontractCardToEdit[3];
                    textBoxCustomer.Text = municipalcontractCardToEdit[4];                   
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
            textBoxCustomer.ReadOnly = value;
            //textBoxValue.Text  НАДО РАЗОБРАТЬСЯ С COST
            //textBoxLocality.Text           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
