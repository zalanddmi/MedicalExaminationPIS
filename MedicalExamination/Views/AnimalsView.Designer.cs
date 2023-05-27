
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
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
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // RegNumber
            // 
            this.RegNumber.HeaderText = "Регистрационный номер";
            this.RegNumber.MinimumWidth = 6;
            this.RegNumber.Name = "RegNumber";
            this.RegNumber.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Категория";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.HeaderText = "Пол";
            this.Sex.MinimumWidth = 6;
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // YearBirthday
            // 
            this.YearBirthday.HeaderText = "Год рождения";
            this.YearBirthday.MinimumWidth = 6;
            this.YearBirthday.Name = "YearBirthday";
            this.YearBirthday.ReadOnly = true;
            // 
            // NumberElectronicChip
            // 
            this.NumberElectronicChip.HeaderText = "Номер электронного чипа";
            this.NumberElectronicChip.MinimumWidth = 6;
            this.NumberElectronicChip.Name = "NumberElectronicChip";
            this.NumberElectronicChip.ReadOnly = true;
            // 
            // NameAnimal
            // 
            this.NameAnimal.HeaderText = "Кличка";
            this.NameAnimal.MinimumWidth = 6;
            this.NameAnimal.Name = "NameAnimal";
            this.NameAnimal.ReadOnly = true;
            // 
            // SignsAnimal
            // 
            this.SignsAnimal.HeaderText = "Признаки животного";
            this.SignsAnimal.MinimumWidth = 6;
            this.SignsAnimal.Name = "SignsAnimal";
            this.SignsAnimal.ReadOnly = true;
            // 
            // SignsOwner
            // 
            this.SignsOwner.HeaderText = "Признаки владельца";
            this.SignsOwner.MinimumWidth = 6;
            this.SignsOwner.Name = "SignsOwner";
            this.SignsOwner.ReadOnly = true;
            // 
            // Locality
            // 
            this.Locality.HeaderText = "Населённый пункт";
            this.Locality.MinimumWidth = 6;
            this.Locality.Name = "Locality";
            this.Locality.ReadOnly = true;
            // 
            // AnimalsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 591);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AnimalsView";
            this.Text = "Животные";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberElectronicChip;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SignsAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SignsOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locality;
    }
}