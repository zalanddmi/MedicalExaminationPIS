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

namespace MedicalExamination.Views
{
    public partial class OrganizationCardView : Form
    {
        private string Function;
        private string ChoosedOrganization;

        public OrganizationCardView(string function, string choosedOrganization)
        {
            InitializeComponent();
            Function = function;
            ChoosedOrganization = choosedOrganization;
            SetParametersAndValues();
        }

        private void SetParametersAndValues()
        {
            var organization = new OrganizationsController().ShowOrganizationCardToView(ChoosedOrganization);
            textBoxName.Text = organization[0];
            textBoxTaxIdNumber.Text = organization[1];
            textBoxCodeReason.Text = organization[2];
            textBoxAddress.Text = organization[3];
            textBoxTypeOrganization.Text = organization[4];
            textBoxFormOrganization.Text = organization[5];
            textBoxLocality.Text = organization[6];
        }
    }
}
