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
    
    public partial class Attribuut
    {
        public Attribuut()
        {
            this.PredicaatDeel = new HashSet<PredicaatDeel>();
            this.VoorbeeldData = new HashSet<VoorbeeldData>();
        }
    
        public int entiteitTypeNummer { get; set; }
        public string attribuutNaam { get; set; }
        public bool verplicht { get; set; }
        public bool identificerend { get; set; }
        public int attribuutNummer { get; set; }
    
        public virtual EntiteitType EntiteitType { get; set; }
        public virtual ICollection<PredicaatDeel> PredicaatDeel { get; set; }
        public virtual ICollection<VoorbeeldData> VoorbeeldData { get; set; }
    }
}
