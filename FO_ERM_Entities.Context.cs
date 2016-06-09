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
    
        public virtual int spr_EntityTypeHasID(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_EntityTypeHasID", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_Niew_segment_aanmaken(Nullable<int> dataModelNumber, string factTypeCode, Nullable<int> segmentNummer, string segmentDeelTekst)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            var segmentNummerParameter = segmentNummer.HasValue ?
                new ObjectParameter("segmentNummer", segmentNummer) :
                new ObjectParameter("segmentNummer", typeof(int));
    
            var segmentDeelTekstParameter = segmentDeelTekst != null ?
                new ObjectParameter("segmentDeelTekst", segmentDeelTekst) :
                new ObjectParameter("segmentDeelTekst", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_Niew_segment_aanmaken", dataModelNumberParameter, factTypeCodeParameter, segmentNummerParameter, segmentDeelTekstParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spr_CheckIfETHasDependentRelationAndNoID(Nullable<int> dataModelNumber, string factTypeCode, ObjectParameter warningMessage)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_CheckIfETHasDependentRelationAndNoID", dataModelNumberParameter, factTypeCodeParameter, warningMessage);
        }
    
        public virtual int spr_EntityTypeNotDependentRelationToItself(Nullable<int> datamodelNumber, string feitTypeCode)
        {
            var datamodelNumberParameter = datamodelNumber.HasValue ?
                new ObjectParameter("datamodelNumber", datamodelNumber) :
                new ObjectParameter("datamodelNumber", typeof(int));
    
            var feitTypeCodeParameter = feitTypeCode != null ?
                new ObjectParameter("feitTypeCode", feitTypeCode) :
                new ObjectParameter("feitTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_EntityTypeNotDependentRelationToItself", datamodelNumberParameter, feitTypeCodeParameter);
        }
    
        public virtual int spr_NotDependentRelatieTypeOnderdeelMustHaveKardinaliteitOneOne(Nullable<int> datamodelNumber, string feitTypeCode)
        {
            var datamodelNumberParameter = datamodelNumber.HasValue ?
                new ObjectParameter("datamodelNumber", datamodelNumber) :
                new ObjectParameter("datamodelNumber", typeof(int));
    
            var feitTypeCodeParameter = feitTypeCode != null ?
                new ObjectParameter("feitTypeCode", feitTypeCode) :
                new ObjectParameter("feitTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_NotDependentRelatieTypeOnderdeelMustHaveKardinaliteitOneOne", datamodelNumberParameter, feitTypeCodeParameter);
        }
    
        public virtual int spr_OneSegmentIsEntityType(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_OneSegmentIsEntityType", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_OnlyOneDependentRelatieOnderdeel(Nullable<int> datamodelNumber, string feitTypeCode, ObjectParameter returnParameter)
        {
            var datamodelNumberParameter = datamodelNumber.HasValue ?
                new ObjectParameter("datamodelNumber", datamodelNumber) :
                new ObjectParameter("datamodelNumber", typeof(int));
    
            var feitTypeCodeParameter = feitTypeCode != null ?
                new ObjectParameter("feitTypeCode", feitTypeCode) :
                new ObjectParameter("feitTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_OnlyOneDependentRelatieOnderdeel", datamodelNumberParameter, feitTypeCodeParameter, returnParameter);
        }
    
        public virtual int spr_PredicaatAttributeInFacttype(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_PredicaatAttributeInFacttype", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_RelatieType_NotDependentRelatieTypeOnderdeelMustHaveKardinaliteitOneOne(Nullable<int> datamodelNumber, string factTypeCode, ObjectParameter returnParameter)
        {
            var datamodelNumberParameter = datamodelNumber.HasValue ?
                new ObjectParameter("datamodelNumber", datamodelNumber) :
                new ObjectParameter("datamodelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_RelatieType_NotDependentRelatieTypeOnderdeelMustHaveKardinaliteitOneOne", datamodelNumberParameter, factTypeCodeParameter, returnParameter);
        }
    
        public virtual int spr_RelatieTypeExactlyTwoParts(Nullable<int> datamodelNumber, string feitTypeCode)
        {
            var datamodelNumberParameter = datamodelNumber.HasValue ?
                new ObjectParameter("datamodelNumber", datamodelNumber) :
                new ObjectParameter("datamodelNumber", typeof(int));
    
            var feitTypeCodeParameter = feitTypeCode != null ?
                new ObjectParameter("feitTypeCode", feitTypeCode) :
                new ObjectParameter("feitTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_RelatieTypeExactlyTwoParts", datamodelNumberParameter, feitTypeCodeParameter);
        }
    
        public virtual int spr_RelationInSameDataModel(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_RelationInSameDataModel", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_SegmentHasSegmentPart(Nullable<int> dataModelNumber, string factTypeCode, Nullable<int> segmentNumber)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            var segmentNumberParameter = segmentNumber.HasValue ?
                new ObjectParameter("segmentNumber", segmentNumber) :
                new ObjectParameter("segmentNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_SegmentHasSegmentPart", dataModelNumberParameter, factTypeCodeParameter, segmentNumberParameter);
        }
    
        public virtual int spr_SegmentMustHaveEntityTypeOrAttribute(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_SegmentMustHaveEntityTypeOrAttribute", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_SegmentValidation(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_SegmentValidation", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_TwoSegmentsHaveARelationType(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_TwoSegmentsHaveARelationType", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_TwoSegmentsMustHaveETETOrETATT(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_TwoSegmentsMustHaveETETOrETATT", dataModelNumberParameter, factTypeCodeParameter);
        }
    
        public virtual int spr_ValidateRelatieType(Nullable<int> datamodelNumber, string feitTypeCode, ObjectParameter returnParameter)
        {
            var datamodelNumberParameter = datamodelNumber.HasValue ?
                new ObjectParameter("datamodelNumber", datamodelNumber) :
                new ObjectParameter("datamodelNumber", typeof(int));
    
            var feitTypeCodeParameter = feitTypeCode != null ?
                new ObjectParameter("feitTypeCode", feitTypeCode) :
                new ObjectParameter("feitTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_ValidateRelatieType", datamodelNumberParameter, feitTypeCodeParameter, returnParameter);
        }
    
        public virtual int spr_FactTypeValidation(Nullable<int> dataModelNumber, string factTypeCode)
        {
            var dataModelNumberParameter = dataModelNumber.HasValue ?
                new ObjectParameter("dataModelNumber", dataModelNumber) :
                new ObjectParameter("dataModelNumber", typeof(int));
    
            var factTypeCodeParameter = factTypeCode != null ?
                new ObjectParameter("factTypeCode", factTypeCode) :
                new ObjectParameter("factTypeCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spr_FactTypeValidation", dataModelNumberParameter, factTypeCodeParameter);
        }
    }
}
