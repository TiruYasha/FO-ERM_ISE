using FO_ERM_ISE;
using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{

    class EntitytypeDatasource : Datasource<EntiteitType, EntiteittypeDTO>, IEntitytypeDatasource
    {
        public List<EntiteittypeDTO> GetEntitytypeOnDataModel(int dataModelNumber)
        {
            using (Db = new FO_ERMEntities1())
            {

                List<EntiteitType> objects =
                    this.Db.EntiteitType.Where(i => i.dataModelNummer == dataModelNumber).ToList();
                List<EntiteittypeDTO> dtos = Program.mapper.Map<List<EntiteitType>, List<EntiteittypeDTO>>(objects);

                return dtos;
            }
        }

        public EntiteittypeDTO GetEntitytypeOnEntityTypeNumber(int entityTypeNumber)
        {
            using (Db = new FO_ERMEntities1())
            {

                EntiteitType objects =
                    this.Db.EntiteitType.Where(i => i.entiteitTypeNummer == entityTypeNumber).First();
                EntiteittypeDTO dtos = Program.mapper.Map<EntiteitType, EntiteittypeDTO>(objects);

                return dtos;
            }
        }

        public new int Create(EntiteittypeDTO dto)
        {
            using (Db = new FO_ERMEntities1())
            {
                try
                {
                    if (dto == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    EntiteitType entity = dtoMapper.MapDTOToEntity(dto);

                    Dbset.Add(entity);
                    Db.SaveChanges();

                    return entity.entiteitTypeNummer;
                }
                catch (Exception dbEx)
                {
                    throw dbEx;
                }
            }
        }

    }
}
