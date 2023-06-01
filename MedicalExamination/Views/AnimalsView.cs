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
        private int currentPage;
        private int pageSize;
        private string filter;
        private string sorting;

        public AnimalsView()
        {
            InitializeComponent();
            ShowRegistry();
        }
        private void ShowRegistry()
        {
            dataGridView1.Rows.Clear();
            animals = new AnimalsController().ShowAnimals(filter, sorting, currentPage, pageSize);
            foreach (var animal in animals)
            {
                dataGridView1.Rows.Add(animal);
            }
            UpdateNavigationButtons();

        }

        private void UpdateNavigationButtons()
        {
            buttonFirst.Enabled = currentPage > 1;
            buttonPrevious.Enabled = currentPage > 1;
            buttonNext.Enabled = !IsLastPage();
            buttonLast.Enabled = !IsLastPage();
            textBox1.Text = currentPage.ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonShowCard_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var choosedAnimal = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                AnimalsCardView animalCardView = new AnimalsCardView("View", choosedAnimal);
                animalCardView.ShowDialog();
            }
        }

        private void Добавить_Click(object sender, EventArgs e)
        {
            AnimalsCardView animalCardView = new AnimalsCardView("Add");
            animalCardView.ShowDialog();
            ShowRegistry();
        }

        private void Изменить_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var choosedAnimal = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                AnimalsCardView animalCardView = new AnimalsCardView("Edit", choosedAnimal);
                animalCardView.ShowDialog();
                ShowRegistry();
            }
        }

        private void Удалить_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var choosedAnimal = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                new AnimalsController().DeleteAnimal(choosedAnimal);
                ShowRegistry();
            }
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ShowRegistry();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowRegistry();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (!IsLastPage())
            {
                currentPage++;
                ShowRegistry();
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            currentPage = CalculateLastPage();
            ShowRegistry();
        }

        private void comboBoxCountItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private int CalculateLastPage()
        {
            int totalItems = new AnimalsController().ShowAnimals(filter, sorting, 1, int.MaxValue).Count;
            int lastPage = totalItems / pageSize;
            if (totalItems % pageSize != 0)
            {
                lastPage++;
            }
            return lastPage;
        }
        private bool IsLastPage()
        {
            int totalItems = new AnimalsController().ShowAnimals(filter, sorting, 1, int.MaxValue).Count;
            int lastItemIndex = (currentPage - 1) * pageSize + pageSize;
            return lastItemIndex >= totalItems;
        }
    }
}
