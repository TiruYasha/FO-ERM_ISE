namespace FO_ERM_ISE.presentation.facttype
{
    partial class FacttypeManagementForm
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
            this.lblFacttypes = new System.Windows.Forms.Label();
            this.btnAddFactType = new System.Windows.Forms.Button();
            this.btnDeleteFactType = new System.Windows.Forms.Button();
            this.btnUpdateFactType = new System.Windows.Forms.Button();
            this.btnSegmentManagement = new System.Windows.Forms.Button();
            this.lvFacttypes = new System.Windows.Forms.ListView();
            this.columnHeaderFactCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVerbalization = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVerified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVerifyFactType = new System.Windows.Forms.Button();
            this.btnPredicateManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFacttypes
            // 
            this.lblFacttypes.AutoSize = true;
            this.lblFacttypes.Location = new System.Drawing.Point(12, 9);
            this.lblFacttypes.Name = "lblFacttypes";
            this.lblFacttypes.Size = new System.Drawing.Size(53, 13);
            this.lblFacttypes.TabIndex = 0;
            this.lblFacttypes.Text = "Feittypen:";
            // 
            // btnAddFactType
            // 
            this.btnAddFactType.Location = new System.Drawing.Point(839, 8);
            this.btnAddFactType.Name = "btnAddFactType";
            this.btnAddFactType.Size = new System.Drawing.Size(121, 23);
            this.btnAddFactType.TabIndex = 1;
            this.btnAddFactType.Text = "Feittype toevoegen";
            this.btnAddFactType.UseVisualStyleBackColor = true;
            this.btnAddFactType.Click += new System.EventHandler(this.btnAddFactType_Click);
            // 
            // btnDeleteFactType
            // 
            this.btnDeleteFactType.Enabled = false;
            this.btnDeleteFactType.Location = new System.Drawing.Point(12, 443);
            this.btnDeleteFactType.Name = "btnDeleteFactType";
            this.btnDeleteFactType.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFactType.TabIndex = 2;
            this.btnDeleteFactType.Text = "Verwijderen";
            this.btnDeleteFactType.UseVisualStyleBackColor = true;
            this.btnDeleteFactType.Click += new System.EventHandler(this.btnDeleteFactType_Click);
            // 
            // btnUpdateFactType
            // 
            this.btnUpdateFactType.Enabled = false;
            this.btnUpdateFactType.Location = new System.Drawing.Point(93, 443);
            this.btnUpdateFactType.Name = "btnUpdateFactType";
            this.btnUpdateFactType.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateFactType.TabIndex = 3;
            this.btnUpdateFactType.Text = "Aanpassen";
            this.btnUpdateFactType.UseVisualStyleBackColor = true;
            this.btnUpdateFactType.Click += new System.EventHandler(this.btnUpdateFactType_Click);
            // 
            // btnSegmentManagement
            // 
            this.btnSegmentManagement.Enabled = false;
            this.btnSegmentManagement.Location = new System.Drawing.Point(885, 443);
            this.btnSegmentManagement.Name = "btnSegmentManagement";
            this.btnSegmentManagement.Size = new System.Drawing.Size(75, 23);
            this.btnSegmentManagement.TabIndex = 4;
            this.btnSegmentManagement.Text = "Verder";
            this.btnSegmentManagement.UseVisualStyleBackColor = true;
            this.btnSegmentManagement.Click += new System.EventHandler(this.btnSegmentManagement_Click);
            // 
            // lvFacttypes
            // 
            this.lvFacttypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFactCode,
            this.columnHeaderVerbalization,
            this.columnHeaderVerified});
            this.lvFacttypes.FullRowSelect = true;
            this.lvFacttypes.GridLines = true;
            this.lvFacttypes.Location = new System.Drawing.Point(15, 37);
            this.lvFacttypes.MultiSelect = false;
            this.lvFacttypes.Name = "lvFacttypes";
            this.lvFacttypes.Size = new System.Drawing.Size(945, 400);
            this.lvFacttypes.TabIndex = 5;
            this.lvFacttypes.UseCompatibleStateImageBehavior = false;
            this.lvFacttypes.View = System.Windows.Forms.View.Details;
            this.lvFacttypes.SelectedIndexChanged += new System.EventHandler(this.lvFacttypes_SelectedIndexChanged);
            // 
            // columnHeaderFactCode
            // 
            this.columnHeaderFactCode.Text = "Feitcode";
            // 
            // columnHeaderVerbalization
            // 
            this.columnHeaderVerbalization.Text = "Verwoording";
            this.columnHeaderVerbalization.Width = 800;
            // 
            // columnHeaderVerified
            // 
            this.columnHeaderVerified.Text = "Geverifieerd";
            this.columnHeaderVerified.Width = 120;
            // 
            // btnVerifyFactType
            // 
            this.btnVerifyFactType.Location = new System.Drawing.Point(174, 443);
            this.btnVerifyFactType.Name = "btnVerifyFactType";
            this.btnVerifyFactType.Size = new System.Drawing.Size(87, 23);
            this.btnVerifyFactType.TabIndex = 6;
            this.btnVerifyFactType.Text = "Verifiëren";
            this.btnVerifyFactType.UseVisualStyleBackColor = true;
            this.btnVerifyFactType.Click += new System.EventHandler(this.btnVerifyFactType_Click);
            // 
            // btnPredicateManagement
            // 
            this.btnPredicateManagement.Location = new System.Drawing.Point(268, 442);
            this.btnPredicateManagement.Name = "btnPredicateManagement";
            this.btnPredicateManagement.Size = new System.Drawing.Size(75, 23);
            this.btnPredicateManagement.TabIndex = 7;
            this.btnPredicateManagement.Text = "Predicaat beheren";
            this.btnPredicateManagement.UseVisualStyleBackColor = true;
            this.btnPredicateManagement.Click += new System.EventHandler(this.btnPredicateManagement_Click);
            // 
            // FacttypeManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 478);
            this.Controls.Add(this.btnPredicateManagement);
            this.Controls.Add(this.btnVerifyFactType);
            this.Controls.Add(this.lvFacttypes);
            this.Controls.Add(this.btnSegmentManagement);
            this.Controls.Add(this.btnUpdateFactType);
            this.Controls.Add(this.btnDeleteFactType);
            this.Controls.Add(this.btnAddFactType);
            this.Controls.Add(this.lblFacttypes);
            this.Name = "FacttypeManagementForm";
            this.Text = "FacttypeManagementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFacttypes;
        private System.Windows.Forms.Button btnAddFactType;
        private System.Windows.Forms.Button btnDeleteFactType;
        private System.Windows.Forms.Button btnUpdateFactType;
        private System.Windows.Forms.Button btnSegmentManagement;
        private System.Windows.Forms.ListView lvFacttypes;
        private System.Windows.Forms.ColumnHeader columnHeaderFactCode;
        private System.Windows.Forms.ColumnHeader columnHeaderVerbalization;
        private System.Windows.Forms.ColumnHeader columnHeaderVerified;
        private System.Windows.Forms.Button btnVerifyFactType;
        private System.Windows.Forms.Button btnPredicateManagement;
    }
}