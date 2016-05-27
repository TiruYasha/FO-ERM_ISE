using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    class SegmentDatasource : Datasource<Segment, SegmentDTO>, ISegmentDatasource
    {
        public List<SegmentDTO> getAllSegmentenOnFacttype(FacttypeDTO facttype)
        {
            List<Segment> factTypes = this.get_DB().Segment.Where(i => i.feitTypeCode == facttype.feitTypeCode && i.dataModelNummer == facttype.dataModelNummer).ToList();          
            return this.dtoMapper.mapEntitiesToDTOs(factTypes);
        }

        public override void create(SegmentDTO dto)
        {           
            if(!this.get_DB().Segment.Where( i => i.dataModelNummer == dto.dataModelNummer &&
                                             i.feitTypeCode == dto.feitTypeCode &&
                                             i.segmentNummer == dto.segmentNummer).Any())
            {
                base.create(dto);
            }
            else
            {
                foreach(var segDeel in dto.SegmentDeel)
                {
                    if(!this.get_DB().SegmentDeel.Where(    i => i.dataModelNummer == segDeel.dataModelNummer &&
                                                            i.feitTypeCode == segDeel.feitTypeCode &&
                                                            i.segmentNummer == segDeel.segmentNummer &&
                                                            i.segmentDeelnummer == segDeel.segmentDeelNummer).Any())
                    {
                        addNewSegmentDeel(segDeel);
                    }
                }
            }
        }

        private void addNewSegmentDeel(SegmentDeelDTO segmentDeelDTO)
        {
            using (var db = new FO_ERMEntities1())
            {
                DTOMapper<SegmentDeel, SegmentDeelDTO> segmentDeelMapper = new DTOMapper<SegmentDeel, SegmentDeelDTO>();
                db.SegmentDeel.Add(segmentDeelMapper.mapDTOToEntity(segmentDeelDTO));
                db.SaveChanges();
            }
        }

    }
}
