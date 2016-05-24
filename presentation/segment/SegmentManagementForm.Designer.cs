namespace FO_ERM_ISE.presentation.segment
{
    partial class SegmentManagementForm
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
            this.lbSegment1 = new System.Windows.Forms.ListBox();
            this.lbSegment2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVerwoording = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioSegment2 = new System.Windows.Forms.RadioButton();
            this.radioSegment1 = new System.Windows.Forms.RadioButton();
            this.btnToevoegen = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAnalyseren = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verwoording";
            // 
            // lbSegment1
            // 
            this.lbSegment1.FormattingEnabled = true;
            this.lbSegment1.Location = new System.Drawing.Point(15, 132);
            this.lbSegment1.Name = "lbSegment1";
            this.lbSegment1.Size = new System.Drawing.Size(178, 160);
            this.lbSegment1.TabIndex = 1;
            // 
            // lbSegment2
            // 
            this.lbSegment2.FormattingEnabled = true;
            this.lbSegment2.Location = new System.Drawing.Point(224, 132);
            this.lbSegment2.Name = "lbSegment2";
            this.lbSegment2.Size = new System.Drawing.Size(182, 160);
            this.lbSegment2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Delen van segment 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Delen van segment 3:";
            // 
            // txtVerwoording
            // 
            this.txtVerwoording.HideSelection = false;
            this.txtVerwoording.Location = new System.Drawing.Point(12, 29);
            this.txtVerwoording.Multiline = true;
            this.txtVerwoording.Name = "txtVerwoording";
            this.txtVerwoording.ReadOnly = true;
            this.txtVerwoording.Size = new System.Drawing.Size(284, 73);
            this.txtVerwoording.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioSegment2);
            this.groupBox1.Controls.Add(this.radioSegment1);
            this.groupBox1.Location = new System.Drawing.Point(303, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(103, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Segment";
            // 
            // radioSegment2
            // 
            this.radioSegment2.AutoSize = true;
            this.radioSegment2.Location = new System.Drawing.Point(55, 25);
            this.radioSegment2.Name = "radioSegment2";
            this.radioSegment2.Size = new System.Drawing.Size(31, 17);
            this.radioSegment2.TabIndex = 1;
            this.radioSegment2.Text = "2";
            this.radioSegment2.UseVisualStyleBackColor = true;
            // 
            // radioSegment1
            // 
            this.radioSegment1.AutoSize = true;
            this.radioSegment1.Checked = true;
            this.radioSegment1.Location = new System.Drawing.Point(7, 25);
            this.radioSegment1.Name = "radioSegment1";
            this.radioSegment1.Size = new System.Drawing.Size(31, 17);
            this.radioSegment1.TabIndex = 0;
            this.radioSegment1.TabStop = true;
            this.radioSegment1.Text = "1";
            this.radioSegment1.UseVisualStyleBackColor = true;
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.Location = new System.Drawing.Point(303, 71);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(103, 32);
            this.btnToevoegen.TabIndex = 7;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.UseVisualStyleBackColor = true;
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(15, 304);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Verwijderen";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAnalyseren
            // 
            this.btnAnalyseren.Location = new System.Drawing.Point(96, 304);
            this.btnAnalyseren.Name = "btnAnalyseren";
            this.btnAnalyseren.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyseren.TabIndex = 9;
            this.btnAnalyseren.Text = "Analyseren";
            this.btnAnalyseren.UseVisualStyleBackColor = true;
            // 
            // SegmentManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 339);
            this.Controls.Add(this.btnAnalyseren);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnToevoegen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtVerwoording);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbSegment2);
            this.Controls.Add(this.lbSegment1);
            this.Controls.Add(this.label1);
            this.Name = "SegmentManagementForm";
            this.Text = "SegmentManagementForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbSegment1;
        private System.Windows.Forms.ListBox lbSegment2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVerwoording;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioSegment2;
        private System.Windows.Forms.RadioButton radioSegment1;
        private System.Windows.Forms.Button btnToevoegen;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAnalyseren;
    }
}