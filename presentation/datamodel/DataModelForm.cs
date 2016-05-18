using System;
using System.Windows.Forms;
using FO_ERM_ISE.presentation.facttype;
using FO_ERM_ISE.business;
using FO_ERM_ISE.business.interfaces;
using System.Collections.Generic;
using FO_ERM_ISE.dependencyManager;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.Forms
{
    public partial class DataModelForm : Form
    {
        IDatamodelBusiness dmBusiness; //Datamodel business layer
        List<DatamodelDTO> datamodels; //Serves as datasource for the listbox lbDatamodels

        public DataModelForm()
        {
            InitializeComponent();

            DependencyManager depman = new DependencyManager();
            this.dmBusiness = depman.getIDatamodelBusiness();          
            datamodels = dmBusiness.getAllDatamodels();

            setlbDatamodelDatasource();
        }

        /*
         * btnAddDataModel
         * 
         * Shows addDatamodelForm
         * Checks if input is not null or empty
         * 
         * Executes addDatamodel(datamodelName)
         */
        private void btnAddDataModel_Click(object sender, EventArgs e)
        {
            var addDataModelForm = new AddDataModelForm();
            addDataModelForm.ShowDialog(); //Show addDatamodelForm

            //Check if input is not null or empty
            if (addDataModelForm.DataModelName != null && addDataModelForm.DataModelName != string.Empty)
            {  
                this.addDatamodel(addDataModelForm.DataModelName); 
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
                deleteDatamodel(selectedItem);
            }
        }

        private void btnRenameDataModel_Click(object sender, EventArgs e)
        {
            var renameDataModelForm = new RenameDataModelForm();

            renameDataModelForm.ShowDialog();

            if (renameDataModelForm.DataModelName != null || renameDataModelForm.DataModelName != String.Empty)
            {
                var selectedModel = (DatamodelDTO)lbDataModel.SelectedItem;
                updateDatamodel(renameDataModelForm.DataModelName, selectedModel);
            }
        }

        private void btnFactTypeManagement_Click(object sender, EventArgs e)
        {
            var facttypeManagementForm = new FacttypeManagementForm((DataModel)lbDataModel.SelectedItem);

            facttypeManagementForm.Show();
            this.Hide();

            facttypeManagementForm.FormClosing += delegate
            {
                this.Show();
            };
        }

        private void addDatamodel(String datamodelName)
        {
            DatamodelDTO dm = new DatamodelDTO { dataModelNaam = datamodelName }; //Create a new datamodel object

            try
            {
                dmBusiness.addDatamodel(dm); //Try to save the datamodel
                this.datamodels.Add(dm); //Add the new datamodel to the datamodel list
                setlbDatamodelDatasource(); //Update the datasource of lbDatamodel
            }
            catch(Exception e)
            {
                //Exception handling
            }
        }

        private void deleteDatamodel(DatamodelDTO datamodel)
        {
            try
            {
                dmBusiness.deleteDataModel(datamodel); //Try to delete the datamodel
                this.datamodels.Remove(datamodel); //Remove the datamodel from the datamodel list
                setlbDatamodelDatasource(); //Update the datasource of lbDatamodel
            }
            catch(Exception e)
            {
                //Exception handling
            }
        }

        private void updateDatamodel(String newDatamodelName, DatamodelDTO selectedModel)
        {
            try
            {
                selectedModel.dataModelNaam = newDatamodelName;
                dmBusiness.updateDataModel(selectedModel);
                setlbDatamodelDatasource();
            }
            catch(Exception e)
            {
                //Exception handling
            }
        }

        private void setlbDatamodelDatasource()
        {
            lbDataModel.DataSource = null; //Clear the datasource
            lbDataModel.DataSource = datamodels; //Add the updated datasource
            lbDataModel.DisplayMember = "dataModelNaam"; //Set display member
        }
    }
}
