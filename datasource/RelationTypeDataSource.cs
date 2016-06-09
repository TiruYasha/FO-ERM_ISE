using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.datasource
{
    class RelationTypeDataSource : Datasource<Relatietype, RelationTypeDTO>, IRelationTypeDataSource
    {
        public List<RelationTypeDTO> GetRelationTypeByDataModelFactType(int dataModelNumber, string factTypeCode)
        {
            using (Db = new FO_ERMEntities1())
            {
                List<Relatietype> relationTypes = Db.Relatietype.Where(rt => rt.feitTypeCode == factTypeCode && rt.dataModelNummer == dataModelNumber)
                    .ToList();

                List<RelationTypeDTO> relationTypesDto = dtoMapper.MapEntitiesToDTOs(relationTypes);

                return relationTypesDto;
            }

        }

        public void UpdateRelationTypeAndPart(RelationTypeDTO relationTypeDTO)
        {
            using (Db = new FO_ERMEntities1())
            {
                Relatietype relationType = dtoMapper.MapDTOToEntity(relationTypeDTO);

                foreach (var relationTypePart in relationType.RelatieTypeOnderdeel)
                {
                    Db.RelatieTypeOnderdeel.Attach(relationTypePart);
                    Db.Entry(relationTypePart).State = EntityState.Modified;
                }

                relationType.RelatieTypeOnderdeel = null;
                Db.Relatietype.Attach(relationType);
                Db.Entry(relationType).State = EntityState.Modified;

                Db.SaveChanges();
            }

        }
    }
}
