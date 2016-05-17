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

namespace FO_ERM_ISE.presentation.facttype
{
    public partial class FacttypeManagementForm : Form
    {
        public DataModel datamodel;

        public FacttypeManagementForm(DataModel datamodel)
        {
            InitializeComponent();
            this.datamodel = datamodel;
            this.Text = "Feittype beheren - Datamodel: " + this.datamodel.dataModelNaam;
        }

        private void btnAddFactType_Click(object sender, EventArgs e)
        {
            var addFacttypeForm = new AddFacttypeForm();
            addFacttypeForm.ShowDialog();

            if (addFacttypeForm.factCode != string.Empty && addFacttypeForm.verbalization != string.Empty)
            {
                var newFacttype = new FacttypeDTO
                {
                    factCode = addFacttypeForm.factCode,
                    verbalization = addFacttypeForm.verbalization
                };

                string[] row = { newFacttype.factCode, newFacttype.verbalization };
                ListViewItem item = new ListViewItem(row);
                item.Tag = newFacttype;
                lvFacttypes.Items.Add(item);
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

        private void lbFacttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteFactType.Enabled = true;
            btnUpdateFactType.Enabled = true;
            btnSegmentManagement.Enabled = true;
        }

        private void lvFacttypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
