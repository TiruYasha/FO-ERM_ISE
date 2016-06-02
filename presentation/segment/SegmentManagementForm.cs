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
        /// On click handler voor de verwijderen knop. Voert de functies RemoveSegmentDeelFromSegment en getSelectedSegmentDeel uit.
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
        /// Als de er een item in de listbox voor segment één geselecteerd is, mag er geen item geselecteerd zijn in de listbox voor segment twee.
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
        /// Als de er een item in de listbox voor segment twee geselecteerd is, mag er geen item geselecteerd zijn in de listbox voor segment één.
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
        /// Controleert of het segmentdeel uniek is binnen de segmentdelen die al aangegeven zijn via de functie IsUniqueSegmentDeel.
        /// Voert de functies addSegmentDeel en updateListboxes uit.
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

        #endregion   
    
        #region Functions
        /// <summary>
        /// Stuurt een segment dat toegevoegd moet worden door naar de business laag. Dit gebeurt op basis van segmentNummer.
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
        /// Controleert of het toegevoegde segmentDeel al voorkomt
        /// 
        /// Door: Marnix Dessing.
        /// </summary>
        /// <param name="selectedTekst"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update de listboxes voor segment één en twee.
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
        /// Haalt de segmenten op uit de database, als deze nog niet bestaan worden deze aangemaakt (Nog niet in de database maar als object).
        ///
        /// Door: Harm Roerdink
        /// </summary>
        private void getSegmenten()
        {
            this.segmentOne = this.getSegmentDeel(1);
            this.segmentTwo = this.getSegmentDeel(2);

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
        }

        /// <summary>
        /// Reset de listboxes voor segment één en segment twee
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        private void resetListboxes()
        {
            lbSegment1.DataSource = null;
            lbSegment2.DataSource = null;
        }

        /// <summary>
        /// Haalt een segment op, op basis van het segmentNummer
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="segmentNummer"></param>
        /// <returns></returns>
        private SegmentDTO getSegmentDeel(int segmentNummer)
        {
            return this.sb.getSegmentOnSegmentNummer(segmentNummer, this.factType.dataModelNummer, this.factType.feitTypeCode);
        }

        /// <summary>
        /// Haalt het geselecteerde segmentDeel op, dit is altijd of een segmentdeel uit segment één of segment twee.
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
        /// Verwijderd het geselecteerde segment uit de objecten segmentOne of segmentTwo gebaseerd op het geselecteerde segmentDeel.
        /// Hierna wordt de functie deleteSegment uitgevoerd in de businessLaag.
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
                    if (segmentDeel.segment.segmentNummer == 1)
                    {
                        this.segmentOne.SegmentDeel.Remove(segmentDeel);
                        this.sb.DeleteSegment(segmentOne);
                    }
                    else
                    {
                        this.segmentTwo.SegmentDeel.Remove(segmentDeel);
                        this.sb.DeleteSegment(segmentTwo);
                    }
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
    }
}
