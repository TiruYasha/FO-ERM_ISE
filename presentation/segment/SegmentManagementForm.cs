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
using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.dependencyManager;

namespace FO_ERM_ISE.presentation.segment
{
    public partial class SegmentManagementForm : Form
    {
        private FacttypeDTO factType; 

        private SegmentDTO segmentOne;
        private SegmentDTO segmentTwo;

        private ISegmentBusiness sb;

        public SegmentManagementForm(FacttypeDTO facttype)
        {
            InitializeComponent();
            DependencyManager dp = new DependencyManager();
            this.sb = dp.GetISegmentBusiness();

            this.factType = facttype;
            txtVerwoording.Text = this.factType.verwoording;

            updateListboxes();
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

                if(!IsUniqueSegmentDeel(selectedTekst))
                {
                    MessageBox.Show("Eenzelfde segmentdeel wordt al gebuikt.\nEen segmentdeel mag maar een keer voorkomen.");
                    return;
                }
                
                if (radioSegment1.Checked)
                {
                    this.segmentOne.addSegmentDeel(selectedTekst);
                    sb.AddSegment(segmentOne);
                }
                else
                {
                    this.segmentTwo.addSegmentDeel(selectedTekst);
                    sb.AddSegment(segmentTwo);
                }

                updateListboxes();
            }
        }       

        private Boolean IsUniqueSegmentDeel(string selectedTekst)
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

        private void updateListboxes()
        {
            this.resetListboxes();
            this.getSegmenten();            

            if (segmentOne != null && segmentOne.SegmentDeel != null)
                lbSegment1.DataSource = segmentOne.SegmentDeel;
            if (segmentTwo != null && segmentTwo != null)
                lbSegment2.DataSource = segmentTwo.SegmentDeel;

            lbSegment1.DisplayMember = "segmentDeelTekst";
            lbSegment2.DisplayMember = "segmentDeelTekst";
        }

        private void getSegmenten()
        {
            this.segmentOne = this.getSegmentDeel(1);
            this.segmentTwo = this.getSegmentDeel(2);

            if(this.segmentOne == null)
            {
                this.segmentOne = new SegmentDTO();
                this.segmentOne.setFactType(this.factType);
                this.segmentOne.segmentNummer = 1;
            }

            if (this.segmentTwo == null)
            {
                this.segmentTwo = new SegmentDTO();
                this.segmentTwo.setFactType(this.factType);
                this.segmentTwo.segmentNummer = 2;
            }
        }

        private void resetListboxes()
        {
            lbSegment1.DataSource = null;
            lbSegment2.DataSource = null;
        }

        public SegmentDTO getSegmentDeel(int segmentNummer)
        {
            return this.sb.getSegmentOnSegmentNummer(segmentNummer, this.factType.dataModelNummer, this.factType.feitTypeCode);
        }

        private void lbSegment1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSegment1.SelectedItem != null)
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

        //Not yet implemented!
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //lbSegment1.Items.Remove(lbSegment1.SelectedItem);
            //lbSegment2.Items.Remove(lbSegment2.SelectedItem);
        }       

        //Not yet implemented!
        private void btnAnalyseSegment1_Click(object sender, EventArgs e)
        {
            StartAnalysation(1);
        }
        //Not yet implemented!
        private void btnAnalyseSegment2_Click(object sender, EventArgs e)
        {
            StartAnalysation(2);
        }
        //Not yet implemented!
        private void StartAnalysation(int segmentNumber)
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
    }
}
