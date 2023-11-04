
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
            this.warningLabelName = new System.Windows.Forms.Label();
            this.warningLabelINN = new System.Windows.Forms.Label();
            this.warningLabelKPP = new System.Windows.Forms.Label();
            this.warningLabelAddress = new System.Windows.Forms.Label();
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
            this.textBoxName.Size = new System.Drawing.Size(245, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
            // 
            // textBoxTaxIdNumber
            // 
            this.textBoxTaxIdNumber.Location = new System.Drawing.Point(15, 92);
            this.textBoxTaxIdNumber.MaxLength = 12;
            this.textBoxTaxIdNumber.Name = "textBoxTaxIdNumber";
            this.textBoxTaxIdNumber.Size = new System.Drawing.Size(245, 20);
            this.textBoxTaxIdNumber.TabIndex = 3;
            this.textBoxTaxIdNumber.Enter += new System.EventHandler(this.textBoxTaxIdNumber_Enter);
            this.textBoxTaxIdNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTaxIdNumber_KeyPress);
            this.textBoxTaxIdNumber.Leave += new System.EventHandler(this.textBoxTaxIdNumber_Leave);
            // 
            // labelTaxIdNumber
            // 
            this.labelTaxIdNumber.AutoSize = true;
            this.labelTaxIdNumber.Location = new System.Drawing.Point(12, 76);
            this.labelTaxIdNumber.Name = "labelTaxIdNumber";
            this.labelTaxIdNumber.Size = new System.Drawing.Size(34, 13);
            this.labelTaxIdNumber.TabIndex = 2;
            this.labelTaxIdNumber.Text = "ИНН:";
            // 
            // textBoxCodeReason
            // 
            this.textBoxCodeReason.Location = new System.Drawing.Point(15, 131);
            this.textBoxCodeReason.MaxLength = 9;
            this.textBoxCodeReason.Name = "textBoxCodeReason";
            this.textBoxCodeReason.Size = new System.Drawing.Size(245, 20);
            this.textBoxCodeReason.TabIndex = 5;
            this.textBoxCodeReason.Enter += new System.EventHandler(this.textBoxCodeReason_Enter);
            this.textBoxCodeReason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCodeReason_KeyPress);
            this.textBoxCodeReason.Leave += new System.EventHandler(this.textBoxCodeReason_Leave);
            // 
            // labelCodeReason
            // 
            this.labelCodeReason.AutoSize = true;
            this.labelCodeReason.Location = new System.Drawing.Point(12, 115);
            this.labelCodeReason.Name = "labelCodeReason";
            this.labelCodeReason.Size = new System.Drawing.Size(33, 13);
            this.labelCodeReason.TabIndex = 4;
            this.labelCodeReason.Text = "КПП:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(16, 170);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(244, 20);
            this.textBoxAddress.TabIndex = 7;
            this.textBoxAddress.Enter += new System.EventHandler(this.textBoxAddress_Enter);
            this.textBoxAddress.Leave += new System.EventHandler(this.textBoxAddress_Leave);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(13, 154);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(108, 13);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Адрес регистрации:";
            // 
            // textBoxTypeOrganization
            // 
            this.textBoxTypeOrganization.Location = new System.Drawing.Point(16, 209);
            this.textBoxTypeOrganization.Name = "textBoxTypeOrganization";
            this.textBoxTypeOrganization.ReadOnly = true;
            this.textBoxTypeOrganization.Size = new System.Drawing.Size(244, 20);
            this.textBoxTypeOrganization.TabIndex = 9;
            // 
            // labelTypeOrganization
            // 
            this.labelTypeOrganization.AutoSize = true;
            this.labelTypeOrganization.Location = new System.Drawing.Point(13, 193);
            this.labelTypeOrganization.Name = "labelTypeOrganization";
            this.labelTypeOrganization.Size = new System.Drawing.Size(97, 13);
            this.labelTypeOrganization.TabIndex = 8;
            this.labelTypeOrganization.Text = "Тип организации:";
            // 
            // textBoxFormOrganization
            // 
            this.textBoxFormOrganization.Location = new System.Drawing.Point(16, 248);
            this.textBoxFormOrganization.Name = "textBoxFormOrganization";
            this.textBoxFormOrganization.ReadOnly = true;
            this.textBoxFormOrganization.Size = new System.Drawing.Size(244, 20);
            this.textBoxFormOrganization.TabIndex = 11;
            // 
            // labelFormOganization
            // 
            this.labelFormOganization.AutoSize = true;
            this.labelFormOganization.Location = new System.Drawing.Point(13, 232);
            this.labelFormOganization.Name = "labelFormOganization";
            this.labelFormOganization.Size = new System.Drawing.Size(126, 13);
            this.labelFormOganization.TabIndex = 10;
            this.labelFormOganization.Text = "ИП/Юридическое лицо:";
            // 
            // textBoxLocality
            // 
            this.textBoxLocality.Location = new System.Drawing.Point(16, 287);
            this.textBoxLocality.Name = "textBoxLocality";
            this.textBoxLocality.ReadOnly = true;
            this.textBoxLocality.Size = new System.Drawing.Size(244, 20);
            this.textBoxLocality.TabIndex = 13;
            // 
            // labelLocality
            // 
            this.labelLocality.AutoSize = true;
            this.labelLocality.Location = new System.Drawing.Point(13, 271);
            this.labelLocality.Name = "labelLocality";
            this.labelLocality.Size = new System.Drawing.Size(105, 13);
            this.labelLocality.TabIndex = 12;
            this.labelLocality.Text = "Населенный пункт:";
            // 
            // radioButtonIndividual
            // 
            this.radioButtonIndividual.AutoSize = true;
            this.radioButtonIndividual.Checked = true;
            this.radioButtonIndividual.Location = new System.Drawing.Point(16, 249);
            this.radioButtonIndividual.Name = "radioButtonIndividual";
            this.radioButtonIndividual.Size = new System.Drawing.Size(41, 17);
            this.radioButtonIndividual.TabIndex = 14;
            this.radioButtonIndividual.TabStop = true;
            this.radioButtonIndividual.Text = "ИП";
            this.radioButtonIndividual.UseVisualStyleBackColor = true;
            this.radioButtonIndividual.CheckedChanged += new System.EventHandler(this.radioButtonIndividual_CheckedChanged);
            // 
            // radioButtonJuridical
            // 
            this.radioButtonJuridical.AutoSize = true;
            this.radioButtonJuridical.Location = new System.Drawing.Point(63, 249);
            this.radioButtonJuridical.Name = "radioButtonJuridical";
            this.radioButtonJuridical.Size = new System.Drawing.Size(64, 17);
            this.radioButtonJuridical.TabIndex = 15;
            this.radioButtonJuridical.Text = "Юрлицо";
            this.radioButtonJuridical.UseVisualStyleBackColor = true;
            // 
            // comboBoxLocality
            // 
            this.comboBoxLocality.FormattingEnabled = true;
            this.comboBoxLocality.Location = new System.Drawing.Point(16, 287);
            this.comboBoxLocality.Name = "comboBoxLocality";
            this.comboBoxLocality.Size = new System.Drawing.Size(244, 21);
            this.comboBoxLocality.TabIndex = 16;
            // 
            // comboBoxTypeOrganization
            // 
            this.comboBoxTypeOrganization.FormattingEnabled = true;
            this.comboBoxTypeOrganization.Location = new System.Drawing.Point(16, 209);
            this.comboBoxTypeOrganization.Name = "comboBoxTypeOrganization";
            this.comboBoxTypeOrganization.Size = new System.Drawing.Size(244, 21);
            this.comboBoxTypeOrganization.TabIndex = 17;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(99, 330);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 18;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(185, 330);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // warningLabelName
            // 
            this.warningLabelName.AutoSize = true;
            this.warningLabelName.BackColor = System.Drawing.SystemColors.Control;
            this.warningLabelName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.warningLabelName.Location = new System.Drawing.Point(88, 55);
            this.warningLabelName.Name = "warningLabelName";
            this.warningLabelName.Size = new System.Drawing.Size(98, 13);
            this.warningLabelName.TabIndex = 20;
            this.warningLabelName.Text = "warning-label-name";
            this.warningLabelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.warningLabelName_MouseDown);
            // 
            // warningLabelINN
            // 
            this.warningLabelINN.AutoSize = true;
            this.warningLabelINN.BackColor = System.Drawing.SystemColors.Control;
            this.warningLabelINN.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.warningLabelINN.Location = new System.Drawing.Point(88, 96);
            this.warningLabelINN.Name = "warningLabelINN";
            this.warningLabelINN.Size = new System.Drawing.Size(86, 13);
            this.warningLabelINN.TabIndex = 21;
            this.warningLabelINN.Text = "warning-label-inn";
            this.warningLabelINN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.warningLabelINN_MouseDown);
            // 
            // warningLabelKPP
            // 
            this.warningLabelKPP.AutoSize = true;
            this.warningLabelKPP.BackColor = System.Drawing.SystemColors.Control;
            this.warningLabelKPP.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.warningLabelKPP.Location = new System.Drawing.Point(88, 135);
            this.warningLabelKPP.Name = "warningLabelKPP";
            this.warningLabelKPP.Size = new System.Drawing.Size(90, 13);
            this.warningLabelKPP.TabIndex = 22;
            this.warningLabelKPP.Text = "warning-label-kpp";
            this.warningLabelKPP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.warningLabelKPP_MouseDown);
            // 
            // warningLabelAddress
            // 
            this.warningLabelAddress.AutoSize = true;
            this.warningLabelAddress.BackColor = System.Drawing.SystemColors.Control;
            this.warningLabelAddress.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.warningLabelAddress.Location = new System.Drawing.Point(88, 174);
            this.warningLabelAddress.Name = "warningLabelAddress";
            this.warningLabelAddress.Size = new System.Drawing.Size(109, 13);
            this.warningLabelAddress.TabIndex = 23;
            this.warningLabelAddress.Text = "warning-label-address";
            this.warningLabelAddress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.warningLabelAddress_MouseDown);
            // 
            // OrganizationCardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 387);
            this.Controls.Add(this.warningLabelAddress);
            this.Controls.Add(this.warningLabelKPP);
            this.Controls.Add(this.warningLabelINN);
            this.Controls.Add(this.warningLabelName);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Организация";
            this.Load += new System.EventHandler(this.OrganizationCardView_Load);
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
        private System.Windows.Forms.Label warningLabelName;
        private System.Windows.Forms.Label warningLabelINN;
        private System.Windows.Forms.Label warningLabelKPP;
        private System.Windows.Forms.Label warningLabelAddress;
    }
}