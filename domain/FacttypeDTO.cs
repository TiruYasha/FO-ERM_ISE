using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class FacttypeDTO
    {
        public DatamodelDTO DataModel { get; set; }
        public List<SegmentDTO> Segment { get; set; }

        public string feitTypeCode { get; set; }
        public int dataModelNummer { get; set; }
        public string verwoording { get; set; }      
    }
}



