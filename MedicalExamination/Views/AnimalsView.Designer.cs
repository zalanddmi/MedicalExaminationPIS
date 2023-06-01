
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Просмотр = new System.Windows.Forms.Button();
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
            this.buttonFirst = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.Добавить = new System.Windows.Forms.Button();
            this.Изменить = new System.Windows.Forms.Button();
            this.Удалить = new System.Windows.Forms.Button();
            this.comboBoxCountItems = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1170, 501);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Просмотр
            // 
            this.Просмотр.Location = new System.Drawing.Point(12, 588);
            this.Просмотр.Name = "Просмотр";
            this.Просмотр.Size = new System.Drawing.Size(103, 23);
            this.Просмотр.TabIndex = 1;
            this.Просмотр.Text = "Просмотр";
            this.Просмотр.UseVisualStyleBackColor = true;
            this.Просмотр.Click += new System.EventHandler(this.buttonShowCard_Click);
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
            this.Category.FillWeight = 98.66309F;
            this.Category.HeaderText = "Категория";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.FillWeight = 98.66309F;
            this.Sex.HeaderText = "Пол";
            this.Sex.MinimumWidth = 6;
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // YearBirthday
            // 
            this.YearBirthday.FillWeight = 98.66309F;
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
            // buttonFirst
            // 
            this.buttonFirst.Location = new System.Drawing.Point(13, 531);
            this.buttonFirst.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(40, 37);
            this.buttonFirst.TabIndex = 2;
            this.buttonFirst.Text = "<<";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 539);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(61, 532);
            this.buttonPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(40, 37);
            this.buttonPrevious.TabIndex = 5;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(183, 532);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(40, 37);
            this.buttonNext.TabIndex = 6;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.Location = new System.Drawing.Point(231, 532);
            this.buttonLast.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(40, 37);
            this.buttonLast.TabIndex = 7;
            this.buttonLast.Text = ">>";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // Добавить
            // 
            this.Добавить.Location = new System.Drawing.Point(148, 588);
            this.Добавить.Name = "Добавить";
            this.Добавить.Size = new System.Drawing.Size(90, 23);
            this.Добавить.TabIndex = 8;
            this.Добавить.Text = "Добавить";
            this.Добавить.UseVisualStyleBackColor = true;
            this.Добавить.Click += new System.EventHandler(this.Добавить_Click);
            // 
            // Изменить
            // 
            this.Изменить.Location = new System.Drawing.Point(276, 588);
            this.Изменить.Name = "Изменить";
            this.Изменить.Size = new System.Drawing.Size(93, 23);
            this.Изменить.TabIndex = 9;
            this.Изменить.Text = "Изменить";
            this.Изменить.UseVisualStyleBackColor = true;
            this.Изменить.Click += new System.EventHandler(this.Изменить_Click);
            // 
            // Удалить
            // 
            this.Удалить.Location = new System.Drawing.Point(409, 588);
            this.Удалить.Name = "Удалить";
            this.Удалить.Size = new System.Drawing.Size(87, 23);
            this.Удалить.TabIndex = 10;
            this.Удалить.Text = "Удалить";
            this.Удалить.UseVisualStyleBackColor = true;
            this.Удалить.Click += new System.EventHandler(this.Удалить_Click);
            // 
            // comboBoxCountItems
            // 
            this.comboBoxCountItems.FormattingEnabled = true;
            this.comboBoxCountItems.Location = new System.Drawing.Point(301, 539);
            this.comboBoxCountItems.Name = "comboBoxCountItems";
            this.comboBoxCountItems.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCountItems.TabIndex = 11;
            this.comboBoxCountItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountItems_SelectedIndexChanged);
            // 
            // AnimalsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 623);
            this.Controls.Add(this.comboBoxCountItems);
            this.Controls.Add(this.Удалить);
            this.Controls.Add(this.Изменить);
            this.Controls.Add(this.Добавить);
            this.Controls.Add(this.buttonLast);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonFirst);
            this.Controls.Add(this.Просмотр);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AnimalsView";
            this.Text = "Животные";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Просмотр;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberElectronicChip;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SignsAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SignsOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.Button Добавить;
        private System.Windows.Forms.Button Изменить;
        private System.Windows.Forms.Button Удалить;
        private System.Windows.Forms.ComboBox comboBoxCountItems;
    }
}