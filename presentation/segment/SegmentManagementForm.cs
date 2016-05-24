using System;
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

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            string selectedTekst = txtVerwoording.SelectedText;

            if (!String.IsNullOrWhiteSpace(selectedTekst))
            {

                //check if selected text is not in listbox.
                ListBox lb = new ListBox();
                lb.Items.AddRange(lbSegment1.Items);
                lb.Items.AddRange(lbSegment2.Items);

                foreach (var item in lb.Items)
                {
                    if (item.Equals(selectedTekst)) return;
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

    }
}
