using System.Windows.Forms;

namespace MedicalExamination.Views
{
    partial class MunicipalContractsView
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
            this.buttonShowCardToAdd = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonLastPage = new System.Windows.Forms.Button();
            this.comboBoxCountItems = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdMunicipalContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateConclusion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Executor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.labelNameFilter = new System.Windows.Forms.Label();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonUseFilter = new System.Windows.Forms.Button();
            this.labelFilter = new System.Windows.Forms.Label();
            this.contextMenuStripUpdateOrDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.contextMenuStripUpdateOrDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShowCardToAdd
            // 
            this.buttonShowCardToAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonShowCardToAdd.FlatAppearance.BorderSize = 0;
            this.buttonShowCardToAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowCardToAdd.ForeColor = System.Drawing.Color.White;
            this.buttonShowCardToAdd.Location = new System.Drawing.Point(12, 12);
            this.buttonShowCardToAdd.Name = "buttonShowCardToAdd";
            this.buttonShowCardToAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonShowCardToAdd.TabIndex = 4;
            this.buttonShowCardToAdd.Text = "Добавить";
            this.buttonShowCardToAdd.UseVisualStyleBackColor = false;
            this.buttonShowCardToAdd.Click += new System.EventHandler(this.buttonShowCardToAdd_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonExcel.FlatAppearance.BorderSize = 0;
            this.buttonExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExcel.Location = new System.Drawing.Point(93, 12);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(100, 23);
            this.buttonExcel.TabIndex = 14;
            this.buttonExcel.Text = "Экспорт в Excel";
            this.buttonExcel.UseVisualStyleBackColor = false;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click_1);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(861, 14);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(100, 23);
            this.buttonClearAll.TabIndex = 16;
            this.buttonClearAll.Text = "Очистить всё";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(12, 507);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(30, 30);
            this.buttonFirstPage.TabIndex = 17;
            this.buttonFirstPage.Text = "<<";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(48, 507);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(30, 30);
            this.buttonPreviousPage.TabIndex = 18;
            this.buttonPreviousPage.Text = "<";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click_1);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(84, 513);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.ReadOnly = true;
            this.textBoxPage.Size = new System.Drawing.Size(30, 20);
            this.textBoxPage.TabIndex = 22;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(120, 507);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(30, 30);
            this.buttonNextPage.TabIndex = 23;
            this.buttonNextPage.Text = ">";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click_1);
            // 
            // buttonLastPage
            // 
            this.buttonLastPage.Location = new System.Drawing.Point(156, 507);
            this.buttonLastPage.Name = "buttonLastPage";
            this.buttonLastPage.Size = new System.Drawing.Size(30, 30);
            this.buttonLastPage.TabIndex = 24;
            this.buttonLastPage.Text = ">>";
            this.buttonLastPage.UseVisualStyleBackColor = true;
            this.buttonLastPage.Click += new System.EventHandler(this.buttonLastPage_Click_1);
            // 
            // comboBoxCountItems
            // 
            this.comboBoxCountItems.FormattingEnabled = true;
            this.comboBoxCountItems.Items.AddRange(new object[] {
            "1",
            "3",
            "5"});
            this.comboBoxCountItems.Location = new System.Drawing.Point(192, 513);
            this.comboBoxCountItems.Name = "comboBoxCountItems";
            this.comboBoxCountItems.Size = new System.Drawing.Size(60, 21);
            this.comboBoxCountItems.TabIndex = 25;
            this.comboBoxCountItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountItems_SelectedIndexChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMunicipalContract,
            this.Number,
            this.DateConclusion,
            this.DateAction,
            this.Executor,
            this.Customer});
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(949, 440);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick_1);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // IdMunicipalContract
            // 
            this.IdMunicipalContract.HeaderText = "Id";
            this.IdMunicipalContract.Name = "IdMunicipalContract";
            this.IdMunicipalContract.ReadOnly = true;
            this.IdMunicipalContract.Visible = false;
            // 
            // Number
            // 
            this.Number.HeaderText = "Номер";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // DateConclusion
            // 
            this.DateConclusion.FillWeight = 60F;
            this.DateConclusion.HeaderText = "Дата заключения";
            this.DateConclusion.Name = "DateConclusion";
            this.DateConclusion.ReadOnly = true;
            // 
            // DateAction
            // 
            this.DateAction.FillWeight = 60F;
            this.DateAction.HeaderText = "Дата действий";
            this.DateAction.Name = "DateAction";
            this.DateAction.ReadOnly = true;
            // 
            // Executor
            // 
            this.Executor.HeaderText = "Исполнитель";
            this.Executor.Name = "Executor";
            this.Executor.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Заказчик";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.labelNameFilter);
            this.groupBoxFilter.Controls.Add(this.buttonClearFilter);
            this.groupBoxFilter.Controls.Add(this.textBoxFilter);
            this.groupBoxFilter.Controls.Add(this.buttonUseFilter);
            this.groupBoxFilter.Controls.Add(this.labelFilter);
            this.groupBoxFilter.Location = new System.Drawing.Point(746, 433);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(198, 100);
            this.groupBoxFilter.TabIndex = 27;
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
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click_1);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(13, 38);
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
            this.buttonUseFilter.Click += new System.EventHandler(this.buttonUseFilter_Click_1);
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
            // MunicipalContractsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 550);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxCountItems);
            this.Controls.Add(this.buttonLastPage);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonShowCardToAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MunicipalContractsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Муниципальные контракты";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MunicipalContractsView_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.contextMenuStripUpdateOrDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShowCardToAdd;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonLastPage;
        private System.Windows.Forms.ComboBox comboBoxCountItems;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label labelNameFilter;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonUseFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUpdateOrDelete;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private DataGridViewTextBoxColumn IdMunicipalContract;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn DateConclusion;
        private DataGridViewTextBoxColumn DateAction;
        private DataGridViewTextBoxColumn Executor;
        private DataGridViewTextBoxColumn Customer;
    }
}