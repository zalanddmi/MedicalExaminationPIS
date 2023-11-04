using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using DocumentFormat.OpenXml.Spreadsheet;
using MedicalExamination.Controllers;
using MedicalExamination.Data;
using MedicalExamination.Models;
using MedicalExamination.Services;
using MedicalExamination.ViewModels;

namespace MedicalExamination.Views
{
    public partial class MunicipalContractCardView : Form
    {
        private string cardState;
        private readonly MunicipalContractsController controller;
        MunicipalContractView currentMunicipalContractCard;
        List<ViewModels.Image> scanCard;
        List<Cost> costs;
        List<Organization> organizations;
        List<Locality> localities;
        Dictionary<int, string> localitiesForCombo;
        int currentImage = 0;
        int costStatus = 0;

        public MunicipalContractCardView(string cardState)
        {
            InitializeComponent();
            this.cardState = cardState;
            controller = new MunicipalContractsController();
            scanCard = new List<ViewModels.Image>();
            costs = new List<Cost>();
            organizations = controller.GetOrganizations();
            localities = controller.GetLocalities();
            localitiesForCombo = new Dictionary<int, string>();
            SetParametersAndValues();
        }

        public MunicipalContractCardView(string cardState, int municipalContractId)
        {
            InitializeComponent();
            this.cardState = cardState;
            controller = new MunicipalContractsController();
            scanCard = new List<ViewModels.Image>();
            costs = new List<Cost>();
            currentMunicipalContractCard = controller.GetMunicipalContractCard(municipalContractId);
            organizations = controller.GetOrganizations();
            localities = controller.GetLocalities();
            localitiesForCombo = new Dictionary<int, string>();
            SetParametersAndValues();
            OpenMunicipalContractCard();
        }

        private void SetParametersAndValues()
        {
            switch (cardState)
            {
                case "View":
                    SetParameters(true);
                    FillFields();
                    dataGridViewCost.Rows.Clear();
                    foreach(var cost in currentMunicipalContractCard.Costs)
                    {
                        dataGridViewCost.Rows.Add(cost.IdCost, cost.Locality.IdLocality, cost.Locality.Name, cost.Value);
                    }
                    break;
                case "Add":
                    SetParameters(false);
                    FillComboBoxes();
                    break;
                case "Edit":
                    SetParameters(false);
                    FillComboBoxes();
                    FillFields();
                    comboBoxExecutor.Text = currentMunicipalContractCard.Executor.Name;
                    comboBoxCustomer.Text = currentMunicipalContractCard.Customer.Name;
                    dataGridViewCost.Rows.Clear();
                    foreach (var cost in currentMunicipalContractCard.Costs)
                    {
                        dataGridViewCost.Rows.Add(cost.IdCost, cost.Locality.IdLocality, cost.Locality.Name, cost.Value);
                    }
                    break;
            }
        }

        private void FillFields()
        {
            textBoxNumber.Text = currentMunicipalContractCard.Number;
            textBoxDateConclusion.Text = currentMunicipalContractCard.DateConclusion.ToShortDateString();
            textBoxDateAction.Text = currentMunicipalContractCard.DateAction.ToShortDateString();
            textBoxExecutor.Text = currentMunicipalContractCard.Executor.Name;
            textBoxCustomer.Text = currentMunicipalContractCard.Customer.Name;
            dateTimePickerDateConclusion.Value = currentMunicipalContractCard.DateConclusion;
            dateTimePickerDateAction.Value = currentMunicipalContractCard.DateAction;
            ShowScan(currentMunicipalContractCard.Scan);
        }

        public void ShowScan(List<ViewModels.Image> scan)
        {
            scanCard = scan;

            if (scanCard.Count != 0)
            {
                ChangeImage(0);
            }
        }

        private void ChangeImage(int index)
        {
            if (index == -1)
            {
                pictureBox.Image = null;
                return;
            }
            Bitmap bitmap;
            using (MemoryStream stream = new MemoryStream(scanCard[index].data))
            {
                bitmap = new Bitmap(stream);
            }
            pictureBox.Image = bitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void ShowPrevImage()
        {
            if (scanCard.Count == 0)
            {
                ChangeImage(-1);
                return;
            }

            if (currentImage < 0)
                currentImage = scanCard.Count - 1;

            if (scanCard[currentImage].data != null)
            {
                ChangeImage(currentImage);
                return;
            }


            for (int i = currentImage; i >= 0; i--)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            for (int i = scanCard.Count - 1; i > currentImage; i--)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            ChangeImage(-1);
        }

        private void ShowNextImage()
        {
            if (scanCard.Count == 0)
            {
                ChangeImage(-1);
                return;
            }


            if (currentImage > scanCard.Count - 1)
                currentImage = 0;
            if (scanCard[currentImage].data != null)
            {
                ChangeImage(currentImage);
                return;
            }


            for (int i = currentImage; i < scanCard.Count; i++)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }
            for (int i = 0; i < currentImage; i++)
            {
                if (scanCard[i].data != null)
                {
                    currentImage = i;
                    ChangeImage(currentImage);
                    return;
                }
            }

            ChangeImage(-1);
        }

        private void SetParameters(bool value)
        {
            textBoxNumber.ReadOnly = value;
            textBoxDateConclusion.ReadOnly = value;
            textBoxDateAction.ReadOnly = value;
            textBoxExecutor.ReadOnly = value;
            textBoxExecutor.Visible = value;
            comboBoxExecutor.Visible = !value;
            textBoxCustomer.ReadOnly = value;
            textBoxCustomer.Visible = value;
            comboBoxCustomer.Visible = !value;
            buttonAddCost.Visible = !value;
            buttonEditCost.Visible = !value;
            buttonDeleteCost.Visible = !value;
            buttonAddScan.Visible = !value;
            buttonDeleteScan.Visible = !value;
            dateTimePickerDateAction.Visible = !value;
            dateTimePickerDateConclusion.Visible = !value;
        }

        private void FillComboBoxes()
        {
            comboBoxExecutor.DataSource = new BindingSource(organizations, null);
            comboBoxExecutor.DisplayMember = "Name";
            comboBoxExecutor.ValueMember = "IdOrganization";
            comboBoxCustomer.DataSource = new BindingSource(organizations, null);
            comboBoxCustomer.ValueMember = "IdOrganization";
            comboBoxCustomer.DisplayMember = "Name";
        }

        private void FillLocalities(bool isAdd)
        {
            localitiesForCombo.Clear();
            foreach (var item in localities)
            {
                localitiesForCombo.Add(item.IdLocality, item.Name);
            }
            if (dataGridViewCost.Rows.Count != 0)
            {
                if (isAdd)
                {
                    foreach (DataGridViewRow row in dataGridViewCost.Rows)
                    {
                        localitiesForCombo.Remove(Convert.ToInt32(row.Cells["IdLocalityColumn"].Value));
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridViewCost.Rows)
                    {
                        if (row != dataGridViewCost.CurrentRow)
                        {
                            localitiesForCombo.Remove(Convert.ToInt32(row.Cells["IdLocalityColumn"].Value));
                        }
                    }
                }
            }
            comboBoxLocality.DataSource = new BindingSource(localitiesForCombo, null);
            comboBoxLocality.DisplayMember = "Value";
            comboBoxLocality.ValueMember = "Key";
        }

        private void SetEnabledButtons(bool value)
        {
            groupBoxCost.Visible = !value;
            buttonAddCost.Enabled = value;
            buttonEditCost.Enabled = value;
            buttonDeleteCost.Enabled = value;
            buttonOK.Enabled = value;
            buttonCancel.Enabled = value;
            buttonAddScan.Enabled = value;
            buttonDeleteScan.Enabled = value;
            ButtonPrevious.Enabled = value;
            ButtonNext.Enabled = value;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenMunicipalContractCard()
        {
            //var municipalcontract = controller.ShowMunicipalContractCardToView(currentMunicipalContractId);
            //List<string> photos = municipalcontract[municipalcontract.Length - 1].Split(';').ToList();
            //ShowPhotos(photos);
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            switch (cardState)
            {
                case "View":
                    Close();
                    break;
                case "Add":
                    for (int i = 0; i < dataGridViewCost.Rows.Count; i++)
                    {
                        var value = Convert.ToDouble(dataGridViewCost.Rows[i].Cells["ValueColumn"].Value);
                        var locality = localities.First(loc => loc.IdLocality == Convert.ToInt32(dataGridViewCost.Rows[i].Cells["IdLocalityColumn"].Value));
                        var contract = new MunicipalContract
                            (
                            textBoxNumber.Text,
                            dateTimePickerDateConclusion.Value,
                            dateTimePickerDateAction.Value,
                            new List<string>(),
                            (Organization)comboBoxExecutor.SelectedItem,
                            (Organization)comboBoxCustomer.SelectedItem
                            );
                        var cost = new Cost(value, locality, contract);
                        costs.Add(cost);
                    }
                    var municipalContractNew = new MunicipalContractView
                        (
                            textBoxNumber.Text,
                            dateTimePickerDateConclusion.Value,
                            dateTimePickerDateAction.Value,
                            scanCard,
                            (Organization)comboBoxExecutor.SelectedItem,
                            (Organization)comboBoxCustomer.SelectedItem,
                            costs
                        );
                    
                    controller.AddMunicipalContract(municipalContractNew);
                    Close();
                    break;
                case "Edit":
                    for (int i = 0; i < dataGridViewCost.Rows.Count; i++)
                    {
                        var value = Convert.ToDouble(dataGridViewCost.Rows[i].Cells["ValueColumn"].Value);
                        var locality = localities.First(loc => loc.IdLocality == Convert.ToInt32(dataGridViewCost.Rows[i].Cells["IdLocalityColumn"].Value));
                        var idCost = dataGridViewCost.Rows[i].Cells["IdColumn"].Value;
                        var contract = new MunicipalContract
                            (
                            textBoxNumber.Text,
                            dateTimePickerDateConclusion.Value,
                            dateTimePickerDateAction.Value,
                            new List<string>(),
                            (Organization)comboBoxExecutor.SelectedItem,
                            (Organization)comboBoxCustomer.SelectedItem
                            );
                        Cost cost;
                        if (idCost != null)
                        {
                            cost = new Cost(Convert.ToInt32(idCost), value, locality, contract);
                        }
                        else
                        {
                            cost = new Cost(value, locality, contract);
                        } 
                        costs.Add(cost);
                    }
                    currentMunicipalContractCard.Number = textBoxNumber.Text;
                    currentMunicipalContractCard.DateConclusion = dateTimePickerDateConclusion.Value;
                    currentMunicipalContractCard.DateAction = dateTimePickerDateAction.Value;
                    currentMunicipalContractCard.Scan = scanCard;
                    currentMunicipalContractCard.Executor = (Organization)comboBoxExecutor.SelectedItem;
                    currentMunicipalContractCard.Customer = (Organization)comboBoxCustomer.SelectedItem;
                    currentMunicipalContractCard.Costs = costs;
                    controller.UpdateMunicipalContract(currentMunicipalContractCard);
                    Close();
                    break;
            }
        }
        public void ShowPhotos(List<string> photos)
        {
            panelScan.Controls.Clear();
            for (int i = 0; i < photos.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = photos[i];
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = i * (pictureBox.Height + 10);
                panelScan.Controls.Add(pictureBox);
            }
            panelScan.Height = photos.Count * (pictureBox.Height + 10);
        }

        private void AddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.ImageLocation = openFile.FileName;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 200;
                pictureBox.Height = 150;
                pictureBox.Top = panelScan.Controls.Count * (pictureBox.Height + 10);
                panelScan.Controls.Add(pictureBox);
            }
        }

        private void DeletePhoto_Click(object sender, EventArgs e)
        {
            if (panelScan.Controls.Count > 0)
            {
                PictureBox pictureBox = panelScan.Controls[panelScan.Controls.Count - 1] as PictureBox;
                if (pictureBox != null)
                {
                    panelScan.Controls.Remove(pictureBox);
                }
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            currentImage--;
            ShowPrevImage();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            currentImage++;
            ShowNextImage();
        }

        private void buttonAddCost_Click(object sender, EventArgs e)
        {
            FillLocalities(true);
            if (localitiesForCombo.Count == 0)
            {
                MessageBox.Show("Больше нет населенных пунктов для добавления стоимости");
            }
            else
            {
                SetEnabledButtons(false);
                costStatus = 1;
            }
        }

        private void buttonEditCost_Click(object sender, EventArgs e)
        {
            if (dataGridViewCost.CurrentRow != null)
            {
                FillLocalities(false);
                comboBoxLocality.SelectedItem = Convert.ToInt32(dataGridViewCost.CurrentRow.Cells["IdLocalityColumn"].Value);
                textBoxValue.Text = Convert.ToString(dataGridViewCost.CurrentRow.Cells["ValueColumn"].Value);
                SetEnabledButtons(false);
                costStatus = 2;
            }
        }

        private void buttonDeleteCost_Click(object sender, EventArgs e)
        {
            if (dataGridViewCost.CurrentRow != null)
            {
                dataGridViewCost.Rows.Remove(dataGridViewCost.CurrentRow);
            }
        }

        private void buttonOKCost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxValue.Text))
            {
                MessageBox.Show("Введите значение стоимости");
            }
            else
            {
                var selectedLocality = (KeyValuePair<int, string>)comboBoxLocality.SelectedItem;
                var selectedId = selectedLocality.Key;
                var selectedName = selectedLocality.Value;
                var value = Convert.ToDouble(textBoxValue.Text);
                if (costStatus == 1)
                {
                    dataGridViewCost.Rows.Add(null, selectedId, selectedName, value);
                }
                else if (costStatus == 2)
                {
                    dataGridViewCost.CurrentRow.Cells["IdLocalityColumn"].Value = selectedId;
                    dataGridViewCost.CurrentRow.Cells["LocalityColumn"].Value = selectedName;
                    dataGridViewCost.CurrentRow.Cells["ValueColumn"].Value = value;
                }
                SetEnabledButtons(true);
                textBoxValue.Text = null;
            }
        }

        private void buttonCancelCost_Click(object sender, EventArgs e)
        {
            SetEnabledButtons(true);
        }

        private void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonAddScan_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                var scanB = File.ReadAllBytes(openFile.FileName);
                scanCard.Add(new ViewModels.Image(scanB));
                currentImage = scanCard.Count - 1;
                ChangeImage(currentImage);
            }
        }

        private void buttonDeleteScan_Click(object sender, EventArgs e)
        {
            if (currentImage >= 0 && currentImage < scanCard.Count)
            {
                if (scanCard[currentImage].filePath == null)
                {
                    scanCard.RemoveAt(currentImage);
                    currentImage--;
                    ShowPrevImage();
                    return;
                }
                scanCard[currentImage].data = null;
                currentImage--;
                ShowPrevImage();
            }
        }
    }
}
