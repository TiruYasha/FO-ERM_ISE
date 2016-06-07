namespace FO_ERM_ISE.presentation.predicaat
{
    partial class PredicaatManagementFrm
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
            this.lblVerwoording = new System.Windows.Forms.Label();
            this.txtVerwoording = new System.Windows.Forms.TextBox();
            this.lblAttributes = new System.Windows.Forms.Label();
            this.lbAttributes = new System.Windows.Forms.ListBox();
            this.lblPredicaat = new System.Windows.Forms.Label();
            this.txtPredicaat = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVerwoording
            // 
            this.lblVerwoording.AutoSize = true;
            this.lblVerwoording.Location = new System.Drawing.Point(12, 9);
            this.lblVerwoording.Name = "lblVerwoording";
            this.lblVerwoording.Size = new System.Drawing.Size(66, 13);
            this.lblVerwoording.TabIndex = 0;
            this.lblVerwoording.Text = "Verwoording";
            // 
            // txtVerwoording
            // 
            this.txtVerwoording.Location = new System.Drawing.Point(15, 26);
            this.txtVerwoording.Multiline = true;
            this.txtVerwoording.Name = "txtVerwoording";
            this.txtVerwoording.ReadOnly = true;
            this.txtVerwoording.Size = new System.Drawing.Size(256, 78);
            this.txtVerwoording.TabIndex = 1;
            // 
            // lblAttributes
            // 
            this.lblAttributes.AutoSize = true;
            this.lblAttributes.Location = new System.Drawing.Point(12, 117);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(52, 13);
            this.lblAttributes.TabIndex = 2;
            this.lblAttributes.Text = "Attributen";
            // 
            // lbAttributes
            // 
            this.lbAttributes.FormattingEnabled = true;
            this.lbAttributes.Location = new System.Drawing.Point(15, 134);
            this.lbAttributes.Name = "lbAttributes";
            this.lbAttributes.Size = new System.Drawing.Size(257, 147);
            this.lbAttributes.TabIndex = 3;
            // 
            // lblPredicaat
            // 
            this.lblPredicaat.AutoSize = true;
            this.lblPredicaat.Location = new System.Drawing.Point(12, 292);
            this.lblPredicaat.Name = "lblPredicaat";
            this.lblPredicaat.Size = new System.Drawing.Size(52, 13);
            this.lblPredicaat.TabIndex = 4;
            this.lblPredicaat.Text = "Predicaat";
            // 
            // txtPredicaat
            // 
            this.txtPredicaat.Location = new System.Drawing.Point(15, 308);
            this.txtPredicaat.Multiline = true;
            this.txtPredicaat.Name = "txtPredicaat";
            this.txtPredicaat.ReadOnly = true;
            this.txtPredicaat.Size = new System.Drawing.Size(257, 110);
            this.txtPredicaat.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(196, 424);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(115, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // PredicaatManagementFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 470);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPredicaat);
            this.Controls.Add(this.lblPredicaat);
            this.Controls.Add(this.lbAttributes);
            this.Controls.Add(this.lblAttributes);
            this.Controls.Add(this.txtVerwoording);
            this.Controls.Add(this.lblVerwoording);
            this.Name = "PredicaatManagementFrm";
            this.Text = "PredicaatManagementFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVerwoording;
        private System.Windows.Forms.TextBox txtVerwoording;
        private System.Windows.Forms.Label lblAttributes;
        private System.Windows.Forms.ListBox lbAttributes;
        private System.Windows.Forms.Label lblPredicaat;
        private System.Windows.Forms.TextBox txtPredicaat;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}