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
    public partial class AnimalsView : Form
    {
        private List<string[]> animals;


        public AnimalsView()
        {
            InitializeComponent();
            ShowRegistry();
        }
        private void ShowRegistry()
        {
            dataGridView1.Rows.Clear();
            animals = new AnimalsController().ShowAnimals();
            foreach (var animal in animals)
            {
                dataGridView1.Rows.Add(animal);
            }
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
