using FO_ERM_ISE.business;
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
        private IPredicaatBusiness pb;
        private FacttypeDTO factType;

        private DatabaseErrorHandler errorHandler;

        public PredicaatManagementFrm(FacttypeDTO factType)
        {
            InitializeComponent();

            this.txtVerwoording.Text = factType.verwoording;
            this.factType = factType;

            DependencyManager depman = new DependencyManager();
            ab = depman.GetIAttributeBusiness();
            pb = depman.getIPredicaatBusiness();

            this.errorHandler = new DatabaseErrorHandler();

            loadPredicaat();
            getAttributes();

            if(factType.PredicaatDeel.Count() > 1)
            {
                this.disableInput();
            }
        }

        public void disableInput()
        {
            lbAttributes.Enabled = false;
            btnAddAttribute.Enabled = false;
            btnSave.Enabled = false;
        }

        public void getAttributes()
        {
            List<AttributeDTO> attributes = ab.getAttributeForPredicate("", factType.dataModelNummer);
            this.lbAttributes.DataSource = attributes;
            this.lbAttributes.DisplayMember = "attribuutNaam";
        }

        public void loadPredicaat()
        {
            String predicaat = this.predicaatDelenToString(factType.PredicaatDeel);
            
            if (!String.IsNullOrEmpty(predicaat))
            {
                txtPredicaat.Text = predicaat;
            }
            else
            {
                this.factType.PredicaatDeel.Add(new PredicaatDeelDTO
                                                    {
                                                        predicaatDeelNummer = 1,
                                                        predicaatDeelTekst = this.factType.verwoording.Trim(),
                                                        FeitType = this.factType,
                                                        feitTypeCode = this.factType.feitTypeCode,
                                                        dataModelNummer = this.factType.dataModelNummer
                                                    });
                txtPredicaat.Text = this.predicaatDelenToString(factType.PredicaatDeel);
            }
        }

        public String predicaatDelenToString(List<PredicaatDeelDTO> predicaten)
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
                    predicaat += predicaatDeel.predicaatDeelTekst + " ";
                }                
            }

            return predicaat;
        }

        //Wat als het geselecteerde woord meerdere keren voorkomt?
        //Mag de geselecteerde tekst uit meerdere woorden bestaan?
        public void addPredicaatDeel(String selectedTekst, AttributeDTO attribute)
        {
            Boolean updatePredicaatDelen = false;
            int predicaatDeelNummer = 1;
            List<PredicaatDeelDTO> newPredicaatDelen = new List<PredicaatDeelDTO>();           

            foreach(var predicaatDeel in this.factType.PredicaatDeel)
            {
                if(!String.IsNullOrEmpty(predicaatDeel.predicaatDeelTekst) && predicaatDeel.predicaatDeelTekst.Contains(selectedTekst))
                {
                    updatePredicaatDelen = true;
                    predicaatDeelNummer = predicaatDeel.predicaatDeelNummer + 1;            
        
                    //Selected tekst found in the predicaatDeel
                    newPredicaatDelen.Add(this.newPredicaatDeel(predicaatDeelNummer, null, attribute));
                                       
                    String predicaatDeelTekst = predicaatDeel.predicaatDeelTekst;
                    String before = predicaatDeelTekst.Substring(0, predicaatDeelTekst.IndexOf(selectedTekst)).Trim(); //Tekst in de predicaatDeelTekst voor de geselecteerde tekst
                    String after = predicaatDeelTekst.Substring(predicaatDeelTekst.LastIndexOf(selectedTekst) + selectedTekst.Length).Trim(); //Tekst in de predicaatDeelTekst NA de geselecteerde tekst

                    if(!String.IsNullOrEmpty(before))
                    {
                        predicaatDeel.predicaatDeelTekst = before; //Updaten van het huidige predicaatDeel in de foreach loop.
                    }
                    
                    if(!String.IsNullOrEmpty(after))
                    {
                        predicaatDeelNummer += 1;
                        newPredicaatDelen.Add(this.newPredicaatDeel(predicaatDeelNummer, after, null));                      
                    }
                }
                else
                {
                    if(updatePredicaatDelen)
                    {
                        predicaatDeelNummer += 1;
                        predicaatDeel.predicaatDeelNummer = predicaatDeelNummer;
                    }
                }
            }

            if(newPredicaatDelen != null && newPredicaatDelen.Any())
            {
                this.factType.PredicaatDeel.AddRange(newPredicaatDelen);
            }
        }

        private PredicaatDeelDTO newPredicaatDeel(int predicaatDeelNummer, string predicaatDeelTekst, AttributeDTO attribuut)
        {
            int? attribuutNummer = null;

            if(attribuut != null)
            {
                attribuutNummer = attribuut.attribuutNummer;
            }
            return new PredicaatDeelDTO
                    {
                        predicaatDeelNummer = predicaatDeelNummer,
                        feitTypeCode = this.factType.feitTypeCode,
                        dataModelNummer = this.factType.dataModelNummer,
                        predicaatDeelTekst = predicaatDeelTekst,
                        attribuutNummer = attribuutNummer,
                    }; 
        }

        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtVerwoording.SelectedText.Trim()))
            {
                addPredicaatDeel(txtVerwoording.SelectedText.Trim(), (AttributeDTO)lbAttributes.SelectedItem);
                loadPredicaat();
            }
            else
            {
                MessageBox.Show("Selecteer een tekst uit de verwoording!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.pb.AddPredicaatDelen(this.factType.PredicaatDeel);
                MessageBox.Show("Het predicaat is aangemaakt");
                this.disableInput();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this.errorHandler.ParseErrorMessage(ex));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
