
using System.Windows.Forms;

namespace MedicalExamination.Views
{
    partial class AnimalsView
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonShowCardToAdd = new System.Windows.Forms.Button();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.labelNameFilter = new System.Windows.Forms.Label();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonUseFilter = new System.Windows.Forms.Button();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.comboBoxCountItems = new System.Windows.Forms.ComboBox();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.contextMenuStripUpdateOrDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IdAnimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberElectronicChip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameAnimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SignsAnimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SignsOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.contextMenuStripUpdateOrDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAnimal,
            this.RegNumber,
            this.Category,
            this.Sex,
            this.YearBirthday,
            this.NumberElectronicChip,
            this.NameAnimal,
            this.SignsAnimal,
            this.SignsOwner,
            this.Locality});
            this.dataGridView1.Location = new System.Drawing.Point(9, 46);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1118, 379);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // buttonShowCardToAdd
            // 
            this.buttonShowCardToAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonShowCardToAdd.FlatAppearance.BorderSize = 0;
            this.buttonShowCardToAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowCardToAdd.ForeColor = System.Drawing.Color.White;
            this.buttonShowCardToAdd.Location = new System.Drawing.Point(9, 17);
            this.buttonShowCardToAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShowCardToAdd.Name = "buttonShowCardToAdd";
            this.buttonShowCardToAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonShowCardToAdd.TabIndex = 8;
            this.buttonShowCardToAdd.Text = "Добавить";
            this.buttonShowCardToAdd.UseVisualStyleBackColor = false;
            this.buttonShowCardToAdd.Click += new System.EventHandler(this.buttonShowCardToAdd_Click);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.labelNameFilter);
            this.groupBoxFilter.Controls.Add(this.buttonClearFilter);
            this.groupBoxFilter.Controls.Add(this.textBoxFilter);
            this.groupBoxFilter.Controls.Add(this.buttonUseFilter);
            this.groupBoxFilter.Controls.Add(this.labelFilter);
            this.groupBoxFilter.Location = new System.Drawing.Point(322, 123);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(198, 100);
            this.groupBoxFilter.TabIndex = 14;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтр";
            this.groupBoxFilter.Visible = false;
            // 
            // labelNameFilter
            // 
            this.labelNameFilter.AutoSize = true;
            this.labelNameFilter.Location = new System.Drawing.Point(104, 20);
            this.labelNameFilter.Name = "labelNameFilter";
            this.labelNameFilter.Size = new System.Drawing.Size(13, 13);
            this.labelNameFilter.TabIndex = 6;
            this.labelNameFilter.Text = "0";
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Location = new System.Drawing.Point(36, 71);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFilter.TabIndex = 5;
            this.buttonClearFilter.Text = "Очистить";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(14, 37);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(179, 20);
            this.textBoxFilter.TabIndex = 1;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // buttonUseFilter
            // 
            this.buttonUseFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonUseFilter.FlatAppearance.BorderSize = 0;
            this.buttonUseFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUseFilter.ForeColor = System.Drawing.Color.White;
            this.buttonUseFilter.Location = new System.Drawing.Point(117, 71);
            this.buttonUseFilter.Name = "buttonUseFilter";
            this.buttonUseFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonUseFilter.TabIndex = 4;
            this.buttonUseFilter.Text = "Применить";
            this.buttonUseFilter.UseVisualStyleBackColor = false;
            this.buttonUseFilter.Click += new System.EventHandler(this.buttonUseFilter_Click);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(10, 22);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(60, 13);
            this.labelFilter.TabIndex = 0;
            this.labelFilter.Text = "Содержит:";
            // 
            // buttonExcel
            // 
            this.buttonExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonExcel.FlatAppearance.BorderSize = 0;
            this.buttonExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExcel.Location = new System.Drawing.Point(94, 17);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(100, 23);
            this.buttonExcel.TabIndex = 15;
            this.buttonExcel.Text = "Экспорт в Excel";
            this.buttonExcel.UseVisualStyleBackColor = false;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // comboBoxCountItems
            // 
            this.comboBoxCountItems.FormattingEnabled = true;
            this.comboBoxCountItems.Items.AddRange(new object[] {
            "1",
            "3",
            "5"});
            this.comboBoxCountItems.Location = new System.Drawing.Point(193, 436);
            this.comboBoxCountItems.Name = "comboBoxCountItems";
            this.comboBoxCountItems.Size = new System.Drawing.Size(60, 21);
            this.comboBoxCountItems.TabIndex = 21;
            this.comboBoxCountItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountItems_SelectedIndexChanged);
            // 
            // buttonFirst
            // 
            this.buttonFirst.Location = new System.Drawing.Point(13, 430);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(30, 30);
            this.buttonFirst.TabIndex = 20;
            this.buttonFirst.Text = "<<";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(49, 430);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(30, 30);
            this.buttonPrevious.TabIndex = 19;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.Location = new System.Drawing.Point(157, 430);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(30, 30);
            this.buttonLast.TabIndex = 18;
            this.buttonLast.Text = ">>";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(121, 430);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(30, 30);
            this.buttonNext.TabIndex = 17;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(85, 436);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.ReadOnly = true;
            this.textBoxPage.Size = new System.Drawing.Size(30, 20);
            this.textBoxPage.TabIndex = 16;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(1027, 17);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(100, 23);
            this.buttonClearAll.TabIndex = 22;
            this.buttonClearAll.Text = "Очистить всё";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // contextMenuStripUpdateOrDelete
            // 
            this.contextMenuStripUpdateOrDelete.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripUpdateOrDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStripUpdateOrDelete.Name = "contextMenuStripUpdateOrDelete";
            this.contextMenuStripUpdateOrDelete.Size = new System.Drawing.Size(129, 48);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click_1);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click_1);
            // 
            // IdAnimal
            // 
            this.IdAnimal.HeaderText = "IdAnimal";
            this.IdAnimal.MinimumWidth = 6;
            this.IdAnimal.Name = "IdAnimal";
            this.IdAnimal.ReadOnly = true;
            this.IdAnimal.Visible = false;
            // 
            // RegNumber
            // 
            this.RegNumber.FillWeight = 110.6952F;
            this.RegNumber.HeaderText = "Регистрационный номер";
            this.RegNumber.MinimumWidth = 6;
            this.RegNumber.Name = "RegNumber";
            this.RegNumber.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.FillWeight = 75F;
            this.Category.HeaderText = "Категория";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.FillWeight = 33F;
            this.Sex.HeaderText = "Пол";
            this.Sex.MinimumWidth = 6;
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // YearBirthday
            // 
            this.YearBirthday.FillWeight = 75F;
            this.YearBirthday.HeaderText = "Год рождения";
            this.YearBirthday.MinimumWidth = 6;
            this.YearBirthday.Name = "YearBirthday";
            this.YearBirthday.ReadOnly = true;
            // 
            // NumberElectronicChip
            // 
            this.NumberElectronicChip.FillWeight = 98.66309F;
            this.NumberElectronicChip.HeaderText = "Номер электронного чипа";
            this.NumberElectronicChip.MinimumWidth = 6;
            this.NumberElectronicChip.Name = "NumberElectronicChip";
            this.NumberElectronicChip.ReadOnly = true;
            // 
            // NameAnimal
            // 
            this.NameAnimal.FillWeight = 98.66309F;
            this.NameAnimal.HeaderText = "Кличка";
            this.NameAnimal.MinimumWidth = 6;
            this.NameAnimal.Name = "NameAnimal";
            this.NameAnimal.ReadOnly = true;
            // 
            // SignsAnimal
            // 
            this.SignsAnimal.FillWeight = 98.66309F;
            this.SignsAnimal.HeaderText = "Признаки животного";
            this.SignsAnimal.MinimumWidth = 6;
            this.SignsAnimal.Name = "SignsAnimal";
            this.SignsAnimal.ReadOnly = true;
            // 
            // SignsOwner
            // 
            this.SignsOwner.FillWeight = 98.66309F;
            this.SignsOwner.HeaderText = "Признаки владельца";
            this.SignsOwner.MinimumWidth = 6;
            this.SignsOwner.Name = "SignsOwner";
            this.SignsOwner.ReadOnly = true;
            // 
            // Locality
            // 
            this.Locality.FillWeight = 98.66309F;
            this.Locality.HeaderText = "Населённый пункт";
            this.Locality.MinimumWidth = 6;
            this.Locality.Name = "Locality";
            this.Locality.ReadOnly = true;
            // 
            // AnimalsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 467);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.comboBoxCountItems);
            this.Controls.Add(this.buttonFirst);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonLast);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.buttonShowCardToAdd);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AnimalsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Животные";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnimalsView_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.contextMenuStripUpdateOrDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonShowCardToAdd;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label labelNameFilter;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonUseFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.ComboBox comboBoxCountItems;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUpdateOrDelete;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private DataGridViewTextBoxColumn IdAnimal;
        private DataGridViewTextBoxColumn RegNumber;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Sex;
        private DataGridViewTextBoxColumn YearBirthday;
        private DataGridViewTextBoxColumn NumberElectronicChip;
        private DataGridViewTextBoxColumn NameAnimal;
        private DataGridViewTextBoxColumn SignsAnimal;
        private DataGridViewTextBoxColumn SignsOwner;
        private DataGridViewTextBoxColumn Locality;
    }
}