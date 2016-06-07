namespace FO_ERM_ISE.presentation.relationtype
{
    partial class RelationTypeForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtRelationTypeName = new System.Windows.Forms.TextBox();
            this.lblEtNameOne = new System.Windows.Forms.Label();
            this.cbEntityTypeOne = new System.Windows.Forms.ComboBox();
            this.cbEntityTypeTwo = new System.Windows.Forms.ComboBox();
            this.lblEtTwo = new System.Windows.Forms.Label();
            this.rbETAfhankelijkOne = new System.Windows.Forms.RadioButton();
            this.rbETAfhankelijkTwo = new System.Windows.Forms.RadioButton();
            this.cbCardinalityOne = new System.Windows.Forms.ComboBox();
            this.lblCardinalityOne = new System.Windows.Forms.Label();
            this.lblCardinalityTwo = new System.Windows.Forms.Label();
            this.cbCardinalityTwo = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Naam:";
            // 
            // txtRelationTypeName
            // 
            this.txtRelationTypeName.Location = new System.Drawing.Point(15, 47);
            this.txtRelationTypeName.Name = "txtRelationTypeName";
            this.txtRelationTypeName.Size = new System.Drawing.Size(358, 20);
            this.txtRelationTypeName.TabIndex = 1;
            // 
            // lblEtNameOne
            // 
            this.lblEtNameOne.AutoSize = true;
            this.lblEtNameOne.Location = new System.Drawing.Point(12, 84);
            this.lblEtNameOne.Name = "lblEtNameOne";
            this.lblEtNameOne.Size = new System.Drawing.Size(68, 13);
            this.lblEtNameOne.TabIndex = 2;
            this.lblEtNameOne.Text = "Entiteittype 1";
            // 
            // cbEntityTypeOne
            // 
            this.cbEntityTypeOne.FormattingEnabled = true;
            this.cbEntityTypeOne.Location = new System.Drawing.Point(15, 100);
            this.cbEntityTypeOne.Name = "cbEntityTypeOne";
            this.cbEntityTypeOne.Size = new System.Drawing.Size(172, 21);
            this.cbEntityTypeOne.TabIndex = 3;
            // 
            // cbEntityTypeTwo
            // 
            this.cbEntityTypeTwo.FormattingEnabled = true;
            this.cbEntityTypeTwo.Location = new System.Drawing.Point(201, 100);
            this.cbEntityTypeTwo.Name = "cbEntityTypeTwo";
            this.cbEntityTypeTwo.Size = new System.Drawing.Size(172, 21);
            this.cbEntityTypeTwo.TabIndex = 5;
            // 
            // lblEtTwo
            // 
            this.lblEtTwo.AutoSize = true;
            this.lblEtTwo.Location = new System.Drawing.Point(198, 84);
            this.lblEtTwo.Name = "lblEtTwo";
            this.lblEtTwo.Size = new System.Drawing.Size(68, 13);
            this.lblEtTwo.TabIndex = 4;
            this.lblEtTwo.Text = "Entiteittype 2";
            // 
            // rbETAfhankelijkOne
            // 
            this.rbETAfhankelijkOne.AutoSize = true;
            this.rbETAfhankelijkOne.Location = new System.Drawing.Point(15, 284);
            this.rbETAfhankelijkOne.Name = "rbETAfhankelijkOne";
            this.rbETAfhankelijkOne.Size = new System.Drawing.Size(77, 17);
            this.rbETAfhankelijkOne.TabIndex = 8;
            this.rbETAfhankelijkOne.TabStop = true;
            this.rbETAfhankelijkOne.Text = "Afhankelijk";
            this.rbETAfhankelijkOne.UseVisualStyleBackColor = true;
            // 
            // rbETAfhankelijkTwo
            // 
            this.rbETAfhankelijkTwo.AutoSize = true;
            this.rbETAfhankelijkTwo.Location = new System.Drawing.Point(201, 284);
            this.rbETAfhankelijkTwo.Name = "rbETAfhankelijkTwo";
            this.rbETAfhankelijkTwo.Size = new System.Drawing.Size(77, 17);
            this.rbETAfhankelijkTwo.TabIndex = 9;
            this.rbETAfhankelijkTwo.TabStop = true;
            this.rbETAfhankelijkTwo.Text = "Afhankelijk";
            this.rbETAfhankelijkTwo.UseVisualStyleBackColor = true;
            // 
            // cbCardinalityOne
            // 
            this.cbCardinalityOne.FormattingEnabled = true;
            this.cbCardinalityOne.Items.AddRange(new object[] {
            "1,1",
            "1,n",
            "0,1",
            "0,n"});
            this.cbCardinalityOne.Location = new System.Drawing.Point(15, 351);
            this.cbCardinalityOne.Name = "cbCardinalityOne";
            this.cbCardinalityOne.Size = new System.Drawing.Size(172, 21);
            this.cbCardinalityOne.TabIndex = 10;
            // 
            // lblCardinalityOne
            // 
            this.lblCardinalityOne.AutoSize = true;
            this.lblCardinalityOne.Location = new System.Drawing.Point(15, 335);
            this.lblCardinalityOne.Name = "lblCardinalityOne";
            this.lblCardinalityOne.Size = new System.Drawing.Size(61, 13);
            this.lblCardinalityOne.TabIndex = 11;
            this.lblCardinalityOne.Text = "Kardinaliteit";
            // 
            // lblCardinalityTwo
            // 
            this.lblCardinalityTwo.AutoSize = true;
            this.lblCardinalityTwo.Location = new System.Drawing.Point(201, 335);
            this.lblCardinalityTwo.Name = "lblCardinalityTwo";
            this.lblCardinalityTwo.Size = new System.Drawing.Size(61, 13);
            this.lblCardinalityTwo.TabIndex = 13;
            this.lblCardinalityTwo.Text = "Kardinaliteit";
            // 
            // cbCardinalityTwo
            // 
            this.cbCardinalityTwo.FormattingEnabled = true;
            this.cbCardinalityTwo.Items.AddRange(new object[] {
            "1,1",
            "1,n",
            "0,1",
            "0,n"});
            this.cbCardinalityTwo.Location = new System.Drawing.Point(201, 351);
            this.cbCardinalityTwo.Name = "cbCardinalityTwo";
            this.cbCardinalityTwo.Size = new System.Drawing.Size(172, 21);
            this.cbCardinalityTwo.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(187, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(284, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // RelationTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 427);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCardinalityTwo);
            this.Controls.Add(this.cbCardinalityTwo);
            this.Controls.Add(this.lblCardinalityOne);
            this.Controls.Add(this.cbCardinalityOne);
            this.Controls.Add(this.rbETAfhankelijkTwo);
            this.Controls.Add(this.rbETAfhankelijkOne);
            this.Controls.Add(this.cbEntityTypeTwo);
            this.Controls.Add(this.lblEtTwo);
            this.Controls.Add(this.cbEntityTypeOne);
            this.Controls.Add(this.lblEtNameOne);
            this.Controls.Add(this.txtRelationTypeName);
            this.Controls.Add(this.lblName);
            this.Name = "RelationTypeForm";
            this.Text = "RelationTypeForm";
            this.Load += new System.EventHandler(this.RelationTypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtRelationTypeName;
        private System.Windows.Forms.Label lblEtNameOne;
        private System.Windows.Forms.ComboBox cbEntityTypeOne;
        private System.Windows.Forms.ComboBox cbEntityTypeTwo;
        private System.Windows.Forms.Label lblEtTwo;
        private System.Windows.Forms.RadioButton rbETAfhankelijkOne;
        private System.Windows.Forms.RadioButton rbETAfhankelijkTwo;
        private System.Windows.Forms.ComboBox cbCardinalityOne;
        private System.Windows.Forms.Label lblCardinalityOne;
        private System.Windows.Forms.Label lblCardinalityTwo;
        private System.Windows.Forms.ComboBox cbCardinalityTwo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}