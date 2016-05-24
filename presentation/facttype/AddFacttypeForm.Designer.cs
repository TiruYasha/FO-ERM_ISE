namespace FO_ERM_ISE.presentation.facttype
{
    partial class AddFacttypeForm
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
            this.lblFacttype = new System.Windows.Forms.Label();
            this.txtFactCode = new System.Windows.Forms.TextBox();
            this.lblVerbalization = new System.Windows.Forms.Label();
            this.txtVerbalization = new System.Windows.Forms.TextBox();
            this.btnAddFacttype = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFacttype
            // 
            this.lblFacttype.AutoSize = true;
            this.lblFacttype.Location = new System.Drawing.Point(12, 9);
            this.lblFacttype.Name = "lblFacttype";
            this.lblFacttype.Size = new System.Drawing.Size(54, 13);
            this.lblFacttype.TabIndex = 0;
            this.lblFacttype.Text = "Feitcode: ";
            // 
            // txtFactCode
            // 
            this.txtFactCode.Location = new System.Drawing.Point(72, 6);
            this.txtFactCode.Name = "txtFactCode";
            this.txtFactCode.Size = new System.Drawing.Size(232, 20);
            this.txtFactCode.TabIndex = 1;
            // 
            // lblVerbalization
            // 
            this.lblVerbalization.AutoSize = true;
            this.lblVerbalization.Location = new System.Drawing.Point(12, 44);
            this.lblVerbalization.Name = "lblVerbalization";
            this.lblVerbalization.Size = new System.Drawing.Size(69, 13);
            this.lblVerbalization.TabIndex = 2;
            this.lblVerbalization.Text = "Verwoording:";
            // 
            // txtVerbalization
            // 
            this.txtVerbalization.Location = new System.Drawing.Point(15, 60);
            this.txtVerbalization.Multiline = true;
            this.txtVerbalization.Name = "txtVerbalization";
            this.txtVerbalization.Size = new System.Drawing.Size(289, 139);
            this.txtVerbalization.TabIndex = 3;
            // 
            // btnAddFacttype
            // 
            this.btnAddFacttype.Location = new System.Drawing.Point(143, 206);
            this.btnAddFacttype.Name = "btnAddFacttype";
            this.btnAddFacttype.Size = new System.Drawing.Size(75, 23);
            this.btnAddFacttype.TabIndex = 4;
            this.btnAddFacttype.Text = "Toevoegen";
            this.btnAddFacttype.UseVisualStyleBackColor = true;
            this.btnAddFacttype.Click += new System.EventHandler(this.btnAddFacttype_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddFacttypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 241);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddFacttype);
            this.Controls.Add(this.txtVerbalization);
            this.Controls.Add(this.lblVerbalization);
            this.Controls.Add(this.txtFactCode);
            this.Controls.Add(this.lblFacttype);
            this.Name = "AddFacttypeForm";
            this.Text = "AddFacttypeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFacttype;
        private System.Windows.Forms.TextBox txtFactCode;
        private System.Windows.Forms.Label lblVerbalization;
        private System.Windows.Forms.TextBox txtVerbalization;
        private System.Windows.Forms.Button btnAddFacttype;
        private System.Windows.Forms.Button btnCancel;
    }
}