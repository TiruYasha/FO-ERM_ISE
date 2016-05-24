using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class SegmentDTO
    {
        public int segmentNummer { get; set; }
        public string feitTypeCode { get; set; }
        public int dataModelNummer { get; set; }
        public FacttypeDTO factType { get; set; }
        public List<SegmentDeelDTO> SegmentDeel { get; set; }
    }
}
