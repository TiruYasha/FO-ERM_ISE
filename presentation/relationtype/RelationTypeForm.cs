using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        /// <summary>
        /// This constructor will be used if the entitytypes are known.
        /// </summary>
        /// <param name="etOne">Dependent Entity Type</param>
        /// <param name="etTwo">Not dependent Entity type</param>
        public RelationTypeForm(EntiteittypeDTO etOne, EntiteittypeDTO etTwo)
        {
            InitializeComponent();

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
            ComboBoxSetSingleETSource(cbEntityTypeOne, etTwo);

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
            rbETAfhankelijkOne.Checked = true;
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
        /// <param name="etOne"></param>
        private void ComboBoxSetSingleETSource(ComboBox comboBox, EntiteittypeDTO etOne)
        {
            cbEntityTypeOne.DisplayMember = "entiteitTypeNaam";
            cbEntityTypeOne.DataSource = etOne;
        }

        private void SetEntityTypes()
        {
            List<EntiteittypeDTO> entityTypes = eb.GetEntitytypeOnDataModel(dataModelNumber);

            cbEntityTypeOne.DisplayMember = "entiteitTypeNaam";
            cbEntityTypeOne.DataSource = entityTypes;

            cbEntityTypeTwo.DisplayMember = "entiteitTypeNaam";
            cbEntityTypeTwo.DataSource = entityTypes;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtRelationTypeName.Text))
            {
                MessageBox.Show("De naam mag niet leeg zijn");
                return;
            }
            try
            {
                RelationTypeDTO relationTypeDto = SetRelationType();
                rtb.AddRelationType(relationTypeDto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorHandler.ParseErrorMessage(ex));
            }
        }

        /// <summary>
        /// Constructs the relation type based on the data in this form.
        /// </summary>
        /// <returns></returns>
        private RelationTypeDTO SetRelationType()
        {
            RelationTypeDTO relationTypeDto = new RelationTypeDTO();

            relationTypeDto.relatieTypeNaam = txtRelationTypeName.Text;
            relationTypeDto.dataModelNummer = dataModelNumber;
            relationTypeDto.feitTypeCode = factTypeCode;

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

       
    }
}
