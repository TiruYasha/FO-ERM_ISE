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
        /*
         * TODO 
         * 
         * Exception handling
         * Update
         * Delete
         */
        private DatamodelDTO dm;
        private IFactTypeBusiness ftBusiness;

        public FacttypeManagementForm(DatamodelDTO datamodel)
        {
            InitializeComponent();
            this.dm = datamodel;
            this.Text = "Feittype beheren - Datamodel: " + this.dm.dataModelNaam;

            DependencyManager depman = new DependencyManager();
            this.ftBusiness = depman.GetIFactTypeBusiness();

            SetLvFacttypesItems();
        }

        private void btnAddFactType_Click(object sender, EventArgs e)
        {
            var editFactTypeForm = new EditFactTypeForm("Feittypen toevoegen", null);

            editFactTypeForm.ShowDialog();

            if ( !String.IsNullOrWhiteSpace(editFactTypeForm.factCode) &&
                 !String.IsNullOrWhiteSpace(editFactTypeForm.verbalization) )
            {
                AddFactType(editFactTypeForm.factCode, editFactTypeForm.verbalization);
            }

        }

        private void btnDeleteFactType_Click(object sender, EventArgs e)
        {
            var selectedItem = (FacttypeDTO)lvFacttypes.SelectedItems[0].Tag;

            DialogResult dialogResult = MessageBox.Show("Weet u het zeker?", "Verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DeleteFactType(selectedItem);
            }
        }

        private void btnUpdateFactType_Click(object sender, EventArgs e)
        {
            var selectedModel = (FacttypeDTO)lvFacttypes.SelectedItems[0].Tag;
            var editFactTypeForm = new EditFactTypeForm("Feittypen aanpassen", selectedModel);

            editFactTypeForm.ShowDialog();

            if ( !String.IsNullOrWhiteSpace(editFactTypeForm.factCode) &&
                 !String.IsNullOrWhiteSpace(editFactTypeForm.verbalization))
            {
                selectedModel.feitTypeCode = editFactTypeForm.factCode;
                selectedModel.verwoording = editFactTypeForm.verbalization;
                UpdateFactType(selectedModel);
            }
        }

        private void lvFacttypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvFacttypes.SelectedItems.Count <= 0)
            {
                btnDeleteFactType.Enabled = false;
                btnUpdateFactType.Enabled = false;
                btnSegmentManagement.Enabled = false;
            }
            else
            {
                btnDeleteFactType.Enabled = true;
                btnUpdateFactType.Enabled = true;
                btnSegmentManagement.Enabled = true;
            }
            
        }

    

        private void AddFactType(string factCode, string verbalization)
        {
            var newFacttype = new FacttypeDTO { feitTypeCode = factCode, verwoording = verbalization, dataModelNummer = dm.dataModelNummer };

            try
            {
                ftBusiness.AddFactType(newFacttype);
                SetLvFacttypesItems();
            }
            catch(Exception e)
            {
                MessageBox.Show("Er is een onverwachte fout opgetreden: " + e.Message);
            }
        }

        private void DeleteFactType(FacttypeDTO selectedItem)
        {
            try
            {
                ftBusiness.DeleteFactType(selectedItem); //Try to delete the facttype               
                SetLvFacttypesItems(); //Update the list view facttypes
            }
            catch (Exception e)
            {
                MessageBox.Show("Er is een onverwachte fout opgetreden: " + e.Message);
            }
        }

        private void UpdateFactType(FacttypeDTO selectedItem)
        {
            try
            {
                ftBusiness.UpdateFactType(selectedItem); //Try to delete the facttype               
                SetLvFacttypesItems(); //Update the list view facttypes
            }
            catch (Exception e)
            {
                MessageBox.Show("Er is een onverwachte fout opgetreden: " + e.Message);
            }
        }

        private void SetLvFacttypesItems()
        {
            lvFacttypes.Items.Clear();
            foreach(var i in ftBusiness.GetAllFactTypesOnDatamodel(this.dm))
            {
                AddFacttypeToListView(i);
            }
        }

        private void AddFacttypeToListView(FacttypeDTO newFacttype)
        {
            string[] row = { newFacttype.feitTypeCode, newFacttype.verwoording };
            ListViewItem item = new ListViewItem(row);
            item.Tag = newFacttype;

            lvFacttypes.Items.Add(item);
        }

        private void btnSegmentManagement_Click(object sender, EventArgs e)
        {
            var segmentManagementForm = new SegmentManagementForm((FacttypeDTO)lvFacttypes.SelectedItems[0].Tag);

            segmentManagementForm.Show();
            this.Hide();

            segmentManagementForm.FormClosing += delegate
            {
                this.Show();
            };
        }
    }
}
