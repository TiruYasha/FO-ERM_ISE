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
    
    public partial class PredicaatDeel
    {
        public int dataModelNummer { get; set; }
        public string feitTypeCode { get; set; }
        public int predicaatDeelNummer { get; set; }
        public Nullable<int> attribuutNummer { get; set; }
        public string predicaatDeelTekst { get; set; }
    
        public virtual Attribuut Attribuut { get; set; }
        public virtual FeitType FeitType { get; set; }
    }
}
