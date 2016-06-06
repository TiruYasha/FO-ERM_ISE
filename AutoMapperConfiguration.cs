using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE
{
    class AutoMapperConfiguration : Profile 
    {
        protected override void Configure()
        {
            CreateMap<DataModel, DatamodelDTO>();
            CreateMap<DatamodelDTO, DataModel>();

            CreateMap<FeitType, FacttypeDTO>();
            CreateMap<FacttypeDTO, FeitType>();

            CreateMap<Segment, SegmentDTO>();
            CreateMap<SegmentDTO, Segment>();

            CreateMap<SegmentDeel, SegmentDeelDTO>();
            CreateMap<SegmentDeelDTO, SegmentDeel>();

            CreateMap<Relatietype, RelationTypeDTO>();
            CreateMap<RelationTypeDTO, Relatietype>();

            CreateMap<RelatieTypeOnderdeel, RelationTypePartDTO>();
            CreateMap<RelationTypePartDTO, RelatieTypeOnderdeel>();

            CreateMap<EntiteitType, EntiteittypeDTO>();
            CreateMap<EntiteittypeDTO, EntiteitType>();

            CreateMap<Attribuut, AttributeDTO>();
            CreateMap<AttributeDTO, Attribuut>();

        }
    }
}
