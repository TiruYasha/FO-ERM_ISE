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
            this.ftBusiness = depman.getIFactTypeBusiness();

            setLvFacttypesItems();
        }

        private void btnAddFactType_Click(object sender, EventArgs e)
        {
            var addFacttypeForm = new AddFacttypeForm();
            addFacttypeForm.ShowDialog();

            if (addFacttypeForm.factCode != string.Empty && addFacttypeForm.verbalization != string.Empty)
            {
                addFactType(addFacttypeForm.factCode, addFacttypeForm.verbalization);
            }
        }

        private void btnDeleteFactType_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u het zeker?", "Verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                           
            }
        }

        private void btnUpdateFactType_Click(object sender, EventArgs e)
        {

        }

        private void lvFacttypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteFactType.Enabled = true;
            btnUpdateFactType.Enabled = true;
            btnSegmentManagement.Enabled = true;
        }

        private void addFactType(string factCode, string verbalization)
        {
            var newFacttype = new FacttypeDTO { feitTypeCode = factCode, verwoording = verbalization, dataModelNummer = dm.dataModelNummer };

            try
            {
                ftBusiness.addFactType(newFacttype);
                setLvFacttypesItems();
            }
            catch(Exception e)
            {
                MessageBox.Show("Er is een onverwachte fout opgetreden: " + e.Message);
            }
        }

        private void deleteFactType(FacttypeDTO selectedItem)
        {

        }

        private void setLvFacttypesItems()
        {
            lvFacttypes.Items.Clear();
            foreach(var i in ftBusiness.getAllFactTypesOnDatamodel(this.dm))
            {
                addFacttypeToListView(i);
            }
        }

        private void addFacttypeToListView(FacttypeDTO newFacttype)
        {
            string[] row = { newFacttype.feitTypeCode, newFacttype.verwoording };
            ListViewItem item = new ListViewItem(row);
            item.Tag = newFacttype;

            lvFacttypes.Items.Add(item);
        }
    }
}
