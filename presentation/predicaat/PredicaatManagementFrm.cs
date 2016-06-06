using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.dependencyManager;
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

namespace FO_ERM_ISE.presentation.predicaat
{
    public partial class PredicaatManagementFrm : Form
    {
        private IAttributeBusiness ab;
        private FacttypeDTO factType;

        public PredicaatManagementFrm(FacttypeDTO factType)
        {
            InitializeComponent();

            this.txtVerwoording.Text = factType.verwoording;
            this.factType = factType;

            DependencyManager depman = new DependencyManager();
            ab = depman.GetIAttributeBusiness();

            loadPredicaat();
            getAttributes();
        }

        public void getAttributes()
        {
            List<AttributeDTO> attributes = ab.getAttributeForPredicate("", factType.dataModelNummer);
            this.lbAttributes.DataSource = attributes;
            this.lbAttributes.DisplayMember = "attribuutNaam";
        }

        public void loadPredicaat()
        {
            String predicaat = this.predicaatDeelToString(factType.PredicaatDeel);
            if (!String.IsNullOrEmpty(predicaat))
            {
                txtPredicaat.Text = predicaat;
            }
            else
            {
                txtPredicaat.Text = factType.verwoording;
            }
        }
            

        public String predicaatDeelToString(List<PredicaatDeelDTO> predicaten)
        {
            String predicaat = "";

            foreach(var predicaatDeel in predicaten.OrderBy( i => i.predicaatDeelNummer).ToList())
            {
                if(predicaatDeel.attribuutNummer != null)
                {
                    predicaat += "<" + ab.GetAttributeOnAttributeNumber(predicaatDeel.attribuutNummer.Value).attribuutNaam + "> ";
                }
                else
                {
                    predicaat += predicaatDeel.predicaatDeelTekst += " ";
                }                
            }

            return predicaat;
        }
    }
}
