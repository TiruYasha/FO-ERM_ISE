using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.domain
{
    public class PredicaatDeelDTO
    {
        public int dataModelNummer { get; set; }
        public string feitTypeCode { get; set; }
        public int predicaatDeelNummer { get; set; }
        public Nullable<int> attribuutNummer { get; set; }
        public string predicaatDeelTekst { get; set; }
        
        public FacttypeDTO FeitType { get; set; }
        public AttributeDTO Attribuut { get; set; }
        
    }
}
