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
        private IAttributeBusiness AttrBusiness;
        private ISegmentBusiness SegmentBusiness;


        public AnalyseSegmentForm(SegmentDTO segment)
        {
            InitializeComponent();

            DependencyManager dm = new DependencyManager();
            this.ETBusiness = dm.GetIEntitytypeBusiness();
            this.AttrBusiness = dm.GetIAttributeBusiness();
            this.SegmentBusiness = dm.GetISegmentBusiness();
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

            if (segment.entiteitTypeNummer != null)
            {
                var EtToAnalyse = ETBusiness.GetEntitytypeOnEntityTypeNumber(segment.entiteitTypeNummer.Value);
                fillEntitytypeInForm(EtToAnalyse);
            }
            else if (segment.attribuutNummer != null)
            {
                var AttrToAnalyse = AttrBusiness.GetAttributeOnAttributeNumber(segment.attribuutNummer.Value);
                fillAttributeInForm(AttrToAnalyse);
            }

        }

        private void fillEntitytypeInForm(EntiteittypeDTO EtToAnalyse)
        {
            txtETNaam.Text = EtToAnalyse.entiteitTypeNaam;
            // laad identificerende attribuuten.
        }

        private void fillAttributeInForm(AttributeDTO AttrToAnalyse)
        {
            if (AttrToAnalyse == null) return; 
            txtAttrName.Text = AttrToAnalyse.attribuutNaam;
            if(AttrToAnalyse.verplicht == "True")
            {
                chMandatory.Checked = true;
            } else
            {
                chMandatory.Checked = false;
            }
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

        private void chMatch_CheckedChanged(object sender, EventArgs e)
        {
            selectEntitytype.Enabled = !selectEntitytype.Enabled;

            txtETNaam.Enabled = !txtETNaam.Enabled;
            lbDependentETs.Enabled = !lbDependentETs.Enabled;
            lbIDAttr.Enabled = !lbIDAttr.Enabled;
            btnAddRelationType.Enabled = !btnAddRelationType.Enabled;
            btnAddAttribute.Enabled = !btnAddAttribute.Enabled;

            if (chMatch.Checked)
            {
                lbDependentETs.DataSource = null;
                txtETNaam.Text = "";
                txtIdentificatoren.Text = "";
            } else
            {
                loadEntityTypesInForm(segment.dataModelNummer);
            }
        }

        #endregion


        #region ACTIONS

        private void saveET()
        {
            if (chMatch.Checked)
            { //checked so save segment with ET numer then exit.
                segment.entiteitTypeNummer = ((EntiteittypeDTO)selectEntitytype.SelectedItem).entiteitTypeNummer;
            } else
            {  // new ET

                // save ET
                EntiteittypeDTO newEt = new EntiteittypeDTO();
                newEt.dataModelNummer = segment.dataModelNummer;
                newEt.entiteitTypeNaam = txtETNaam.Text;

                int newETnummer = ETBusiness.AddEntiteittype(newEt);

                // save ID Attr
                //      for each in listbox create attrbibute
                foreach(string naam in lbIDAttr.Items)
                {
                    AttributeDTO newAttr = new AttributeDTO();
                    newAttr.attribuutNaam = naam;
                    newAttr.dataModelNummer = segment.dataModelNummer;
                    newAttr.entiteitTypeNummer = newETnummer;
                    newAttr.identificerend = "True";
                    newAttr.verplicht = "True";
                    AttrBusiness.AddAttribute(newAttr);
                }

                // save relationtypes


                // update segment
                segment.entiteitTypeNummer = newETnummer;
                SegmentBusiness.UpdateSegment(segment);
            }
        }

        private void saveAttr()
        {

            int segmentNummer;
            if(segment.segmentNummer == 1)
            {
                segmentNummer = 2;
            } else
            {
                segmentNummer = 1;
            }

            SegmentDTO anderSegment = 
                SegmentBusiness.getSegmentOnSegmentNummer(segmentNummer, segment.dataModelNummer, segment.feitTypeCode);

            if(anderSegment == null || anderSegment.entiteitTypeNummer == 0)
            {
                // the other segment is null or is a Attr.
                MessageBox.Show("Kan het attribuut niet opslaan: " +
                    "Er is of nog geen ander entiteittype in dit feittype, " +
                    "of het is al een attribuut.");
                return;
            }

            AttributeDTO attr = new AttributeDTO();
            attr.attribuutNaam = txtAttrName.Text;
            attr.dataModelNummer = segment.dataModelNummer;
            attr.entiteitTypeNummer = anderSegment.entiteitTypeNummer.Value;
            attr.verplicht = "False";
            if (chMandatory.Checked) attr.verplicht = "True";
            attr.identificerend = "False";

            // add as a new attribute or update attribute
            if (segment.attribuutNummer != null)
            {
                // update
                attr.attribuutNummer = segment.attribuutNummer.Value;
                AttrBusiness.UpdateAttribute(attr);              
            }
            else
            {
                //retreve number and save segment.
                int attrNumber = AttrBusiness.AddAttribute(attr);
                segment.attribuutNummer = attrNumber;
                SegmentBusiness.UpdateSegment(segment);
            }

            
        }

        private void cancel()
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt annuleren?", "Annuleren", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        #endregion


        #region EVENTS

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void btnSaveAttr_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u dit segment als een attribuut wilt opslaan?", "Attribuut opslaan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveAttr();
                this.Close();
            }
        }

        private void btnSaveET_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u dit segment als een entiteittype wilt opslaan?", "Entieittype opslaan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveET();
                this.Close();
            }
        }

        #endregion

        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            NameIDAttributeForm form = new NameIDAttributeForm();
            form.ShowDialog();

            if (!string.IsNullOrEmpty(form.AttributeName))
            {
                lbIDAttr.Items.Add(form.AttributeName);
            }
        }

        private void btnDeleteAttr_Click(object sender, EventArgs e)
        {
            if(lbIDAttr.SelectedItem != null)
            {
                lbIDAttr.Items.Remove(lbIDAttr.SelectedItem);
            }
        }
    }

}
