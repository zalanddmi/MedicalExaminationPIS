
namespace MedicalExamination.Views
{
    partial class OrganizationCardView
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxTaxIdNumber = new System.Windows.Forms.TextBox();
            this.labelTaxIdNumber = new System.Windows.Forms.Label();
            this.textBoxCodeReason = new System.Windows.Forms.TextBox();
            this.labelCodeReason = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxTypeOrganization = new System.Windows.Forms.TextBox();
            this.labelTypeOrganization = new System.Windows.Forms.Label();
            this.textBoxFormOrganization = new System.Windows.Forms.TextBox();
            this.labelFormOganization = new System.Windows.Forms.Label();
            this.textBoxLocality = new System.Windows.Forms.TextBox();
            this.labelLocality = new System.Windows.Forms.Label();
            this.radioButtonIndividual = new System.Windows.Forms.RadioButton();
            this.radioButtonJuridical = new System.Windows.Forms.RadioButton();
            this.comboBoxLocality = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeOrganization = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 35);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(15, 51);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(245, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxTaxIdNumber
            // 
            this.textBoxTaxIdNumber.Location = new System.Drawing.Point(15, 90);
            this.textBoxTaxIdNumber.Name = "textBoxTaxIdNumber";
            this.textBoxTaxIdNumber.ReadOnly = true;
            this.textBoxTaxIdNumber.Size = new System.Drawing.Size(245, 20);
            this.textBoxTaxIdNumber.TabIndex = 3;
            // 
            // labelTaxIdNumber
            // 
            this.labelTaxIdNumber.AutoSize = true;
            this.labelTaxIdNumber.Location = new System.Drawing.Point(12, 74);
            this.labelTaxIdNumber.Name = "labelTaxIdNumber";
            this.labelTaxIdNumber.Size = new System.Drawing.Size(34, 13);
            this.labelTaxIdNumber.TabIndex = 2;
            this.labelTaxIdNumber.Text = "ИНН:";
            // 
            // textBoxCodeReason
            // 
            this.textBoxCodeReason.Location = new System.Drawing.Point(15, 129);
            this.textBoxCodeReason.Name = "textBoxCodeReason";
            this.textBoxCodeReason.ReadOnly = true;
            this.textBoxCodeReason.Size = new System.Drawing.Size(245, 20);
            this.textBoxCodeReason.TabIndex = 5;
            // 
            // labelCodeReason
            // 
            this.labelCodeReason.AutoSize = true;
            this.labelCodeReason.Location = new System.Drawing.Point(12, 113);
            this.labelCodeReason.Name = "labelCodeReason";
            this.labelCodeReason.Size = new System.Drawing.Size(33, 13);
            this.labelCodeReason.TabIndex = 4;
            this.labelCodeReason.Text = "КПП:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(16, 168);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(244, 20);
            this.textBoxAddress.TabIndex = 7;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(13, 152);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(108, 13);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Адрес регистрации:";
            // 
            // textBoxTypeOrganization
            // 
            this.textBoxTypeOrganization.Location = new System.Drawing.Point(16, 207);
            this.textBoxTypeOrganization.Name = "textBoxTypeOrganization";
            this.textBoxTypeOrganization.ReadOnly = true;
            this.textBoxTypeOrganization.Size = new System.Drawing.Size(244, 20);
            this.textBoxTypeOrganization.TabIndex = 9;
            // 
            // labelTypeOrganization
            // 
            this.labelTypeOrganization.AutoSize = true;
            this.labelTypeOrganization.Location = new System.Drawing.Point(13, 191);
            this.labelTypeOrganization.Name = "labelTypeOrganization";
            this.labelTypeOrganization.Size = new System.Drawing.Size(97, 13);
            this.labelTypeOrganization.TabIndex = 8;
            this.labelTypeOrganization.Text = "Тип организации:";
            // 
            // textBoxFormOrganization
            // 
            this.textBoxFormOrganization.Location = new System.Drawing.Point(16, 246);
            this.textBoxFormOrganization.Name = "textBoxFormOrganization";
            this.textBoxFormOrganization.ReadOnly = true;
            this.textBoxFormOrganization.Size = new System.Drawing.Size(244, 20);
            this.textBoxFormOrganization.TabIndex = 11;
            // 
            // labelFormOganization
            // 
            this.labelFormOganization.AutoSize = true;
            this.labelFormOganization.Location = new System.Drawing.Point(13, 230);
            this.labelFormOganization.Name = "labelFormOganization";
            this.labelFormOganization.Size = new System.Drawing.Size(126, 13);
            this.labelFormOganization.TabIndex = 10;
            this.labelFormOganization.Text = "ИП/Юридическое лицо:";
            // 
            // textBoxLocality
            // 
            this.textBoxLocality.Location = new System.Drawing.Point(16, 285);
            this.textBoxLocality.Name = "textBoxLocality";
            this.textBoxLocality.ReadOnly = true;
            this.textBoxLocality.Size = new System.Drawing.Size(244, 20);
            this.textBoxLocality.TabIndex = 13;
            // 
            // labelLocality
            // 
            this.labelLocality.AutoSize = true;
            this.labelLocality.Location = new System.Drawing.Point(13, 269);
            this.labelLocality.Name = "labelLocality";
            this.labelLocality.Size = new System.Drawing.Size(105, 13);
            this.labelLocality.TabIndex = 12;
            this.labelLocality.Text = "Населенный пункт:";
            // 
            // radioButtonIndividual
            // 
            this.radioButtonIndividual.AutoSize = true;
            this.radioButtonIndividual.Location = new System.Drawing.Point(16, 247);
            this.radioButtonIndividual.Name = "radioButtonIndividual";
            this.radioButtonIndividual.Size = new System.Drawing.Size(41, 17);
            this.radioButtonIndividual.TabIndex = 14;
            this.radioButtonIndividual.TabStop = true;
            this.radioButtonIndividual.Text = "ИП";
            this.radioButtonIndividual.UseVisualStyleBackColor = true;
            // 
            // radioButtonJuridical
            // 
            this.radioButtonJuridical.AutoSize = true;
            this.radioButtonJuridical.Location = new System.Drawing.Point(63, 247);
            this.radioButtonJuridical.Name = "radioButtonJuridical";
            this.radioButtonJuridical.Size = new System.Drawing.Size(64, 17);
            this.radioButtonJuridical.TabIndex = 15;
            this.radioButtonJuridical.TabStop = true;
            this.radioButtonJuridical.Text = "Юрлицо";
            this.radioButtonJuridical.UseVisualStyleBackColor = true;
            // 
            // comboBoxLocality
            // 
            this.comboBoxLocality.FormattingEnabled = true;
            this.comboBoxLocality.Location = new System.Drawing.Point(16, 285);
            this.comboBoxLocality.Name = "comboBoxLocality";
            this.comboBoxLocality.Size = new System.Drawing.Size(244, 21);
            this.comboBoxLocality.TabIndex = 16;
            // 
            // comboBoxTypeOrganization
            // 
            this.comboBoxTypeOrganization.FormattingEnabled = true;
            this.comboBoxTypeOrganization.Location = new System.Drawing.Point(16, 207);
            this.comboBoxTypeOrganization.Name = "comboBoxTypeOrganization";
            this.comboBoxTypeOrganization.Size = new System.Drawing.Size(244, 21);
            this.comboBoxTypeOrganization.TabIndex = 17;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(99, 328);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 18;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(185, 328);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // OrganizationCardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 384);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxTypeOrganization);
            this.Controls.Add(this.comboBoxLocality);
            this.Controls.Add(this.radioButtonJuridical);
            this.Controls.Add(this.radioButtonIndividual);
            this.Controls.Add(this.textBoxLocality);
            this.Controls.Add(this.labelLocality);
            this.Controls.Add(this.textBoxFormOrganization);
            this.Controls.Add(this.labelFormOganization);
            this.Controls.Add(this.textBoxTypeOrganization);
            this.Controls.Add(this.labelTypeOrganization);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxCodeReason);
            this.Controls.Add(this.labelCodeReason);
            this.Controls.Add(this.textBoxTaxIdNumber);
            this.Controls.Add(this.labelTaxIdNumber);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OrganizationCardView";
            this.Text = "Организация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxTaxIdNumber;
        private System.Windows.Forms.Label labelTaxIdNumber;
        private System.Windows.Forms.TextBox textBoxCodeReason;
        private System.Windows.Forms.Label labelCodeReason;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxTypeOrganization;
        private System.Windows.Forms.Label labelTypeOrganization;
        private System.Windows.Forms.TextBox textBoxFormOrganization;
        private System.Windows.Forms.Label labelFormOganization;
        private System.Windows.Forms.TextBox textBoxLocality;
        private System.Windows.Forms.Label labelLocality;
        private System.Windows.Forms.RadioButton radioButtonIndividual;
        private System.Windows.Forms.RadioButton radioButtonJuridical;
        private System.Windows.Forms.ComboBox comboBoxLocality;
        private System.Windows.Forms.ComboBox comboBoxTypeOrganization;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}