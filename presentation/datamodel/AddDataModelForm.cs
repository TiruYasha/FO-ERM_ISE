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
    public partial class AddDataModelForm : Form
    {

        public string DataModelName { get; set; }

        public AddDataModelForm()
        {
            InitializeComponent();
        }

        private void btnAddDataModel_Click(object sender, EventArgs e)
        {
            DataModelName = txtDataModelName.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
