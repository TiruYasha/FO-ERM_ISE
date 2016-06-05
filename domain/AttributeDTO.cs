using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class AttributeDTO
    {
        public int entiteitTypeNummer { get; set; }
        public int dataModelNummer { get; set; }
        public int attribuutNummer { get; set; }

        public string attribuutNaam { get; set; }
        public string verplicht { get; set; }
        public string identificerend { get; set; }

        public SegmentDTO segment { get; set; }

    }
}
