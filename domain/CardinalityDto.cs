using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class CardinalityDTO
    {
        public string minimaleKardinaliteit { get; set; }
        public string maximaleKardinaliteit { get; set; }

        public ICollection<RelationTypePartDTO> RelatieTypeOnderdeel { get; set; } 
    }
}
