
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdOrganization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxIdNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOrganization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsJuridicalPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonShowCardToAdd = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.comboBoxCountItems = new System.Windows.Forms.ComboBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.buttonUseFilter = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.contextMenuStripUpdateOrDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.labelNameFilter = new System.Windows.Forms.Label();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripUpdateOrDelete.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1256, 384);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // IdOrganization
            // 
            this.IdOrganization.HeaderText = "ID";
            this.IdOrganization.MinimumWidth = 6;
            this.IdOrganization.Name = "IdOrganization";
            this.IdOrganization.ReadOnly = true;
            this.IdOrganization.Visible = false;
            // 
            // NameOrg
            // 
            this.NameOrg.HeaderText = "Название";
            this.NameOrg.MinimumWidth = 6;
            this.NameOrg.Name = "NameOrg";
            this.NameOrg.ReadOnly = true;
            // 
            // TaxIdNumber
            // 
            this.TaxIdNumber.HeaderText = "ИНН";
            this.TaxIdNumber.MinimumWidth = 6;
            this.TaxIdNumber.Name = "TaxIdNumber";
            this.TaxIdNumber.ReadOnly = true;
            // 
            // CodeReason
            // 
            this.CodeReason.HeaderText = "КПП";
            this.CodeReason.MinimumWidth = 6;
            this.CodeReason.Name = "CodeReason";
            this.CodeReason.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес регистрации";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // TypeOrganization
            // 
            this.TypeOrganization.HeaderText = "Тип организации";
            this.TypeOrganization.MinimumWidth = 6;
            this.TypeOrganization.Name = "TypeOrganization";
            this.TypeOrganization.ReadOnly = true;
            // 
            // IsJuridicalPerson
            // 
            this.IsJuridicalPerson.HeaderText = "ИП/Юрлицо";
            this.IsJuridicalPerson.MinimumWidth = 6;
            this.IsJuridicalPerson.Name = "IsJuridicalPerson";
            this.IsJuridicalPerson.ReadOnly = true;
            // 
            // Locality
            // 
            this.Locality.HeaderText = "Населенный пункт";
            this.Locality.MinimumWidth = 6;
            this.Locality.Name = "Locality";
            this.Locality.ReadOnly = true;
            // 
            // buttonShowCardToAdd
            // 
            this.buttonShowCardToAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonShowCardToAdd.ForeColor = System.Drawing.Color.White;
            this.buttonShowCardToAdd.Location = new System.Drawing.Point(4, 7);
            this.buttonShowCardToAdd.Name = "buttonShowCardToAdd";
            this.buttonShowCardToAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonShowCardToAdd.TabIndex = 2;
            this.buttonShowCardToAdd.Text = "Добавить";
            this.buttonShowCardToAdd.UseVisualStyleBackColor = false;
            this.buttonShowCardToAdd.Click += new System.EventHandler(this.buttonShowCardToAdd_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(85, 437);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.ReadOnly = true;
            this.textBoxPage.Size = new System.Drawing.Size(30, 20);
            this.textBoxPage.TabIndex = 5;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(121, 431);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(30, 30);
            this.buttonNextPage.TabIndex = 6;
            this.buttonNextPage.Text = ">";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(157, 431);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(30, 30);
            this.buttonLastPage.TabIndex = 7;
            this.buttonLastPage.Text = ">>";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(49, 431);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(30, 30);
            this.buttonPreviousPage.TabIndex = 8;
            this.buttonPreviousPage.Text = "<";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(13, 431);
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
            this.comboBoxCountItems.Location = new System.Drawing.Point(193, 437);
            this.comboBoxCountItems.Name = "comboBoxCountItems";
            this.comboBoxCountItems.Size = new System.Drawing.Size(38, 21);
            this.comboBoxCountItems.TabIndex = 10;
            this.comboBoxCountItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountItems_SelectedIndexChanged);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Location = new System.Drawing.Point(46, 71);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(65, 23);
            this.buttonClearFilter.TabIndex = 5;
            this.buttonClearFilter.Text = "Очистить";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // buttonUseFilter
            // 
            this.buttonUseFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonUseFilter.ForeColor = System.Drawing.Color.White;
            this.buttonUseFilter.Location = new System.Drawing.Point(117, 71);
            this.buttonUseFilter.Name = "buttonUseFilter";
            this.buttonUseFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonUseFilter.TabIndex = 4;
            this.buttonUseFilter.Text = "Применить";
            this.buttonUseFilter.UseVisualStyleBackColor = false;
            this.buttonUseFilter.Click += new System.EventHandler(this.buttonUseFilter_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExcel.Location = new System.Drawing.Point(89, 7);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(100, 23);
            this.buttonExcel.TabIndex = 12;
            this.buttonExcel.Text = "Экспорт в Excel";
            this.buttonExcel.UseVisualStyleBackColor = false;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
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
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.labelNameFilter);
            this.groupBoxFilter.Controls.Add(this.buttonClearFilter);
            this.groupBoxFilter.Controls.Add(this.textBoxFilter);
            this.groupBoxFilter.Controls.Add(this.buttonUseFilter);
            this.groupBoxFilter.Controls.Add(this.labelFilter);
            this.groupBoxFilter.Location = new System.Drawing.Point(147, 72);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(198, 100);
            this.groupBoxFilter.TabIndex = 13;
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
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(13, 38);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(179, 20);
            this.textBoxFilter.TabIndex = 1;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
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
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(1171, 7);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(85, 23);
            this.buttonClearAll.TabIndex = 14;
            this.buttonClearAll.Text = "Очистить всё";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Количество элементов на странице";
            // 
            // OrganizationsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 471);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.comboBoxCountItems);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonShowCardToAdd);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OrganizationsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Организации";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OrganizationsView_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripUpdateOrDelete.ResumeLayout(false);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonShowCardToAdd;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.ComboBox comboBoxCountItems;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonUseFilter;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxIdNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsJuridicalPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUpdateOrDelete;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Label labelNameFilter;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Label label1;
    }
}