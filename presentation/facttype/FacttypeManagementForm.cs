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
using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.presentation.segment;

namespace FO_ERM_ISE.presentation.facttype
{
    public partial class FacttypeManagementForm : Form
    {
        private DatamodelDTO dm;
        private IFactTypeBusiness ftBusiness;
        private DatabaseErrorHandler errorHandler;

        public FacttypeManagementForm(DatamodelDTO datamodel)
        {
            InitializeComponent();
            this.dm = datamodel;
            this.Text = "Feittype beheren - Datamodel: " + this.dm.dataModelNaam;

            DependencyManager depman = new DependencyManager();
            this.ftBusiness = depman.GetIFactTypeBusiness();

            this.errorHandler = new DatabaseErrorHandler();

            SetLvFacttypesItems();
        }

        #region EventHandlers
        
        /// <summary>
        /// Opens the editFactTypeForm
        /// 
        /// Checks if input if null or empty
        /// Executes the function AddFactType        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFactType_Click(object sender, EventArgs e)
        {
            var editFactTypeForm = new EditFactTypeForm("Feittypen toevoegen", null);

            editFactTypeForm.ShowDialog();

            if (!String.IsNullOrWhiteSpace(editFactTypeForm.factCode) &&
                 !String.IsNullOrWhiteSpace(editFactTypeForm.verbalization))
            {
                AddFactType(editFactTypeForm.factCode, editFactTypeForm.verbalization);
            }
        }

        /// <summary>
        /// Gets the selected factType
        /// Ask the user if he wants to delete the selected factType
        /// Deletes the selected factType
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFactType_Click(object sender, EventArgs e)
        {
            var selectedItem = this.getSelectedDataModel();

            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u feitType " + selectedItem.feitTypeCode + " wil verwijderen?", "Verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DeleteFactType(selectedItem);
            }
        }

        /// <summary>
        /// Gets the selected factType
        /// Opens the EditFactTypeForm(selectedFactType)
        /// 
        /// Checks if the input is not null or empty
        /// Updates the selected FactType
        /// Updates the selected FactType in the database
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateFactType_Click(object sender, EventArgs e)
        {
            var selectedModel = this.getSelectedDataModel();
            var editFactTypeForm = new EditFactTypeForm("Feittypen aanpassen", selectedModel);

            editFactTypeForm.ShowDialog();

            if (!String.IsNullOrWhiteSpace(editFactTypeForm.factCode) &&
                 !String.IsNullOrWhiteSpace(editFactTypeForm.verbalization))
            {
                selectedModel.feitTypeCode = editFactTypeForm.factCode;
                selectedModel.verwoording = editFactTypeForm.verbalization;
                UpdateFactType(selectedModel);
            }
        }

        /// <summary>
        /// If there are no fact types selected btnDeleteFactType, btnUpdateFactType, btnSegmentManagement are disabled
        /// If there is a factType selected the buttons are enabled
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvFacttypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFacttypes.SelectedItems.Count <= 0)
            {
                btnDeleteFactType.Enabled = false;
                btnUpdateFactType.Enabled = false;
                btnSegmentManagement.Enabled = false;
                btnVerifyFactType.Enabled = false;
            }
            else
            {
                btnDeleteFactType.Enabled = true;
                btnUpdateFactType.Enabled = true;
                btnSegmentManagement.Enabled = true;
                btnVerifyFactType.Enabled = true;
            }
        }

        /// <summary>
        /// Opens the segmentManagementForm and sends the selected factType with it
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSegmentManagement_Click(object sender, EventArgs e)
        {
            var segmentManagementForm = new SegmentManagementForm(this.getSelectedDataModel());

            segmentManagementForm.Show();
            this.Hide();

            segmentManagementForm.FormClosing += delegate
            {
                this.Show();
            };
        }

        /// <summary>
        /// Verifies the selected factType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerifyFactType_Click(object sender, EventArgs e)
        {
            try
            {
                FacttypeDTO ft = this.getSelectedDataModel();
                this.ftBusiness.verifyFactType(ft);
                SetLvFacttypesItems();

                MessageBox.Show("Feit type: " + ft.feitTypeCode + " is geverifieerd!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(this.errorHandler.ParseErrorMessage(ex));
            }
        }

        #endregion

        #region Functions

        private FacttypeDTO getSelectedDataModel()
        {
            return (FacttypeDTO)lvFacttypes.SelectedItems[0].Tag;
        }

        /// <summary>
        /// Creates a new FacttypeDTO object
        /// Attempts to save it via the business layer
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="factCode"></param>
        /// <param name="verbalization"></param>
        private void AddFactType(string factCode, string verbalization)
        {
            var newFacttype = new FacttypeDTO { feitTypeCode = factCode, verwoording = verbalization, dataModelNummer = dm.dataModelNummer, geverifieerd = false };

            try
            {
                ftBusiness.AddFactType(newFacttype);
                SetLvFacttypesItems();
            }
            catch (Exception e)
            {
                MessageBox.Show(errorHandler.ParseErrorMessage(e));
            }
        }

        /// <summary>
        /// Attempts to delete the selected factType via the business layer.
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="selectedItem"></param>
        private void DeleteFactType(FacttypeDTO selectedItem)
        {
            try
            {
                ftBusiness.DeleteFactType(selectedItem); //Try to delete the facttype               
                SetLvFacttypesItems(); //Update the list view facttypes
            }
            catch (Exception e)
            {
                MessageBox.Show(errorHandler.ParseErrorMessage(e));
            }
        }

        /// <summary>
        /// Attempts to update the selected FactType
        /// 
        /// </summary>
        /// <param name="selectedItem"></param>
        private void UpdateFactType(FacttypeDTO selectedItem)
        {
            try
            {
                ftBusiness.UpdateFactType(selectedItem); //Try to update the facttype               
                SetLvFacttypesItems(); //Update the list view facttypes
            }
            catch (Exception e)
            {
                MessageBox.Show(errorHandler.ParseErrorMessage(e));
            }
        }

        /// <summary>
        /// Updates the factType list view with all the factTypes in the database
        /// 
        /// </summary>
        private void SetLvFacttypesItems()
        {
            lvFacttypes.Items.Clear();
            foreach (var i in ftBusiness.GetAllFactTypesOnDatamodel(this.dm))
            {
                AddFacttypeToListView(i);
            }
        }

        /// <summary>
        /// Adds a single factType to the factTypeListView
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="newFacttype"></param>
        private void AddFacttypeToListView(FacttypeDTO newFacttype)
        {
            string[] row = { newFacttype.feitTypeCode, newFacttype.verwoording, newFacttype.geverifieerd.ToString() };
            ListViewItem item = new ListViewItem(row);
            item.Tag = newFacttype;
            
            if(newFacttype.geverifieerd)
            {
                item.BackColor = Color.LightGreen;
            }
            else
            {
                item.BackColor = Color.LightCoral;
            }

            lvFacttypes.Items.Add(item);
        }

        #endregion                                             
        
    }
}
