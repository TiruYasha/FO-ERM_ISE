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
    
    public partial class DataModel
    {
        public DataModel()
        {
            this.EntiteitType = new HashSet<EntiteitType>();
            this.FeitType = new HashSet<FeitType>();
            this.Relatietype = new HashSet<Relatietype>();
        }
    
        public int dataModelNummer { get; set; }
        public string dataModelNaam { get; set; }
    
        public virtual ICollection<EntiteitType> EntiteitType { get; set; }
        public virtual ICollection<FeitType> FeitType { get; set; }
        public virtual ICollection<Relatietype> Relatietype { get; set; }
    }
}
