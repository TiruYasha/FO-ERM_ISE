using FO_ERM_ISE.domain;
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
    public partial class EditFactTypeForm : Form
    {

        public string factCode { get; set; }
        public string verbalization { get; set; }

        /// <summary>
        /// Form for editing/creating facttypes
        /// </summary>
        /// <param name="title">Dialog title text</param>
        /// <param name="facttype">FacttypeDTO for editing OR null for new facttype</param>
        public EditFactTypeForm(String title, FacttypeDTO facttype)
        {
            InitializeComponent();
            this.Text = title;

            if (facttype != null)
            {
               txtFactCode.Text = facttype.feitTypeCode;
               txtVerbalization.Text = facttype.verwoording;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveFacttype_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditFactTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            factCode = txtFactCode.Text;
            verbalization = txtVerbalization.Text;
        }
    }
}
