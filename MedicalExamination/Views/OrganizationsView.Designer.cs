﻿
namespace MedicalExamination.Views
{
    partial class OrganizationsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonShowCardToView = new System.Windows.Forms.Button();
            this.buttonShowCardToAdd = new System.Windows.Forms.Button();
            this.buttonShowCardToEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.comboBoxCountItems = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.buttonUseFilter = new System.Windows.Forms.Button();
            this.checkedListBoxLocality = new System.Windows.Forms.CheckedListBox();
            this.labelLocality = new System.Windows.Forms.Label();
            this.checkedListBoxTypeOrganization = new System.Windows.Forms.CheckedListBox();
            this.labelTypeOrganization = new System.Windows.Forms.Label();
            this.IdOrganization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxIdNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOrganization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsJuridicalPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOrganization,
            this.NameOrg,
            this.TaxIdNumber,
            this.CodeReason,
            this.Address,
            this.TypeOrganization,
            this.IsJuridicalPerson,
            this.Locality});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(955, 384);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // buttonShowCardToView
            // 
            this.buttonShowCardToView.Location = new System.Drawing.Point(967, 250);
            this.buttonShowCardToView.Name = "buttonShowCardToView";
            this.buttonShowCardToView.Size = new System.Drawing.Size(75, 23);
            this.buttonShowCardToView.TabIndex = 1;
            this.buttonShowCardToView.Text = "Просмотр";
            this.buttonShowCardToView.UseVisualStyleBackColor = true;
            this.buttonShowCardToView.Click += new System.EventHandler(this.buttonShowCardToView_Click);
            // 
            // buttonShowCardToAdd
            // 
            this.buttonShowCardToAdd.Location = new System.Drawing.Point(967, 290);
            this.buttonShowCardToAdd.Name = "buttonShowCardToAdd";
            this.buttonShowCardToAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonShowCardToAdd.TabIndex = 2;
            this.buttonShowCardToAdd.Text = "Добавить";
            this.buttonShowCardToAdd.UseVisualStyleBackColor = true;
            this.buttonShowCardToAdd.Click += new System.EventHandler(this.buttonShowCardToAdd_Click);
            // 
            // buttonShowCardToEdit
            // 
            this.buttonShowCardToEdit.Location = new System.Drawing.Point(967, 319);
            this.buttonShowCardToEdit.Name = "buttonShowCardToEdit";
            this.buttonShowCardToEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonShowCardToEdit.TabIndex = 3;
            this.buttonShowCardToEdit.Text = "Изменить";
            this.buttonShowCardToEdit.UseVisualStyleBackColor = true;
            this.buttonShowCardToEdit.Click += new System.EventHandler(this.buttonShowCardToEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(967, 361);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(85, 396);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.ReadOnly = true;
            this.textBoxPage.Size = new System.Drawing.Size(30, 20);
            this.textBoxPage.TabIndex = 5;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(121, 390);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(30, 30);
            this.buttonNextPage.TabIndex = 6;
            this.buttonNextPage.Text = ">";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(157, 390);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(30, 30);
            this.buttonLastPage.TabIndex = 7;
            this.buttonLastPage.Text = ">>";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(49, 390);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(30, 30);
            this.buttonPreviousPage.TabIndex = 8;
            this.buttonPreviousPage.Text = "<";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(13, 390);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(30, 30);
            this.buttonFirstPage.TabIndex = 9;
            this.buttonFirstPage.Text = "<<";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFistPage_Click);
            // 
            // comboBoxCountItems
            // 
            this.comboBoxCountItems.FormattingEnabled = true;
            this.comboBoxCountItems.Items.AddRange(new object[] {
            "1",
            "3",
            "5"});
            this.comboBoxCountItems.Location = new System.Drawing.Point(193, 396);
            this.comboBoxCountItems.Name = "comboBoxCountItems";
            this.comboBoxCountItems.Size = new System.Drawing.Size(60, 21);
            this.comboBoxCountItems.TabIndex = 10;
            this.comboBoxCountItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountItems_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClearFilter);
            this.groupBox1.Controls.Add(this.buttonUseFilter);
            this.groupBox1.Controls.Add(this.checkedListBoxLocality);
            this.groupBox1.Controls.Add(this.labelLocality);
            this.groupBox1.Controls.Add(this.checkedListBoxTypeOrganization);
            this.groupBox1.Controls.Add(this.labelTypeOrganization);
            this.groupBox1.Location = new System.Drawing.Point(961, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 229);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтры";
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Location = new System.Drawing.Point(119, 200);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFilter.TabIndex = 5;
            this.buttonClearFilter.Text = "Очистить";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // buttonUseFilter
            // 
            this.buttonUseFilter.Location = new System.Drawing.Point(9, 200);
            this.buttonUseFilter.Name = "buttonUseFilter";
            this.buttonUseFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonUseFilter.TabIndex = 4;
            this.buttonUseFilter.Text = "Применить";
            this.buttonUseFilter.UseVisualStyleBackColor = true;
            this.buttonUseFilter.Click += new System.EventHandler(this.buttonUseFilter_Click);
            // 
            // checkedListBoxLocality
            // 
            this.checkedListBoxLocality.FormattingEnabled = true;
            this.checkedListBoxLocality.Location = new System.Drawing.Point(6, 120);
            this.checkedListBoxLocality.Name = "checkedListBoxLocality";
            this.checkedListBoxLocality.Size = new System.Drawing.Size(188, 64);
            this.checkedListBoxLocality.TabIndex = 3;
            // 
            // labelLocality
            // 
            this.labelLocality.AutoSize = true;
            this.labelLocality.Location = new System.Drawing.Point(3, 104);
            this.labelLocality.Name = "labelLocality";
            this.labelLocality.Size = new System.Drawing.Size(105, 13);
            this.labelLocality.TabIndex = 2;
            this.labelLocality.Text = "Населенный пункт:";
            // 
            // checkedListBoxTypeOrganization
            // 
            this.checkedListBoxTypeOrganization.FormattingEnabled = true;
            this.checkedListBoxTypeOrganization.Location = new System.Drawing.Point(6, 37);
            this.checkedListBoxTypeOrganization.Name = "checkedListBoxTypeOrganization";
            this.checkedListBoxTypeOrganization.Size = new System.Drawing.Size(188, 64);
            this.checkedListBoxTypeOrganization.TabIndex = 1;
            // 
            // labelTypeOrganization
            // 
            this.labelTypeOrganization.AutoSize = true;
            this.labelTypeOrganization.Location = new System.Drawing.Point(3, 21);
            this.labelTypeOrganization.Name = "labelTypeOrganization";
            this.labelTypeOrganization.Size = new System.Drawing.Size(97, 13);
            this.labelTypeOrganization.TabIndex = 0;
            this.labelTypeOrganization.Text = "Тип организации:";
            // 
            // IdOrganization
            // 
            this.IdOrganization.HeaderText = "ID";
            this.IdOrganization.Name = "IdOrganization";
            this.IdOrganization.ReadOnly = true;
            this.IdOrganization.Visible = false;
            // 
            // NameOrg
            // 
            this.NameOrg.HeaderText = "Название";
            this.NameOrg.Name = "NameOrg";
            this.NameOrg.ReadOnly = true;
            // 
            // TaxIdNumber
            // 
            this.TaxIdNumber.HeaderText = "ИНН";
            this.TaxIdNumber.Name = "TaxIdNumber";
            this.TaxIdNumber.ReadOnly = true;
            // 
            // CodeReason
            // 
            this.CodeReason.HeaderText = "КПП";
            this.CodeReason.Name = "CodeReason";
            this.CodeReason.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес регистрации";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // TypeOrganization
            // 
            this.TypeOrganization.HeaderText = "Тип организации";
            this.TypeOrganization.Name = "TypeOrganization";
            this.TypeOrganization.ReadOnly = true;
            // 
            // IsJuridicalPerson
            // 
            this.IsJuridicalPerson.HeaderText = "ИП/Юрлицо";
            this.IsJuridicalPerson.Name = "IsJuridicalPerson";
            this.IsJuridicalPerson.ReadOnly = true;
            // 
            // Locality
            // 
            this.Locality.HeaderText = "Населенный пункт";
            this.Locality.Name = "Locality";
            this.Locality.ReadOnly = true;
            // 
            // OrganizationsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 471);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxCountItems);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonShowCardToEdit);
            this.Controls.Add(this.buttonShowCardToAdd);
            this.Controls.Add(this.buttonShowCardToView);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OrganizationsView";
            this.Text = "Организации";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonShowCardToView;
        private System.Windows.Forms.Button buttonShowCardToAdd;
        private System.Windows.Forms.Button buttonShowCardToEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.ComboBox comboBoxCountItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTypeOrganization;
        private System.Windows.Forms.CheckedListBox checkedListBoxTypeOrganization;
        private System.Windows.Forms.CheckedListBox checkedListBoxLocality;
        private System.Windows.Forms.Label labelLocality;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonUseFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxIdNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsJuridicalPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
    }
}