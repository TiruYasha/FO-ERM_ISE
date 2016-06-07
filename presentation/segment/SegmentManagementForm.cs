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
using System.Data.Entity.Validation;
using FO_ERM_ISE.presentation.relationtype;
using FO_ERM_ISE.presentation.analyse;

namespace FO_ERM_ISE.presentation.segment
{
    public partial class SegmentManagementForm : Form
    {
        private FacttypeDTO factType; 

        private SegmentDTO segmentOne;
        private SegmentDTO segmentTwo;

        private ISegmentBusiness sb;

        private DatabaseErrorHandler errorHandler;

        public SegmentManagementForm(FacttypeDTO facttype)
        {
            InitializeComponent();
            DependencyManager dp = new DependencyManager();
            this.sb = dp.GetISegmentBusiness();

            this.factType = facttype;
            txtVerwoording.Text = this.factType.verwoording;

            this.errorHandler = new DatabaseErrorHandler();

            updateListboxes();
        }

        #region Event handlers

        /// <summary>
        /// On click handler for btnRemove
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.RemoveSegmentDeelFromSegment(this.getSelectedSegmentDeel());
            this.updateListboxes();
        }

        /// <summary>
        /// When a segment is selected in lbSegment1 then clear any selected item in lbSegment2
        /// 
        /// Door: Marnix Dessing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbSegment1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSegment1.SelectedItem != null)
            {
                lbSegment2.ClearSelected();
            }
        }

        /// <summary>
        /// When a segment is selected in lbSegment2 then clear any selected item in lbSegment1
        /// 
        /// Door: Marnix Dessing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbSegment2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSegment2.SelectedItem != null)
            {
                lbSegment1.ClearSelected();
            }
        }

        /// <summary>
        /// Checks if the selectedTekst is unique
        /// addsTheSegmentDeel(selectedTekst, segmentNummer)
        /// Updates the segment listboxes
        /// 
        /// Door: Marnix Dessing, Harm Roerdink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            string selectedTekst = txtVerwoording.SelectedText;

            if (!String.IsNullOrWhiteSpace(selectedTekst))
            {

                if (!IsUniqueSegmentDeel(selectedTekst))
                {
                    MessageBox.Show("Eenzelfde segmentdeel wordt al gebuikt.\nEen segmentdeel mag maar een keer voorkomen.");
                    return;
                }

                if (radioSegment1.Checked)
                {
                    this.addSegmentDeel(selectedTekst, 1);
                }
                else
                {
                    this.addSegmentDeel(selectedTekst, 2);
                }

                updateListboxes();
            }
        }


        private void btnAddRelationType_Click(object sender, EventArgs e)
        {
            RelationTypeForm rtForm = new RelationTypeForm(factType.dataModelNummer, factType.feitTypeCode);

            rtForm.ShowDialog();
        }

        #endregion   
    
        #region Functions
        /// <summary>
        /// Adds a segment via the business layer, this is based on segmentNumber
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="selectedTekst"></param>
        /// <param name="segmentNumber"></param>
        private void addSegmentDeel(string selectedTekst, int segmentNumber)
        {
            try
            {
                if(segmentNumber == 1)
                {
                    this.segmentOne.addSegmentDeel(selectedTekst);
                    sb.AddSegment(segmentOne);
                }
                else
                {
                    this.segmentTwo.addSegmentDeel(selectedTekst);
                    sb.AddSegment(segmentTwo);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(errorHandler.ParseErrorMessage(e));
            }            
        }

        /// <summary>
        /// Checks if the to be added segmentDeelTekst is unique.
        /// 
        /// Door: Marnix Dessing.
        /// </summary>
        /// <param name="selectedTekst"></param>
        /// <returns></returns>
        private Boolean IsUniqueSegmentDeel(string selectedTekst)
        {
            List<SegmentDeelDTO> AllSegmentDelen = new List<SegmentDeelDTO>();
            if (segmentOne.SegmentDeel != null)
                AllSegmentDelen.AddRange(segmentOne.SegmentDeel.ToList());
            if(segmentTwo.SegmentDeel != null)
                AllSegmentDelen.AddRange(segmentTwo.SegmentDeel.ToList());
            
            foreach(var item in AllSegmentDelen.Select(i => i.segmentDeelTekst))
            {
                if(item.Equals(selectedTekst))
                {
                    return false;
                }
            }
            return true;         
        }

        /// <summary>
        /// Updates the listboxes for segment one and two
        /// 
        /// Door: Harm Roerdink
        /// </summary>
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

        /// <summary>
        /// Gets segment one and two from the database
        /// Checks if they are not null, if they are create a new segment one or segment two object.
        ///
        /// Door: Harm Roerdink
        /// </summary>
        private void getSegmenten()
        {
            this.factType.Segment = new List<SegmentDTO>();
            this.segmentOne = this.getSegmentOnSegmentNumber(1);
            this.segmentTwo = this.getSegmentOnSegmentNumber(2);

            if (this.segmentOne == null)
            {
                this.segmentOne = new SegmentDTO();
                this.segmentOne.SetFactType(this.factType);
                this.segmentOne.segmentNummer = 1;
            }

            if (this.segmentTwo == null)
            {
                this.segmentTwo = new SegmentDTO();
                this.segmentTwo.SetFactType(this.factType);
                this.segmentTwo.segmentNummer = 2;
            }

            this.factType.Segment.Add(segmentOne);
            this.factType.Segment.Add(segmentTwo);
        }

        /// <summary>
        /// Resets the listboxes for segment one and two
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        private void resetListboxes()
        {
            lbSegment1.DataSource = null;
            lbSegment2.DataSource = null;
        }

        /// <summary>
        /// Gets a single segment based on segmentNumber.
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="segmentNummer"></param>
        /// <returns></returns>
        private SegmentDTO getSegmentOnSegmentNumber(int segmentNummer)
        {
            return this.sb.getSegmentOnSegmentNummer(segmentNummer, this.factType.dataModelNummer, this.factType.feitTypeCode);
        }

        /// <summary>
        /// Gets the selected segmentDeel
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <returns></returns>
        private SegmentDeelDTO getSelectedSegmentDeel()
        {
            SegmentDeelDTO selectedItem = (SegmentDeelDTO)lbSegment1.SelectedItem;
            if (selectedItem == null)
            {
                selectedItem = (SegmentDeelDTO)lbSegment2.SelectedItem;
            }

            return selectedItem;
        }

        /// <summary>
        /// Deletes the selected segmentDeel from segmentOne or segmentTwo based on the segmentNumber
        /// Attempts to delete the segmentDeel via the business layer
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="segmentDeel"></param>
        private void RemoveSegmentDeelFromSegment(SegmentDeelDTO segmentDeel)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u segment: " +segmentDeel.segmentDeelTekst + 
                                                        " uit segment " + segmentDeel.segmentNummer + " wil verwijderen?", 
                                                        "Verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (segmentDeel.segmentNummer == 1)
                    {
                        this.segmentOne.SegmentDeel.Remove(segmentDeel);
                    }
                    else
                    {
                        this.segmentTwo.SegmentDeel.Remove(segmentDeel);
                    }
                    
                    this.sb.DeleteSegmentDeel(segmentDeel);
                }
                catch (Exception e)
                {
                    MessageBox.Show(errorHandler.ParseErrorMessage(e));
                }
            }
        }

        #endregion

        #region NOT IMPLEMENTED
        
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

        #endregion

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            SegmentDTO segmentToAnalyse = null;
            if( lbSegment1.SelectedIndex == -1)
            {
                segmentToAnalyse = segmentTwo;    
            }
            else
            {
                segmentToAnalyse = segmentOne;
            }

            if(segmentToAnalyse == null)
            {
                MessageBox.Show("Er is geen segment aangewezen om te analyseren.");
                return;
            }

            segmentToAnalyse.factType = factType;

            var analyseSegmentFrom = new AnalyseSegmentForm(segmentToAnalyse);
            analyseSegmentFrom.Show();
            this.Enabled = false;
            analyseSegmentFrom.FormClosing += delegate
            {
                this.Enabled = true;
            };
        }
    }
}
