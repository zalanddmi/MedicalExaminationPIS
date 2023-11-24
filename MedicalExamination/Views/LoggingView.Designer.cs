using System.Windows.Forms;

namespace MedicalExamination.Views
{
    partial class LoggingView
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
            this.dataGridViewLogging = new System.Windows.Forms.DataGridView();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBoxCountItems = new System.Windows.Forms.ComboBox();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.labelNameFilter = new System.Windows.Forms.Label();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonUseFilter = new System.Windows.Forms.Button();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.IdLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StructuralDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogging)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLogging
            // 
            this.dataGridViewLogging.AllowUserToAddRows = false;
            this.dataGridViewLogging.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewLogging.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLogging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogging.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdLog,
            this.Operation,
            this.FullName,
            this.Number,
            this.Email,
            this.Organization,
            this.StructuralDivision,
            this.Post,
            this.WorkNumber,
            this.WorkEmail,
            this.Login,
            this.Date,
            this.NameObject,
            this.IdObject,
            this.DescriptionObject,
            this.FileNames});
            this.dataGridViewLogging.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewLogging.Name = "dataGridViewLogging";
            this.dataGridViewLogging.ReadOnly = true;
            this.dataGridViewLogging.RowHeadersVisible = false;
            this.dataGridViewLogging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLogging.Size = new System.Drawing.Size(1356, 739);
            this.dataGridViewLogging.TabIndex = 0;
            this.dataGridViewLogging.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLogging_CellContentClick);
            this.dataGridViewLogging.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLogging_ColumnHeaderMouseClick);
            // 
            // buttonExcel
            // 
            this.buttonExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonExcel.FlatAppearance.BorderSize = 0;
            this.buttonExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExcel.Location = new System.Drawing.Point(12, 11);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(100, 23);
            this.buttonExcel.TabIndex = 16;
            this.buttonExcel.Text = "Экспорт в Excel";
            this.buttonExcel.UseVisualStyleBackColor = false;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(118, 11);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(100, 23);
            this.buttonSelectAll.TabIndex = 17;
            this.buttonSelectAll.Text = "Выделить всё";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(223, 11);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 26;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // comboBoxCountItems
            // 
            this.comboBoxCountItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountItems.FormattingEnabled = true;
            this.comboBoxCountItems.Location = new System.Drawing.Point(192, 796);
            this.comboBoxCountItems.Name = "comboBoxCountItems";
            this.comboBoxCountItems.Size = new System.Drawing.Size(60, 21);
            this.comboBoxCountItems.TabIndex = 32;
            this.comboBoxCountItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountItems_SelectedIndexChanged);
            // 
            // buttonFirst
            // 
            this.buttonFirst.Location = new System.Drawing.Point(12, 790);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(30, 30);
            this.buttonFirst.TabIndex = 31;
            this.buttonFirst.Text = "<<";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(48, 790);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(30, 30);
            this.buttonPrevious.TabIndex = 30;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.Location = new System.Drawing.Point(156, 790);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(30, 30);
            this.buttonLast.TabIndex = 29;
            this.buttonLast.Text = ">>";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(120, 790);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(30, 30);
            this.buttonNext.TabIndex = 28;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(84, 796);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.ReadOnly = true;
            this.textBoxPage.Size = new System.Drawing.Size(30, 20);
            this.textBoxPage.TabIndex = 27;
            this.textBoxPage.Text = "1";
            this.textBoxPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.labelNameFilter);
            this.groupBoxFilter.Controls.Add(this.buttonClearFilter);
            this.groupBoxFilter.Controls.Add(this.textBoxFilter);
            this.groupBoxFilter.Controls.Add(this.buttonUseFilter);
            this.groupBoxFilter.Controls.Add(this.labelFilter);
            this.groupBoxFilter.Location = new System.Drawing.Point(20, 116);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(198, 100);
            this.groupBoxFilter.TabIndex = 33;
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
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(1792, 11);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(100, 23);
            this.buttonClearAll.TabIndex = 34;
            this.buttonClearAll.Text = "Очистить всё";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // IdLog
            // 
            this.IdLog.HeaderText = "IdLog";
            this.IdLog.Name = "IdLog";
            this.IdLog.ReadOnly = true;
            this.IdLog.Visible = false;
            this.IdLog.Width = 60;
            // 
            // Operation
            // 
            this.Operation.HeaderText = "Операция";
            this.Operation.Name = "Operation";
            this.Operation.ReadOnly = true;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "ФИО";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // Number
            // 
            this.Number.HeaderText = "Телефон";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 80;
            // 
            // Email
            // 
            this.Email.HeaderText = "Эл. почта";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 80;
            // 
            // Organization
            // 
            this.Organization.HeaderText = "Организация";
            this.Organization.Name = "Organization";
            this.Organization.ReadOnly = true;
            // 
            // StructuralDivision
            // 
            this.StructuralDivision.HeaderText = "Структурное подразделение";
            this.StructuralDivision.Name = "StructuralDivision";
            this.StructuralDivision.ReadOnly = true;
            this.StructuralDivision.Width = 80;
            // 
            // Post
            // 
            this.Post.HeaderText = "Должность";
            this.Post.Name = "Post";
            this.Post.ReadOnly = true;
            this.Post.Width = 80;
            // 
            // WorkNumber
            // 
            this.WorkNumber.HeaderText = "Раб. телефон";
            this.WorkNumber.Name = "WorkNumber";
            this.WorkNumber.ReadOnly = true;
            this.WorkNumber.Width = 80;
            // 
            // WorkEmail
            // 
            this.WorkEmail.HeaderText = "Раб. адрес эл. почты";
            this.WorkEmail.Name = "WorkEmail";
            this.WorkEmail.ReadOnly = true;
            this.WorkEmail.Width = 80;
            // 
            // Login
            // 
            this.Login.HeaderText = "Логин";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 80;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата и время";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 115;
            // 
            // NameObject
            // 
            this.NameObject.HeaderText = "Объект";
            this.NameObject.Name = "NameObject";
            this.NameObject.ReadOnly = true;
            this.NameObject.Width = 70;
            // 
            // IdObject
            // 
            this.IdObject.HeaderText = "ID объекта";
            this.IdObject.Name = "IdObject";
            this.IdObject.ReadOnly = true;
            this.IdObject.Width = 50;
            // 
            // DescriptionObject
            // 
            this.DescriptionObject.HeaderText = "Описание объекта после совершения действия";
            this.DescriptionObject.Name = "DescriptionObject";
            this.DescriptionObject.ReadOnly = true;
            this.DescriptionObject.Width = 125;
            // 
            // FileNames
            // 
            this.FileNames.HeaderText = "Загруженный файл";
            this.FileNames.Name = "FileNames";
            this.FileNames.ReadOnly = true;
            // 
            // LoggingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 826);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.comboBoxCountItems);
            this.Controls.Add(this.buttonFirst);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonLast);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.dataGridViewLogging);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoggingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал операций";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoggingView_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogging)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLogging;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxCountItems;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label labelNameFilter;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonUseFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button buttonClearAll;
        private DataGridViewTextBoxColumn IdLog;
        private DataGridViewTextBoxColumn Operation;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Organization;
        private DataGridViewTextBoxColumn StructuralDivision;
        private DataGridViewTextBoxColumn Post;
        private DataGridViewTextBoxColumn WorkNumber;
        private DataGridViewTextBoxColumn WorkEmail;
        private DataGridViewTextBoxColumn Login;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn NameObject;
        private DataGridViewTextBoxColumn IdObject;
        private DataGridViewTextBoxColumn DescriptionObject;
        private DataGridViewTextBoxColumn FileNames;
    }
}