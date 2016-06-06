using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    class AttributeDatasource : Datasource<Attribuut, AttributeDTO>, IAttributeDatasource
    {
        public AttributeDTO GetAttributeOnAttributeNumber(int attributeNumber)
        {
            using (Db = new FO_ERMEntities1())
            {
                Attribuut objectA =
                    this.Db.Attribuut.Where(i => i.attribuutNummer == attributeNumber).FirstOrDefault();
                AttributeDTO dto = Program.mapper.Map<Attribuut, AttributeDTO>(objectA);

                return dto;
            }
        }

        public List<AttributeDTO> GetAttributesOnEntityTypeNumber(int entityTypeNumber)
        {
            using (Db = new FO_ERMEntities1())
            {
                List<Attribuut> objects =
                    this.Db.Attribuut.Where(i => i.entiteitTypeNummer == entityTypeNumber).ToList();
                List<AttributeDTO> dtos = Program.mapper.Map<List<Attribuut>, List<AttributeDTO>>(objects);

                return dtos;
            }
        }


        public new int Create( AttributeDTO dto)
        {
            using (Db = new FO_ERMEntities1())
            {
                try
                {
                    if (dto == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    Attribuut entity = dtoMapper.MapDTOToEntity(dto);

                    Dbset.Add(entity);
                    Db.SaveChanges();

                    return entity.attribuutNummer;
                }
                catch (Exception dbEx)
                {
                    throw dbEx;
                }
            }
        }


    }
}
