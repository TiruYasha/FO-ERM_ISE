using System;
using System.Windows.Forms;

namespace FO_ERM_ISE.Forms
{
    public partial class DataModelForm : Form
    {
        public DataModelForm()
        {
            InitializeComponent();
        }

        private void btnAddDataModel_Click(object sender, EventArgs e)
        {
            var addDataModelForm = new AddDataModelForm();

            addDataModelForm.ShowDialog();

            if (addDataModelForm.DataModelName != null || addDataModelForm.DataModelName != string.Empty)
            {
                lbDataModel.Items.Add(addDataModelForm.DataModelName);
            }
        }

        private void lbDataModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteDataModel.Enabled = true;
            btnFactTypeManagement.Enabled = true;
            btnRenameDataModel.Enabled = true;
        }

        private void btnDeleteDataModel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Weet u het zeker?", "Verwijderen", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                lbDataModel.Items.Remove(lbDataModel.SelectedItem);
            }
            
        }

        private void btnRenameDataModel_Click(object sender, EventArgs e)
        {
            var renameDataModelForm = new RenameDataModelForm();

            renameDataModelForm.ShowDialog();

            if (renameDataModelForm.DataModelName != null || renameDataModelForm.DataModelName != String.Empty)
            {
                
            }
        }

        private void btnFactTypeManagement_Click(object sender, EventArgs e)
        {

        }
    }
}
