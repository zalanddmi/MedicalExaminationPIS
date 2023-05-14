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
    public partial class OrganizationsView : Form
    {
        public OrganizationsView()
        {
            InitializeComponent();
            var organizations = new OrganizationsController().ShowOrganizations();
            foreach (var organization in organizations)
            {
                dataGridView1.Rows.Add(organization);
            }
        }
    }
}
