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
using FO_ERM_ISE.dependencyManager;
using FO_ERM_ISE.business;
using FO_ERM_ISE.business.interfaces;

namespace FO_ERM_ISE.presentation.analyse
{
    public partial class AnalyseSegmentForm : Form
    {
        private SegmentDTO segment;

        private IEntitytypeBusiness ETBusiness;


        public AnalyseSegmentForm(SegmentDTO segment)
        {
            InitializeComponent();

            DependencyManager dm = new DependencyManager();
            this.ETBusiness = dm.GetIEntitytypeBusiness();
            this.segment = segment;

            fetchAnalyeFromSegment(segment);

            loadEntityTypesInForm(segment.dataModelNummer);
        }


        #region LOAD IN FORM

        private void fetchAnalyeFromSegment(SegmentDTO segment)
        {
            string segmentText = "";
            foreach (SegmentDeelDTO segmentDeel in segment.SegmentDeel)
            {
                segmentText += segmentDeel.segmentDeelTekst;
            }
            this.txtSegment.Text = segmentText;

            if (segment.entiteitTypeNummer != 0)
            {
                var EtToAnalyse = ETBusiness.GetEntitytypeOnEntityTypeNumber(segment.entiteitTypeNummer);
                fillEntitytypeInForm(EtToAnalyse);
            }
            else
            {
                // doe hetzelfde alleen nu voor een attribuut.
                //this.EtToAnalyse = ETBusiness.GetEntitytypeOnEntityTypeNumber(segment.entiteitTypeNummer);
            }

        }

        private void fillEntitytypeInForm(EntiteittypeDTO EtToAnalyse)
        {
            txtETNaam.Text = EtToAnalyse.entiteitTypeNaam;
            // laad identificerende attribuuten.
        }

        private void fillAttributeInForm(AttributeDTO AttrToAnalyse)
        {
            //laad de attr naam in de box
            // check mandatory 
        }

        private void loadEntityTypesInForm(int dataModelNumber)
        {
            List<EntiteittypeDTO> ets = ETBusiness.GetEntitytypeOnDataModel(dataModelNumber);
            lbDependentETs.DataSource = null;
            lbDependentETs.DataSource = ets;
            lbDependentETs.DisplayMember = "entiteitTypeNaam";

            selectEntitytype.DataSource = null;
            selectEntitytype.DataSource = ets;
            selectEntitytype.DisplayMember = "entiteitTypeNaam";
        }

        #endregion


        #region MATCH functions

        private void setMatch(EntiteittypeDTO entityTypeMatch)
        {
            if (entityTypeMatch == null)
            {
                this.Refresh();
            }
            else
            {
                // laad ET attribuuten en relaties etc.
            }

        }

        private void chMatch_CheckedChanged(object sender, EventArgs e)
        {
            selectEntitytype.Enabled = !selectEntitytype.Enabled;

            txtETNaam.Enabled = !txtETNaam.Enabled;
            lbDependentETs.Enabled = !lbDependentETs.Enabled;
            btnAddRelationType.Enabled = !btnAddRelationType.Enabled;
            btnAddAttribute.Enabled = !btnAddAttribute.Enabled;

            if (!chMatch.Checked)
            {
                setMatch(null);
            }
        }

        #endregion


        private void saveET()
        {
            // sla het et op
            // sla id attribuuten op
            // sla dependant relatietyps op

            // voeg verwijzing toe aan segment.
        }

        private void saveAttr()
        {
            // vind bijbehorend entiteittype
            // sla attribuut op

            // voeg verwijzing toe aan segment.
        }

        private void cancel()
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt annuleren?", "Annuleren", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        #region EVENTS

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void selectEntitytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chMatch.Checked)
            {
                setMatch((EntiteittypeDTO)selectEntitytype.SelectedItem);
            }
        }

        private void btnSaveAttr_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u dit segment als een attribuut wilt opslaan?", "Attribuut opslaan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveAttr();
            }
        }

        private void btnSaveET_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u dit segment als een entiteittype wilt opslaan?", "Entieittype opslaan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveET();
            }
        }

        #endregion
    }

}
