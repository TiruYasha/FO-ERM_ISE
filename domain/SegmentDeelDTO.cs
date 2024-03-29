﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class SegmentDeelDTO
    {
        public int segmentDeelNummer { get; set; }
        public string segmentDeelTekst { get; set; }
        public int segmentNummer { get; set; }

        public string feitTypeCode { get; set; }
        public int dataModelNummer { get; set; }
        public FacttypeDTO factType { get; set; }
        public SegmentDTO segment { get; set; }
    }
}
