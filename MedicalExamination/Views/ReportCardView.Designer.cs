namespace MedicalExamination.Views
{
    partial class ReportCardView
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
            this.textBoxTotalCount = new System.Windows.Forms.TextBox();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.buttonView = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxOrganization = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTotalCount
            // 
            this.textBoxTotalCount.Location = new System.Drawing.Point(347, 409);
            this.textBoxTotalCount.Name = "textBoxTotalCount";
            this.textBoxTotalCount.ReadOnly = true;
            this.textBoxTotalCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalCount.TabIndex = 15;
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Location = new System.Drawing.Point(301, 412);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(40, 13);
            this.labelTotalCount.TabIndex = 14;
            this.labelTotalCount.Text = "Итого:";
            // 
            // buttonView
            // 
            this.buttonView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonView.FlatAppearance.BorderSize = 0;
            this.buttonView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonView.ForeColor = System.Drawing.Color.White;
            this.buttonView.Location = new System.Drawing.Point(643, 127);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(99, 23);
            this.buttonView.TabIndex = 13;
            this.buttonView.Text = "Сформировать";
            this.buttonView.UseVisualStyleBackColor = false;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(643, 87);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(134, 20);
            this.dateTimePickerTo.TabIndex = 12;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Location = new System.Drawing.Point(627, 89);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(10, 13);
            this.labelPeriod.TabIndex = 11;
            this.labelPeriod.Text = "-";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(487, 87);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(134, 20);
            this.dateTimePickerFrom.TabIndex = 10;
            this.dateTimePickerFrom.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // labelStatistics
            // 
            this.labelStatistics.AutoSize = true;
            this.labelStatistics.Location = new System.Drawing.Point(487, 66);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(122, 13);
            this.labelStatistics.TabIndex = 9;
            this.labelStatistics.Text = "Статистика за период:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Locality,
            this.Diagnosis,
            this.Count,
            this.Price});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(435, 391);
            this.dataGridView1.TabIndex = 8;
            // 
            // Locality
            // 
            this.Locality.HeaderText = "Населенный пункт";
            this.Locality.Name = "Locality";
            this.Locality.ReadOnly = true;
            // 
            // Diagnosis
            // 
            this.Diagnosis.HeaderText = "Диагноз";
            this.Diagnosis.Name = "Diagnosis";
            this.Diagnosis.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Стоимость";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // comboBoxOrganization
            // 
            this.comboBoxOrganization.FormattingEnabled = true;
            this.comboBoxOrganization.Location = new System.Drawing.Point(487, 35);
            this.comboBoxOrganization.Name = "comboBoxOrganization";
            this.comboBoxOrganization.Size = new System.Drawing.Size(290, 21);
            this.comboBoxOrganization.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Организация:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(580, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 41);
            this.button1.TabIndex = 18;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ReportCardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 448);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOrganization);
            this.Controls.Add(this.textBoxTotalCount);
            this.Controls.Add(this.labelTotalCount);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.labelPeriod);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.labelStatistics);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportCardView";
            this.Text = "ReportCardView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTotalCount;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.ComboBox comboBoxOrganization;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}