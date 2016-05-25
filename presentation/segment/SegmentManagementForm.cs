﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.presentation.segment
{
    public partial class SegmentManagementForm : Form
    {

        public SegmentManagementForm(FacttypeDTO facttype)
        {
            InitializeComponent();
            txtVerwoording.Text = facttype.verwoording;
        }

        /// <summary>
        /// Voeg een segmentdeel toe aan het geselecteerde segment.
        /// Controleer ook of dit uniek is binnen de segmentdelen die al geselecteerd zijn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            string selectedTekst = txtVerwoording.SelectedText;

            if (!String.IsNullOrWhiteSpace(selectedTekst))
            {

                if(!isUniqeSegmentDeel(selectedTekst))
                {
                    MessageBox.Show("Eenzelfde segmentdeel wordt al gebuikt.\nEen segmentdeel mag maar een keer voorkomen.");
                    return;
                }
                
                if (radioSegment1.Checked)
                {
                    lbSegment1.Items.Add(selectedTekst);
                }
                else
                {
                    lbSegment2.Items.Add(selectedTekst);
                }

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lbSegment1.Items.Remove(lbSegment1.SelectedItem);
            lbSegment2.Items.Remove(lbSegment2.SelectedItem);
        }

        private void lbSegment1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbSegment1.SelectedItem != null)
            {
                lbSegment2.ClearSelected();
            }
        }

        private void lbSegment2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSegment2.SelectedItem != null)
            {
                lbSegment1.ClearSelected();
            }
        }

        private void btnAnalyseSegment1_Click(object sender, EventArgs e)
        {
            startAnalysation(1);
        }

        private void btnAnalyseSegment2_Click(object sender, EventArgs e)
        {
            startAnalysation(2);
        }

        private void startAnalysation(int segmentNumber)
        {
            throw new NotImplementedException();

            //var segmentAnalyseForm = new Form(); // SegmentAnalyseForm();

            //segmentAnalyseForm.Show();
            //this.Hide();

            //segmentAnalyseForm.FormClosing += delegate
            //{
            //    this.Show();
            //};
        }

        private Boolean isUniqeSegmentDeel(string selectedTekst)
        {
            
            //check if selected text is not in listbox.
            ListBox lb = new ListBox();
            lb.Items.AddRange(lbSegment1.Items);
            lb.Items.AddRange(lbSegment2.Items);

            foreach (var item in lb.Items)
            {
                if (item.Equals(selectedTekst))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
