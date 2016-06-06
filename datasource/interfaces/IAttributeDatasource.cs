using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource.interfaces
{
    interface IAttributeDatasource : IDatasource<Attribuut, AttributeDTO>
    {
        List<AttributeDTO> GetAttributesOnEntityTypeNumber(int entityTypeNumber);
        AttributeDTO GetAttributeOnAttributeNumber(int attributeNumber);
        new int Create(AttributeDTO dto);
    }
}
