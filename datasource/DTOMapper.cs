using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    class DTOMapper<T, T2> where T : class where T2 : class
    {
        public T MapDTOToEntity(T2 dto)
        {
            T entity = Program.mapper.Map<T>(dto);
            return entity;
        }

        public List<T2> MapEntitiesToDTOs(List<T> entities)
        {
            return Program.mapper.Map<List<T>, List<T2>>(entities);
        }

        public T2 mapEntityToDTO(T entity)
        {
            return Program.mapper.Map<T2>(entity);
        }
    }
}
