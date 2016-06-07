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
using FO_ERM_ISE.presentation.relationtype;

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

            foreach (AttributeDTO attr in
                AttrBusiness.GetAttributesOnEntityTypeNumber(EtToAnalyse.entiteitTypeNummer))
            {
                lbIDAttr.Items.Add(attr);
                lbIDAttr.DisplayMember = "attribuutNaam";
            }

        }

        private void fillAttributeInForm(AttributeDTO AttrToAnalyse)
        {
            if (AttrToAnalyse == null) return;
            txtAttrName.Text = AttrToAnalyse.attribuutNaam;
            if (AttrToAnalyse.verplicht == "True")
            {
                chMandatory.Checked = true;
            }
            else
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
            }
            else
            {
                loadEntityTypesInForm(segment.dataModelNummer);
            }
        }

        #endregion


        #region ACTIONS

        private EntiteittypeDTO saveET()
        {

            if (segment.attribuutNummer != 0 && segment.attribuutNummer != null)
            {
                AttributeDTO attribuutToDelte = AttrBusiness.GetAttributeOnAttributeNumber(segment.attribuutNummer.Value);
                segment.attribuutNummer = null;

                try
                {
                    AttrBusiness.DeleteAttribute(attribuutToDelte);
                    SegmentBusiness.UpdateSegment(segment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            if (chMatch.Checked)
            { //checked so save segment with ET numer then exit.
                segment.entiteitTypeNummer = ((EntiteittypeDTO)selectEntitytype.SelectedItem).entiteitTypeNummer;
                try
                {
                    SegmentBusiness.UpdateSegment(segment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
            else
            {  // new ET

                // save ET
                EntiteittypeDTO newEt = new EntiteittypeDTO();
                newEt.dataModelNummer = segment.dataModelNummer;
                newEt.entiteitTypeNaam = txtETNaam.Text;


                // if et does not exist make new else update 
                int newEtNummer = 0;

                if (segment.entiteitTypeNummer == null || segment.entiteitTypeNummer == 0)
                {
                    try
                    {
                        newEtNummer = ETBusiness.AddEntiteittype(newEt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    newEtNummer = segment.entiteitTypeNummer.Value;
                    newEt.entiteitTypeNummer = newEtNummer;

                    try
                    {
                        ETBusiness.UpdateEntiteittype(newEt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // save ID Attr
                syncAttributesWithDatabase(newEtNummer);

                // new et update segment 
                segment.entiteitTypeNummer = newEtNummer;
                newEt.entiteitTypeNummer = newEtNummer;
                try
                {
                    SegmentBusiness.UpdateSegment(segment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return newEt;
            }
        }

        private void syncAttributesWithDatabase(int etNummer)
        {

            foreach (AttributeDTO attribuut in lbIDAttr.Items)
            {
                if (attribuut.attribuutNummer != 0)
                {// attribuut bestaat dus update
                    try
                    {
                        AttrBusiness.UpdateAttribute(attribuut);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                { // bestaat nog niet voeg et nummer toe en sla op
                    attribuut.entiteitTypeNummer = etNummer;
                    try
                    {
                        AttrBusiness.AddAttribute(attribuut);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void saveAttr()
        {
            if (segment.entiteitTypeNummer != 0 && segment.entiteitTypeNummer != null)
            {
                EntiteittypeDTO etToDelte = ETBusiness.GetEntitytypeOnEntityTypeNumber(segment.entiteitTypeNummer.Value);
                segment.entiteitTypeNummer = null;
                try
                {
                    ETBusiness.DeleteEntiteittype(etToDelte);
                    SegmentBusiness.UpdateSegment(segment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            int segmentNummer;
            if (segment.segmentNummer == 1)
            {
                segmentNummer = 2;
            }
            else
            {
                segmentNummer = 1;
            }

            SegmentDTO anderSegment =
                SegmentBusiness.getSegmentOnSegmentNummer(segmentNummer, segment.dataModelNummer, segment.feitTypeCode);

            if (anderSegment == null || anderSegment.entiteitTypeNummer == 0 || anderSegment.entiteitTypeNummer == null)
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
                try
                {
                    AttrBusiness.UpdateAttribute(attr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //retreve number and save segment.
                try
                {
                    int attrNumber = AttrBusiness.AddAttribute(attr);
                    segment.attribuutNummer = attrNumber;
                    SegmentBusiness.UpdateSegment(segment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        // manage buttons

        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            NameIDAttributeForm form = new NameIDAttributeForm();
            form.ShowDialog();

            if (!string.IsNullOrEmpty(form.AttributeName))
            {
                AttributeDTO newAttr = new AttributeDTO();
                newAttr.attribuutNaam = form.AttributeName;
                newAttr.dataModelNummer = segment.dataModelNummer;
                newAttr.identificerend = "True";
                newAttr.verplicht = "True";

                lbIDAttr.Items.Add(newAttr);
                lbIDAttr.DisplayMember = "attribuutNaam";

            }
        }

        private void btnDeleteAttr_Click(object sender, EventArgs e)
        {
            if (lbIDAttr.SelectedItem != null &&
                ((AttributeDTO)lbIDAttr.SelectedItem).attribuutNummer != 0)
            {
                try
                {
                    AttrBusiness.DeleteAttribute((AttributeDTO)lbIDAttr.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                lbIDAttr.Items.Remove(lbIDAttr.SelectedItem);
            }
            else
            {
                lbIDAttr.Items.Remove(lbIDAttr.SelectedItem);
            }
        }

        private void btnAddRelationType_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Om een relatietype toe te voegen moet het entiteittype eerst worden opgeslagen. Wilt u deze nu opslaan?", "Entiteittype opslaan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                EntiteittypeDTO dependant = saveET();
                EntiteittypeDTO otherEt = (EntiteittypeDTO)lbDependentETs.SelectedItem;

                // open relation type add forum
                RelationTypeForm form = new RelationTypeForm(dependant, otherEt, segment.feitTypeCode);
                form.ShowDialog();
            }
        }

        #endregion
    }

}
