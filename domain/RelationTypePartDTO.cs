using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class RelationTypePartDTO
    {
        public int relatieTypeOnderdeelNummer { get; set; }
        public int dataModelNummer { get; set; }
        public string relatieTypeNaam { get; set; }
        public bool afhankelijk { get; set; }
        public char minKardinaliteit { get; set; }
        public char maxKardinaliteit { get; set; }
        public int entiteitTypeNummer { get; set; }
    }
}
