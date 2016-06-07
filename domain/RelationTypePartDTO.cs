using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class RelationTypePartDTO
    {
        public int onderdeelNummer { get; set; }
        public int dataModelNummer { get; set; }
        public string relatieTypeNaam { get; set; }
        public bool afhankelijk { get; set; }
        public string minimaleKardinaliteit { get; set; }
        public string maximaleKardinaliteit { get; set; }
        public int entiteitTypeNummer { get; set; }

        public EntiteittypeDTO EntiteitType { get; set; }
        public CardinalityDTO Kardinaliteit { get; set; }
        public RelationTypeDTO RelatieType { get; set; }
    }
}
