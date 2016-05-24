using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FO_ERM_ISE.presentation.facttype
{
    public partial class AddFacttypeForm : Form
    {
        public string factCode { get; set; }
        public string verbalization { get; set; }

        public AddFacttypeForm()
        {
            InitializeComponent();
        }

        private void btnAddFacttype_Click(object sender, EventArgs e)
        {
            factCode = txtFactCode.Text;
            verbalization = txtVerbalization.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
