namespace FO_ERM_ISE.Forms
{
    partial class AddDataModelForm
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
            this.lblDataModelName = new System.Windows.Forms.Label();
            this.btnAddDataModel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDataModelName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDataModelName
            // 
            this.lblDataModelName.AutoSize = true;
            this.lblDataModelName.Location = new System.Drawing.Point(18, 24);
            this.lblDataModelName.Name = "lblDataModelName";
            this.lblDataModelName.Size = new System.Drawing.Size(90, 13);
            this.lblDataModelName.TabIndex = 0;
            this.lblDataModelName.Text = "Datamodel naam:";
            // 
            // btnAddDataModel
            // 
            this.btnAddDataModel.Location = new System.Drawing.Point(114, 47);
            this.btnAddDataModel.Name = "btnAddDataModel";
            this.btnAddDataModel.Size = new System.Drawing.Size(75, 23);
            this.btnAddDataModel.TabIndex = 1;
            this.btnAddDataModel.Text = "Toevoegen";
            this.btnAddDataModel.UseVisualStyleBackColor = true;
            this.btnAddDataModel.Click += new System.EventHandler(this.btnAddDataModel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDataModelName
            // 
            this.txtDataModelName.Location = new System.Drawing.Point(114, 21);
            this.txtDataModelName.Name = "txtDataModelName";
            this.txtDataModelName.Size = new System.Drawing.Size(193, 20);
            this.txtDataModelName.TabIndex = 3;
            // 
            // AddDataModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 86);
            this.Controls.Add(this.txtDataModelName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddDataModel);
            this.Controls.Add(this.lblDataModelName);
            this.Name = "AddDataModelForm";
            this.Text = "Datamodel toevoegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataModelName;
        private System.Windows.Forms.Button btnAddDataModel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDataModelName;
    }
}