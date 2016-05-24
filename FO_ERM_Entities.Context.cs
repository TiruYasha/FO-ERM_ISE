﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FO_ERMEntities1 : DbContext
    {
        public FO_ERMEntities1()
            : base("name=FO_ERMEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attribuut> Attribuut { get; set; }
        public virtual DbSet<DataModel> DataModel { get; set; }
        public virtual DbSet<EntiteitType> EntiteitType { get; set; }
        public virtual DbSet<FeitType> FeitType { get; set; }
        public virtual DbSet<Kardinaliteit> Kardinaliteit { get; set; }
        public virtual DbSet<PredicaatDeel> PredicaatDeel { get; set; }
        public virtual DbSet<Relatietype> Relatietype { get; set; }
        public virtual DbSet<RelatieTypeOnderdeel> RelatieTypeOnderdeel { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<SegmentDeel> SegmentDeel { get; set; }
        public virtual DbSet<VoorbeeldData> VoorbeeldData { get; set; }
    
        public virtual int spr_CheckEntityDependency(Nullable<int> entityTypeNumber)
        {
            var entityTypeNumberParameter = entityTypeNumber.HasValue ?
                new ObjectParameter("entityTypeNumber", entityTypeNumber) :
                new ObjectParameter("entityTypeNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_CheckEntityDependency", entityTypeNumberParameter);
        }
    
        public virtual int spr_EntityTypeHasID(Nullable<int> entityTypeNumber)
        {
            var entityTypeNumberParameter = entityTypeNumber.HasValue ?
                new ObjectParameter("entityTypeNumber", entityTypeNumber) :
                new ObjectParameter("entityTypeNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_EntityTypeHasID", entityTypeNumberParameter);
        }
    
        public virtual int spr_Niew_segment_aanmaken(Nullable<int> dataModelNummer, string feitTypeCode, Nullable<int> segmentNummer, string segmentDeelTekst)
        {
            var dataModelNummerParameter = dataModelNummer.HasValue ?
                new ObjectParameter("dataModelNummer", dataModelNummer) :
                new ObjectParameter("dataModelNummer", typeof(int));
    
            var feitTypeCodeParameter = feitTypeCode != null ?
                new ObjectParameter("feitTypeCode", feitTypeCode) :
                new ObjectParameter("feitTypeCode", typeof(string));
    
            var segmentNummerParameter = segmentNummer.HasValue ?
                new ObjectParameter("segmentNummer", segmentNummer) :
                new ObjectParameter("segmentNummer", typeof(int));
    
            var segmentDeelTekstParameter = segmentDeelTekst != null ?
                new ObjectParameter("segmentDeelTekst", segmentDeelTekst) :
                new ObjectParameter("segmentDeelTekst", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_Niew_segment_aanmaken", dataModelNummerParameter, feitTypeCodeParameter, segmentNummerParameter, segmentDeelTekstParameter);
        }
    }
}
