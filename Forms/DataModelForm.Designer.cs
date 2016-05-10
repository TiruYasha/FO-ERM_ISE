namespace FO_ERM_ISE.Forms
{
    partial class DataModelForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddDataModel = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnDeleteDataModel = new System.Windows.Forms.Button();
            this.btnRenameDataModel = new System.Windows.Forms.Button();
            this.btnFactTypeManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datamodellen:";
            // 
            // btnAddDataModel
            // 
            this.btnAddDataModel.Location = new System.Drawing.Point(248, 19);
            this.btnAddDataModel.Name = "btnAddDataModel";
            this.btnAddDataModel.Size = new System.Drawing.Size(137, 23);
            this.btnAddDataModel.TabIndex = 1;
            this.btnAddDataModel.Text = "Datamodel toevoegen";
            this.btnAddDataModel.UseVisualStyleBackColor = true;
            this.btnAddDataModel.Click += new System.EventHandler(this.btnAddDataModel_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(41, 57);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(344, 502);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnDeleteDataModel
            // 
            this.btnDeleteDataModel.Enabled = false;
            this.btnDeleteDataModel.Location = new System.Drawing.Point(38, 576);
            this.btnDeleteDataModel.Name = "btnDeleteDataModel";
            this.btnDeleteDataModel.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDataModel.TabIndex = 3;
            this.btnDeleteDataModel.Text = "Verwijderen";
            this.btnDeleteDataModel.UseVisualStyleBackColor = true;
            // 
            // btnRenameDataModel
            // 
            this.btnRenameDataModel.Enabled = false;
            this.btnRenameDataModel.Location = new System.Drawing.Point(172, 576);
            this.btnRenameDataModel.Name = "btnRenameDataModel";
            this.btnRenameDataModel.Size = new System.Drawing.Size(75, 23);
            this.btnRenameDataModel.TabIndex = 4;
            this.btnRenameDataModel.Text = "Hernoemen";
            this.btnRenameDataModel.UseVisualStyleBackColor = true;
            // 
            // btnFactTypeManagement
            // 
            this.btnFactTypeManagement.Enabled = false;
            this.btnFactTypeManagement.Location = new System.Drawing.Point(308, 575);
            this.btnFactTypeManagement.Name = "btnFactTypeManagement";
            this.btnFactTypeManagement.Size = new System.Drawing.Size(75, 23);
            this.btnFactTypeManagement.TabIndex = 5;
            this.btnFactTypeManagement.Text = "Verder";
            this.btnFactTypeManagement.UseVisualStyleBackColor = true;
            // 
            // DataModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 621);
            this.Controls.Add(this.btnFactTypeManagement);
            this.Controls.Add(this.btnRenameDataModel);
            this.Controls.Add(this.btnDeleteDataModel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnAddDataModel);
            this.Controls.Add(this.label1);
            this.Name = "DataModelForm";
            this.Text = "FO-ERM Analyse - Datamodellen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddDataModel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnDeleteDataModel;
        private System.Windows.Forms.Button btnRenameDataModel;
        private System.Windows.Forms.Button btnFactTypeManagement;
    }
}

