using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FO_ERM_ISE.Forms
{
    public partial class RenameDataModelForm : Form
    {
        public string DataModelName { get; set; }

        public RenameDataModelForm()
        {
            InitializeComponent();
        }

        private void btnRenameDataModel_Click(object sender, EventArgs e)
        {
            DataModelName = txtDataModelName.Text;
        }
    }
}
