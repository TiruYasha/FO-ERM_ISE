using System;
using System.Windows.Forms;
using FO_ERM_ISE.presentation.facttype;
using FO_ERM_ISE.business;
using FO_ERM_ISE.business.interfaces;
using System.Collections.Generic;
using FO_ERM_ISE.dependencyManager;
using FO_ERM_ISE.domain;
using FO_ERM_ISE.presentation;

namespace FO_ERM_ISE.Forms
{   
    public partial class DataModelForm : Form
    {
        IDatamodelBusiness dmBusiness; //Datamodel business layer
        DatabaseErrorHandler errorHanlder;

        public DataModelForm()
        {
            InitializeComponent();

            DependencyManager depman = new DependencyManager();
            this.dmBusiness = depman.GetIDatamodelBusiness();

            this.errorHanlder = new DatabaseErrorHandler();

            SetlbDatamodelDatasource();
        }

        #region Event handlers

        /// <summary>
        /// Shows addDatamodelForm
        /// Checks if input is not null or empty
        /// 
        /// Executes AddDatamodel(datamodelName)
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDataModel_Click(object sender, EventArgs e)
        {
            var addDataModelForm = new AddDataModelForm();
            addDataModelForm.ShowDialog();

            if (!string.IsNullOrEmpty(addDataModelForm.DataModelName))
            {
                this.AddDatamodel(addDataModelForm.DataModelName);
            }
        }

        /// <summary>
        /// If a datamodel is selected the controls for deleting, renaming and factType management should be enabled
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDataModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteDataModel.Enabled = true;
            btnFactTypeManagement.Enabled = true;
            btnRenameDataModel.Enabled = true;
        }

        /// <summary>
        /// Shows y/n dialog box
        /// IF yes Executes deleteDatamodel(selectedItem)
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDataModel_Click(object sender, EventArgs e)
        {
            var selectedItem = (DatamodelDTO)lbDataModel.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u datamodel " + selectedItem.dataModelNaam + " en onderliggende elementen wil verwijderen?", "Verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DeleteDatamodel(selectedItem);
            }
        }

        /// <summary>
        /// Shows renameDatamodelForm
        /// Checks if the input is null or empty
        /// Executes UpdateDatamodel(newDatamodelName, Datamodel)
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRenameDataModel_Click(object sender, EventArgs e)
        {
            var renameDataModelForm = new RenameDataModelForm();

            renameDataModelForm.ShowDialog();

            if (renameDataModelForm.DataModelName != null && renameDataModelForm.DataModelName != String.Empty)
            {
                var selectedModel = (DatamodelDTO)lbDataModel.SelectedItem;
                UpdateDatamodel(renameDataModelForm.DataModelName, selectedModel);
            }
        }

        /// <summary>
        /// Opens the factTypeManagementForm(SelectedDatamodel)
        /// Hides this form
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFactTypeManagement_Click(object sender, EventArgs e)
        {
            var facttypeManagementForm = new FacttypeManagementForm((DatamodelDTO)lbDataModel.SelectedItem);

            facttypeManagementForm.Show();
            this.Hide();

            facttypeManagementForm.FormClosing += delegate
            {
                this.Show();
            };
        }

        #endregion

        #region Functions

        /// <summary>
        /// Creates a new datamodel object and attempts to save it to the database via the business layer.
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="datamodelName"></param>
        private void AddDatamodel(String datamodelName)
        {
            DatamodelDTO dm = new DatamodelDTO { dataModelNaam = datamodelName }; //Create a new datamodel object

            try
            {
                dmBusiness.AddDatamodel(dm); //Try to save the datamodel                
                SetlbDatamodelDatasource(); //Update the datasource of lbDatamodel
            }
            catch (Exception e)
            {
                MessageBox.Show(errorHanlder.ParseErrorMessage(e));
            }
        }

        /// <summary>
        /// Attempts to delete a datamodel via the business layer.
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="datamodel"></param>
        private void DeleteDatamodel(DatamodelDTO datamodel)
        {
            try
            {
                dmBusiness.DeleteDataModel(datamodel); //Try to delete the datamodel               
                SetlbDatamodelDatasource(); //Update the datasource of lbDatamodel
            }
            catch (Exception e)
            {
                MessageBox.Show(errorHanlder.ParseErrorMessage(e));
            }
        }

        /// <summary>
        /// Attempts to update a existing datamodel via the business layer
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        /// <param name="newDatamodelName"></param>
        /// <param name="selectedModel"></param>
        private void UpdateDatamodel(String newDatamodelName, DatamodelDTO selectedModel)
        {
            try
            {
                selectedModel.dataModelNaam = newDatamodelName;
                dmBusiness.UpdateDataModel(selectedModel);
                SetlbDatamodelDatasource();
            }
            catch (Exception e)
            {
                MessageBox.Show(errorHanlder.ParseErrorMessage(e));
            }
        }

        /// <summary>
        /// resets the datasource of lbDataModel
        /// 
        /// Door: Harm Roerdink
        /// </summary>
        private void SetlbDatamodelDatasource()
        {
            lbDataModel.DataSource = null; //Clear the datasource
            lbDataModel.DataSource = dmBusiness.GetAllDatamodels(); //Add the updated datasource
            lbDataModel.DisplayMember = "dataModelNaam"; //Set display member
        }

        #endregion                               
    }
}
