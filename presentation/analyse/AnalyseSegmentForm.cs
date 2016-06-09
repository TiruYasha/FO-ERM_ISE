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

        private DatabaseErrorHandler errorHandler;

        public AnalyseSegmentForm(SegmentDTO segment)
        {
            InitializeComponent();
            errorHandler = new DatabaseErrorHandler();

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
                if (attr.identificerend == "True")
                {
                    lbIDAttr.Items.Add(attr);
                    lbIDAttr.DisplayMember = "attribuutNaam";
                }
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
            selectEntitytype.Items.Clear();
            lbDependentETs.Items.Clear();

            string currentEtName = "";
            if(segment.entiteitTypeNummer != null && segment.entiteitTypeNummer != 0)
            {
                currentEtName = ETBusiness.GetEntitytypeOnEntityTypeNumber(segment.entiteitTypeNummer.Value).entiteitTypeNaam;
            }

            foreach (EntiteittypeDTO et in ets)
            {
                // prevent displaying own entitytype in form
                if (!et.entiteitTypeNaam.Equals(currentEtName))
                {
                    selectEntitytype.Items.Add(et);
                    selectEntitytype.DisplayMember = "entiteitTypeNaam";

                    lbDependentETs.Items.Add(et);
                    lbDependentETs.DisplayMember = "entiteitTypeNaam";
                }
            }

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
            }
            else
            {
                loadEntityTypesInForm(segment.dataModelNummer);
            }
        }

        #endregion


        #region ACTIONS

        private void removeAttributeWithNumber(Nullable<int> attributeNumber)
        {
            if (attributeNumber != null)
            {
                AttributeDTO attribuutToDelte = AttrBusiness.GetAttributeOnAttributeNumber(attributeNumber.Value);
                AttrBusiness.DeleteAttribute(attribuutToDelte);
            }
        }

        private void removeEntityTypeWithNumber(Nullable<int> entityTypeNumber)
        {
            try
            {
                if (entityTypeNumber != null)
                {
                    EntiteittypeDTO entityTypeToDelete = ETBusiness.GetEntitytypeOnEntityTypeNumber(entityTypeNumber.Value);
                    ETBusiness.DeleteEntiteittype(entityTypeToDelete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorHandler.ParseErrorMessage(ex));
            }
        }

        private EntiteittypeDTO saveET()
        {


            if (chMatch.Checked)
            { //checked so save segment with ET numer then exit. When there is a attribute remove that
                try
                {
                    segment.entiteitTypeNummer = ((EntiteittypeDTO)selectEntitytype.SelectedItem).entiteitTypeNummer;
                    if (segment.attribuutNummer != 0 && segment.attribuutNummer != null)
                    {
                        removeAttributeWithNumber(segment.attribuutNummer);
                    }
                    segment.attribuutNummer = null;
                    SegmentBusiness.UpdateSegment(segment);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorHandler.ParseErrorMessage(ex));
                }
                return null;
            }
            else
            {  // Try to save ET (new or update)
                try
                {
                    EntiteittypeDTO newEt = new EntiteittypeDTO();
                    newEt.dataModelNummer = segment.dataModelNummer;
                    newEt.entiteitTypeNaam = txtETNaam.Text;


                    // if et does not exist make new else update 
                    int newEtNummer = 0;
                    if (segment.entiteitTypeNummer == null || segment.entiteitTypeNummer == 0)
                    { // new
                        newEtNummer = ETBusiness.AddEntiteittype(newEt);
                    }
                    else // upate
                    {
                        newEtNummer = segment.entiteitTypeNummer.Value;
                        newEt.entiteitTypeNummer = newEtNummer;
                        ETBusiness.UpdateEntiteittype(newEt);
                    }

                    // save ID Attr
                    syncAttributesWithDatabase(newEtNummer);

                    // update segment for new et
                    if (segment.attribuutNummer != 0 && segment.attribuutNummer != null)
                    {
                        removeAttributeWithNumber(segment.attribuutNummer);
                    }
                    segment.entiteitTypeNummer = newEtNummer;
                    segment.attribuutNummer = null;
                    SegmentBusiness.UpdateSegment(segment);

                    return newEt;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(errorHandler.ParseErrorMessage(ex));
                }

                return null;
            } 

        }

        private void syncAttributesWithDatabase(int etNummer)
        {

            foreach (AttributeDTO attribuut in lbIDAttr.Items)
            {
                if (attribuut.attribuutNummer != 0)
                {// attribuut bestaat dus update
                     AttrBusiness.UpdateAttribute(attribuut);
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
                        MessageBox.Show(errorHandler.ParseErrorMessage(ex));
                    }
                }
            }

        }

        private void saveAttr()
        {

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
                    MessageBox.Show(errorHandler.ParseErrorMessage(ex));
                }
            }
            else
            {
                //retreve number and save segment.
                try
                {
                    int attrNumber = AttrBusiness.AddAttribute(attr); // store new attr
                    segment.attribuutNummer = attrNumber;

                    // (if exists) remove old entitytype
                    if (segment.entiteitTypeNummer != 0 && segment.entiteitTypeNummer != null)
                    {
                        removeEntityTypeWithNumber(segment.entiteitTypeNummer.Value);
                        segment.entiteitTypeNummer = null;
                    }

                    SegmentBusiness.UpdateSegment(segment); // save segment
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorHandler.ParseErrorMessage(ex));
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
                if (!String.IsNullOrWhiteSpace(txtAttrName.Text))
                {
                    saveAttr();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Attribuut naam is leeg.");
                }

            }
        }

        private void btnSaveET_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u dit segment als een entiteittype wilt opslaan?", "Entieittype opslaan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if ((!String.IsNullOrWhiteSpace(txtETNaam.Text) && !chMatch.Checked) || chMatch.Checked)
                {
                    saveET();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Entiteittype naam is leeg.");
                }                    
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
                    MessageBox.Show(errorHandler.ParseErrorMessage(ex));
                    return;
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
