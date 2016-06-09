using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FO_ERM_ISE.business;
using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.presentation.relationtype
{
    public partial class RelationTypeForm : Form
    {
        private IEntitytypeBusiness eb;
        private IRelationTypeBusiness rtb;
        private int dataModelNumber;
        private string factTypeCode;
        private RelationTypeDTO relationTypeToUpdate;

        private DatabaseErrorHandler errorHandler;

        public RelationTypeForm(int dataModelNumber, string factTypeCode)
        {
            InitializeComponent();

            this.dataModelNumber = dataModelNumber;
            this.factTypeCode = factTypeCode;
            eb = new EntitytypeBusiness();
            rtb = new RelationTypeBusiness();
            errorHandler = new DatabaseErrorHandler();

            SetEntityTypes();
            DisableRadioButtons();
        }

        /// <summary>
        /// Update constructor
        /// </summary>
        /// <param name="selectedRelationType"></param>
        public RelationTypeForm(RelationTypeDTO selectedRelationType)
        {
            InitializeComponent();

            eb = new EntitytypeBusiness();
            rtb = new RelationTypeBusiness();
            errorHandler = new DatabaseErrorHandler();
            dataModelNumber = selectedRelationType.dataModelNummer;
            factTypeCode = selectedRelationType.feitTypeCode;
            relationTypeToUpdate = selectedRelationType;
            
            SetFormInformationForUpdate();
        }

        private void SetFormInformationForUpdate()
        {
            if (relationTypeToUpdate.RelatieTypeOnderdeel.Any(q => q.afhankelijk))
            {
                SetDependencies();
                SetDependentRelation(GetRelationTypePart(1).EntiteitType, GetRelationTypePart(2).EntiteitType);
            }
            else
            {
                SetEntityTypes();
                SetComboBoxIndexes();
                DisableRadioButtons();
            }

            txtRelationTypeName.Text = relationTypeToUpdate.relatieTypeNaam;

        }

        private RelationTypePartDTO GetRelationTypePart(int partNumber)
        {
            return relationTypeToUpdate.RelatieTypeOnderdeel.SingleOrDefault(q => q.onderdeelNummer == partNumber);
        }

        private void SetComboBoxIndexes()
        {
            RelationTypePartDTO partOne = GetRelationTypePart(1);
            RelationTypePartDTO partTwo = GetRelationTypePart(2);

            for(int i = 0; i < cbEntityTypeOne.Items.Count; i++)
            {
                if (((EntiteittypeDTO) cbEntityTypeOne.Items[i]).entiteitTypeNummer == partOne.entiteitTypeNummer)
                    cbEntityTypeOne.SelectedIndex = i;
            }

            for (int i = 0; i < cbEntityTypeTwo.Items.Count; i++)
            {
                if (((EntiteittypeDTO)cbEntityTypeTwo.Items[i]).entiteitTypeNummer == partTwo.entiteitTypeNummer)
                    cbEntityTypeTwo.SelectedIndex = i;
            }

           //TODO Cardinalities
        }

        private void DisableRadioButtons()
        {
            rbETAfhankelijkOne.Enabled = false;
            rbETAfhankelijkTwo.Enabled = false;
        }

        private void SetEntityTypes()
        {
            List<EntiteittypeDTO> entityTypesOne = eb.GetEntitytypeOnDataModel(dataModelNumber);
            List<EntiteittypeDTO> entityTypesTwo = eb.GetEntitytypeOnDataModel(dataModelNumber);

            cbEntityTypeOne.DisplayMember = "entiteitTypeNaam";
            cbEntityTypeOne.DataSource = entityTypesOne;

            cbEntityTypeTwo.DisplayMember = "entiteitTypeNaam";
            cbEntityTypeTwo.DataSource = entityTypesTwo;
        }


        #region Dependent relation
        /// <summary>
        /// This constructor will be used if the entitytypes are known.
        /// </summary>
        /// <param name="etOne">Dependent entity Type</param>
        /// <param name="etTwo">Not dependent entity type</param>
        /// <param name="factTypeCode"></param>
        public RelationTypeForm(EntiteittypeDTO etOne, EntiteittypeDTO etTwo, string factTypeCode)
        {
            InitializeComponent();

            this.dataModelNumber = etOne.dataModelNummer;
            this.factTypeCode = factTypeCode;
            eb = new EntitytypeBusiness();
            rtb = new RelationTypeBusiness();
            errorHandler = new DatabaseErrorHandler();
            SetDependentRelation(etOne, etTwo);
        }

        private void RelationTypeForm_Load(object sender, EventArgs e)
        {
            cbCardinalityOne.SelectedIndex = 0;
            cbCardinalityTwo.SelectedIndex = 0;
        }

        /// <summary>
        /// Constructs the whole form in a restrictive way for a pre determined dependency
        /// </summary>
        /// <param name="etOne"></param>
        /// <param name="etTwo"></param>
        private void SetDependentRelation(EntiteittypeDTO etOne, EntiteittypeDTO etTwo)
        {
            ComboBoxSetSingleETSource(cbEntityTypeOne, etOne);
            ComboBoxSetSingleETSource(cbEntityTypeTwo, etTwo);

            DisableETComboBox();

            SetDependencies();

            cbCardinalityOne.SelectedItem = "1,1";
            cbCardinalityOne.Enabled = false;
        }

        /// <summary>
        /// Sets the dependency radio buttons to work with pre determined dependency
        /// </summary>
        private void SetDependencies()
        {
            rbETAfhankelijkTwo.Checked = true;
            rbETAfhankelijkOne.Enabled = false;
            rbETAfhankelijkTwo.Enabled = false;
        }

        /// <summary>
        /// Disable the combo boxes with entity types
        /// </summary>
        private void DisableETComboBox()
        {
            cbEntityTypeOne.Enabled = false;
            cbEntityTypeTwo.Enabled = false;
        }

        /// <summary>
        /// Set single datasource for the Et comboboxes
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="entity"></param>
        private void ComboBoxSetSingleETSource(ComboBox comboBox, EntiteittypeDTO entity)
        {
            comboBox.DisplayMember = "entiteitTypeNaam";
            comboBox.Items.Add(entity);
            comboBox.SelectedIndex = 0;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtRelationTypeName.Text))
            {
                MessageBox.Show("De naam mag niet leeg zijn");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Wilt u dit relatietype opslaan?", "Relatietype opslaan", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    RelationTypeDTO relationTypeDto = SetRelationType();
                    if (relationTypeToUpdate != null)
                    {
                        //TODO Fix update
                        rtb.UpdateRelationTypeAndParts(relationTypeDto);
                    }
                    else
                    {
                        rtb.AddRelationType(relationTypeDto);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorHandler.ParseErrorMessage(ex));
                }
            }
        }

        /// <summary>
        /// Constructs the relation type based on the data in this form.
        /// </summary>
        /// <returns></returns>
        private RelationTypeDTO SetRelationType()
        {
            RelationTypeDTO relationTypeDto = new RelationTypeDTO
            {
                relatieTypeNaam = txtRelationTypeName.Text,
                dataModelNummer = dataModelNumber,
                feitTypeCode = factTypeCode
            };

            EntiteittypeDTO entityTypeOne = (EntiteittypeDTO)cbEntityTypeOne.SelectedItem;
            EntiteittypeDTO entityTypeTwo = (EntiteittypeDTO)cbEntityTypeTwo.SelectedItem;

            string[] cardinalityOne = cbCardinalityOne.SelectedItem.ToString().Split(',');
            string[] cardinalityTwo = cbCardinalityTwo.SelectedItem.ToString().Split(',');

            AddRelationTypePart(ref relationTypeDto, 1, entityTypeOne, rbETAfhankelijkOne.Checked, cardinalityOne[0], cardinalityOne[1]);
            AddRelationTypePart(ref relationTypeDto, 2, entityTypeTwo, rbETAfhankelijkTwo.Checked, cardinalityTwo[0], cardinalityTwo[1]);

            return relationTypeDto;
        }

        /// <summary>
        /// Add the RelationTypePart for the relationType
        /// </summary>
        /// <param name="relationTypeDto"></param>
        /// <param name="partNumber"></param>
        /// <param name="entiteittype"></param>
        /// <param name="afhankelijk"></param>
        /// <param name="minCardinality"></param>
        /// <param name="maxCardinality"></param>
        private void AddRelationTypePart(ref RelationTypeDTO relationTypeDto, int partNumber, EntiteittypeDTO entiteittype, bool afhankelijk, string minCardinality, string maxCardinality)
        {
            relationTypeDto.RelatieTypeOnderdeel.Add(new RelationTypePartDTO
            {
                dataModelNummer = dataModelNumber,
                onderdeelNummer = partNumber,
                entiteitTypeNummer = entiteittype.entiteitTypeNummer,
                afhankelijk = afhankelijk,
                relatieTypeNaam = txtRelationTypeName.Text,
                minimaleKardinaliteit = minCardinality,
                maximaleKardinaliteit = maxCardinality
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u wilt annuleren?", "Annuleren", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
