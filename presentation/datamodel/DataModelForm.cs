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
        /*
         * TODO
         * 
         * Exception handling!
         */

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

        /*
         * btnAddDataModel
         * 
         * Shows addDatamodelForm
         * Checks if input is not null or empty
         * 
         * Executes AddDatamodel(datamodelName)
         */
        private void btnAddDataModel_Click(object sender, EventArgs e)
        {
            var addDataModelForm = new AddDataModelForm();
            addDataModelForm.ShowDialog(); //Show addDatamodelForm

            //Check if input is not null or empty
            if (!string.IsNullOrEmpty(addDataModelForm.DataModelName))
            {  
                this.AddDatamodel(addDataModelForm.DataModelName); 
            }
        }

        /*
         * If a datamodel is selected the controls for deleting, renaming and factType management should be enabled
         */
        private void lbDataModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteDataModel.Enabled = true;
            btnFactTypeManagement.Enabled = true;
            btnRenameDataModel.Enabled = true;
        }

        /*
         * btnDeleteDataModel
         * 
         * Shows y/n dialog box
         * IF yes Executes deleteDatamodel(selectedItem)
         */
        private void btnDeleteDataModel_Click(object sender, EventArgs e)
        {
            var selectedItem = (DatamodelDTO)lbDataModel.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Weet u zeker dat u datamodel "+ selectedItem.dataModelNaam +" en onderliggende elementen wil verwijderen?", "Verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DeleteDatamodel(selectedItem);
            }
        }

        private void btnRenameDataModel_Click(object sender, EventArgs e)
        {
            var renameDataModelForm = new RenameDataModelForm();

            renameDataModelForm.ShowDialog();

            if (renameDataModelForm.DataModelName != null || renameDataModelForm.DataModelName != String.Empty)
            {
                var selectedModel = (DatamodelDTO)lbDataModel.SelectedItem;
                UpdateDatamodel(renameDataModelForm.DataModelName, selectedModel);
            }
        }

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

        private void AddDatamodel(String datamodelName)
        {
            DatamodelDTO dm = new DatamodelDTO { dataModelNaam = datamodelName }; //Create a new datamodel object

            try
            {
                dmBusiness.AddDatamodel(dm); //Try to save the datamodel                
                SetlbDatamodelDatasource(); //Update the datasource of lbDatamodel
            }
            catch(Exception e)
            {
                MessageBox.Show(errorHanlder.ParseErrorMessage(e));
            }
        }

        private void DeleteDatamodel(DatamodelDTO datamodel)
        {
            try
            {
                dmBusiness.DeleteDataModel(datamodel); //Try to delete the datamodel               
                SetlbDatamodelDatasource(); //Update the datasource of lbDatamodel
            }
            catch(Exception e)
            {
                MessageBox.Show(errorHanlder.ParseErrorMessage(e));
            }
        }

        private void UpdateDatamodel(String newDatamodelName, DatamodelDTO selectedModel)
        {
            try
            {
                selectedModel.dataModelNaam = newDatamodelName;
                dmBusiness.UpdateDataModel(selectedModel);
                SetlbDatamodelDatasource();
            }
            catch(Exception e)
            {
                MessageBox.Show(errorHanlder.ParseErrorMessage(e));
            }
        }

        private void SetlbDatamodelDatasource()
        {
            lbDataModel.DataSource = null; //Clear the datasource
            lbDataModel.DataSource = dmBusiness.GetAllDatamodels(); //Add the updated datasource
            lbDataModel.DisplayMember = "dataModelNaam"; //Set display member
        }
    }
}
