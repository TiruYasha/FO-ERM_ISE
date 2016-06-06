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

namespace FO_ERM_ISE.presentation.relationtype
{
    public partial class RelationTypeForm : Form
    {
        public RelationTypeForm()
        {
            InitializeComponent();

        }

        /// <summary>
        /// This constructor will be used if the entitytypes are known.
        /// </summary>
        /// <param name="etNameOne"></param>
        /// <param name="etNameTwo"></param>
        public RelationTypeForm(EntiteittypeDTO etOne, EntiteittypeDTO etTwo)
        {
            InitializeComponent();
        }




    }
}
