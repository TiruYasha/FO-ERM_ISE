//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FO_ERM_ISE
{
    using System;
    using System.Collections.Generic;
    
    public partial class SegmentDeel
    {
        public int dataModelNummer { get; set; }
        public string feitTypeCode { get; set; }
        public int segmentNummer { get; set; }
        public int segmentDeelnummer { get; set; }
        public string segmentDeelTekst { get; set; }
    
        public virtual Segment Segment { get; set; }
    }
}
