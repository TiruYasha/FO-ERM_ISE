namespace FO_ERM_ISE.presentation.analyse
{
    partial class AnalyseSegmentForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEntiteittype = new System.Windows.Forms.TabPage();
            this.btnDeleteAttr = new System.Windows.Forms.Button();
            this.btnSaveET = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddRelationType = new System.Windows.Forms.Button();
            this.btnAddAttribute = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbIDAttr = new System.Windows.Forms.ListBox();
            this.lbDependentETs = new System.Windows.Forms.ListBox();
            this.txtIdentificatoren = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtETNaam = new System.Windows.Forms.TextBox();
            this.selectEntitytype = new System.Windows.Forms.ComboBox();
            this.chMatch = new System.Windows.Forms.CheckBox();
            this.tabAttribuut = new System.Windows.Forms.TabPage();
            this.btnSaveAttr = new System.Windows.Forms.Button();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chMandatory = new System.Windows.Forms.CheckBox();
            this.txtAttrName = new System.Windows.Forms.TextBox();
            this.txtSegment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabEntiteittype.SuspendLayout();
            this.tabAttribuut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEntiteittype);
            this.tabControl1.Controls.Add(this.tabAttribuut);
            this.tabControl1.Location = new System.Drawing.Point(12, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 405);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEntiteittype
            // 
            this.tabEntiteittype.Controls.Add(this.btnDeleteAttr);
            this.tabEntiteittype.Controls.Add(this.btnSaveET);
            this.tabEntiteittype.Controls.Add(this.btnCancel);
            this.tabEntiteittype.Controls.Add(this.btnAddRelationType);
            this.tabEntiteittype.Controls.Add(this.btnAddAttribute);
            this.tabEntiteittype.Controls.Add(this.label5);
            this.tabEntiteittype.Controls.Add(this.label4);
            this.tabEntiteittype.Controls.Add(this.lbIDAttr);
            this.tabEntiteittype.Controls.Add(this.lbDependentETs);
            this.tabEntiteittype.Controls.Add(this.txtIdentificatoren);
            this.tabEntiteittype.Controls.Add(this.label3);
            this.tabEntiteittype.Controls.Add(this.label2);
            this.tabEntiteittype.Controls.Add(this.txtETNaam);
            this.tabEntiteittype.Controls.Add(this.selectEntitytype);
            this.tabEntiteittype.Controls.Add(this.chMatch);
            this.tabEntiteittype.Location = new System.Drawing.Point(4, 22);
            this.tabEntiteittype.Name = "tabEntiteittype";
            this.tabEntiteittype.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntiteittype.Size = new System.Drawing.Size(442, 379);
            this.tabEntiteittype.TabIndex = 0;
            this.tabEntiteittype.Text = "Entiteittype";
            this.tabEntiteittype.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAttr
            // 
            this.btnDeleteAttr.Location = new System.Drawing.Point(238, 313);
            this.btnDeleteAttr.Name = "btnDeleteAttr";
            this.btnDeleteAttr.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAttr.TabIndex = 14;
            this.btnDeleteAttr.Text = "Verwijder";
            this.btnDeleteAttr.UseVisualStyleBackColor = true;
            this.btnDeleteAttr.Click += new System.EventHandler(this.btnDeleteAttr_Click);
            // 
            // btnSaveET
            // 
            this.btnSaveET.Location = new System.Drawing.Point(301, 347);
            this.btnSaveET.Name = "btnSaveET";
            this.btnSaveET.Size = new System.Drawing.Size(93, 23);
            this.btnSaveET.TabIndex = 13;
            this.btnSaveET.Text = "Opslaan";
            this.btnSaveET.UseVisualStyleBackColor = true;
            this.btnSaveET.Click += new System.EventHandler(this.btnSaveET_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(209, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddRelationType
            // 
            this.btnAddRelationType.Location = new System.Drawing.Point(23, 347);
            this.btnAddRelationType.Name = "btnAddRelationType";
            this.btnAddRelationType.Size = new System.Drawing.Size(143, 23);
            this.btnAddRelationType.TabIndex = 11;
            this.btnAddRelationType.Text = "Relatietype toevoegen";
            this.btnAddRelationType.UseVisualStyleBackColor = true;
            this.btnAddRelationType.Click += new System.EventHandler(this.btnAddRelationType_Click);
            // 
            // btnAddAttribute
            // 
            this.btnAddAttribute.Location = new System.Drawing.Point(319, 313);
            this.btnAddAttribute.Name = "btnAddAttribute";
            this.btnAddAttribute.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttribute.TabIndex = 10;
            this.btnAddAttribute.Text = "Toevoegen";
            this.btnAddAttribute.UseVisualStyleBackColor = true;
            this.btnAddAttribute.Click += new System.EventHandler(this.btnAddAttribute_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Identificerende attribuuten:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Entiteittypen:";
            // 
            // lbIDAttr
            // 
            this.lbIDAttr.FormattingEnabled = true;
            this.lbIDAttr.Location = new System.Drawing.Point(203, 212);
            this.lbIDAttr.Name = "lbIDAttr";
            this.lbIDAttr.Size = new System.Drawing.Size(191, 95);
            this.lbIDAttr.TabIndex = 7;
            // 
            // lbDependentETs
            // 
            this.lbDependentETs.FormattingEnabled = true;
            this.lbDependentETs.Location = new System.Drawing.Point(23, 212);
            this.lbDependentETs.Name = "lbDependentETs";
            this.lbDependentETs.Size = new System.Drawing.Size(143, 134);
            this.lbDependentETs.TabIndex = 6;
            // 
            // txtIdentificatoren
            // 
            this.txtIdentificatoren.Enabled = false;
            this.txtIdentificatoren.Location = new System.Drawing.Point(23, 157);
            this.txtIdentificatoren.Name = "txtIdentificatoren";
            this.txtIdentificatoren.Size = new System.Drawing.Size(371, 20);
            this.txtIdentificatoren.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Identificatoren:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entiteittype naam:";
            // 
            // txtETNaam
            // 
            this.txtETNaam.Location = new System.Drawing.Point(23, 99);
            this.txtETNaam.Name = "txtETNaam";
            this.txtETNaam.Size = new System.Drawing.Size(205, 20);
            this.txtETNaam.TabIndex = 2;
            // 
            // selectEntitytype
            // 
            this.selectEntitytype.Enabled = false;
            this.selectEntitytype.FormattingEnabled = true;
            this.selectEntitytype.Location = new System.Drawing.Point(42, 45);
            this.selectEntitytype.Name = "selectEntitytype";
            this.selectEntitytype.Size = new System.Drawing.Size(242, 21);
            this.selectEntitytype.TabIndex = 1;
            // 
            // chMatch
            // 
            this.chMatch.AutoSize = true;
            this.chMatch.Location = new System.Drawing.Point(23, 22);
            this.chMatch.Name = "chMatch";
            this.chMatch.Size = new System.Drawing.Size(261, 17);
            this.chMatch.TabIndex = 0;
            this.chMatch.Text = "Match (Zo ja, selecteer een eintiteittype uit de lijst)";
            this.chMatch.UseVisualStyleBackColor = true;
            this.chMatch.CheckedChanged += new System.EventHandler(this.chMatch_CheckedChanged);
            // 
            // tabAttribuut
            // 
            this.tabAttribuut.Controls.Add(this.btnSaveAttr);
            this.tabAttribuut.Controls.Add(this.btnCancel2);
            this.tabAttribuut.Controls.Add(this.label6);
            this.tabAttribuut.Controls.Add(this.chMandatory);
            this.tabAttribuut.Controls.Add(this.txtAttrName);
            this.tabAttribuut.Location = new System.Drawing.Point(4, 22);
            this.tabAttribuut.Name = "tabAttribuut";
            this.tabAttribuut.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttribuut.Size = new System.Drawing.Size(442, 379);
            this.tabAttribuut.TabIndex = 1;
            this.tabAttribuut.Text = "Attribuut";
            this.tabAttribuut.UseVisualStyleBackColor = true;
            // 
            // btnSaveAttr
            // 
            this.btnSaveAttr.Location = new System.Drawing.Point(318, 350);
            this.btnSaveAttr.Name = "btnSaveAttr";
            this.btnSaveAttr.Size = new System.Drawing.Size(101, 23);
            this.btnSaveAttr.TabIndex = 14;
            this.btnSaveAttr.Text = "Opslaan";
            this.btnSaveAttr.UseVisualStyleBackColor = true;
            this.btnSaveAttr.Click += new System.EventHandler(this.btnSaveAttr_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(211, 350);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(101, 23);
            this.btnCancel2.TabIndex = 13;
            this.btnCancel2.Text = "Annuleren";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Attribuut naam:";
            // 
            // chMandatory
            // 
            this.chMandatory.AutoSize = true;
            this.chMandatory.Location = new System.Drawing.Point(20, 67);
            this.chMandatory.Name = "chMandatory";
            this.chMandatory.Size = new System.Drawing.Size(76, 17);
            this.chMandatory.TabIndex = 1;
            this.chMandatory.Text = "Mandatory";
            this.chMandatory.UseVisualStyleBackColor = true;
            // 
            // txtAttrName
            // 
            this.txtAttrName.Location = new System.Drawing.Point(20, 41);
            this.txtAttrName.Name = "txtAttrName";
            this.txtAttrName.Size = new System.Drawing.Size(141, 20);
            this.txtAttrName.TabIndex = 0;
            // 
            // txtSegment
            // 
            this.txtSegment.Enabled = false;
            this.txtSegment.Location = new System.Drawing.Point(12, 29);
            this.txtSegment.Name = "txtSegment";
            this.txtSegment.Size = new System.Drawing.Size(446, 20);
            this.txtSegment.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Segment tekst:";
            // 
            // AnalyseSegmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSegment);
            this.Controls.Add(this.tabControl1);
            this.Name = "AnalyseSegmentForm";
            this.Text = "analyseSegmentForm";
            this.tabControl1.ResumeLayout(false);
            this.tabEntiteittype.ResumeLayout(false);
            this.tabEntiteittype.PerformLayout();
            this.tabAttribuut.ResumeLayout(false);
            this.tabAttribuut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEntiteittype;
        private System.Windows.Forms.TabPage tabAttribuut;
        private System.Windows.Forms.TextBox txtSegment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectEntitytype;
        private System.Windows.Forms.CheckBox chMatch;
        private System.Windows.Forms.Button btnSaveET;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddRelationType;
        private System.Windows.Forms.Button btnAddAttribute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbIDAttr;
        private System.Windows.Forms.ListBox lbDependentETs;
        private System.Windows.Forms.TextBox txtIdentificatoren;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtETNaam;
        private System.Windows.Forms.Button btnSaveAttr;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chMandatory;
        private System.Windows.Forms.TextBox txtAttrName;
        private System.Windows.Forms.Button btnDeleteAttr;
    }
}