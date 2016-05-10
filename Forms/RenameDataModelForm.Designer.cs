namespace FO_ERM_ISE.Forms
{
    partial class RenameDataModelForm
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
            this.txtDataModelName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRenameDataModel = new System.Windows.Forms.Button();
            this.lblDataModelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDataModelName
            // 
            this.txtDataModelName.Location = new System.Drawing.Point(146, 12);
            this.txtDataModelName.Name = "txtDataModelName";
            this.txtDataModelName.Size = new System.Drawing.Size(193, 20);
            this.txtDataModelName.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(264, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRenameDataModel
            // 
            this.btnRenameDataModel.Location = new System.Drawing.Point(146, 38);
            this.btnRenameDataModel.Name = "btnRenameDataModel";
            this.btnRenameDataModel.Size = new System.Drawing.Size(75, 23);
            this.btnRenameDataModel.TabIndex = 5;
            this.btnRenameDataModel.Text = "Hernoem";
            this.btnRenameDataModel.UseVisualStyleBackColor = true;
            // 
            // lblDataModelName
            // 
            this.lblDataModelName.AutoSize = true;
            this.lblDataModelName.Location = new System.Drawing.Point(13, 15);
            this.lblDataModelName.Name = "lblDataModelName";
            this.lblDataModelName.Size = new System.Drawing.Size(127, 13);
            this.lblDataModelName.TabIndex = 4;
            this.lblDataModelName.Text = "Nieuwe datamodel naam:";
            // 
            // RenameDataModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 77);
            this.Controls.Add(this.txtDataModelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRenameDataModel);
            this.Controls.Add(this.lblDataModelName);
            this.Name = "RenameDataModelForm";
            this.Text = "Hernoem datamodel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDataModelName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRenameDataModel;
        private System.Windows.Forms.Label lblDataModelName;
    }
}