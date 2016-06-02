using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    class SegmentDatasource : Datasource<Segment, SegmentDTO>, ISegmentDatasource
    {
        private DTOMapper<SegmentDeel, SegmentDeelDTO> segmentDeelMapper = new DTOMapper<SegmentDeel, SegmentDeelDTO>();

        public List<SegmentDTO> GetAllSegmentenOnFacttype(FacttypeDTO facttype)
        {
            using (Db = new FO_ERMEntities1())
            {
                List<Segment> factTypes = Db.Segment.Where(i => i.feitTypeCode == facttype.feitTypeCode && i.dataModelNummer == facttype.dataModelNummer).ToList();
                return this.dtoMapper.MapEntitiesToDTOs(factTypes);
            }
        }        

        public SegmentDTO getSegmentOnSegmentNummer(int segmentNumber, int datamodelNumber, string factTypeCode)
        {
            using (Db = new FO_ERMEntities1())
            {
                Segment segment = Db.Segment.Where(i => i.segmentNummer == segmentNumber && i.dataModelNummer == datamodelNumber && i.feitTypeCode == factTypeCode).FirstOrDefault();
                return this.dtoMapper.mapEntityToDTO(segment);
            }
        }

        public void addNewSegmentDeel(SegmentDeelDTO segmentDeelDTO)
        {
            using (var db = new FO_ERMEntities1())
            {               
                db.SegmentDeel.Add(segmentDeelMapper.MapDTOToEntity(segmentDeelDTO));
                db.SaveChanges();
            }
        }

        public void deleteSegmentDeel(SegmentDeelDTO segmentDeelDTO)
        {
            using (var db = new FO_ERMEntities1())
            {
                db.SegmentDeel.Remove(segmentDeelMapper.MapDTOToEntity(segmentDeelDTO));
                db.SaveChanges();
            }
        }

    }
}
