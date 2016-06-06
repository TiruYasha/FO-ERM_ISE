using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.business.interfaces
{
    public interface IAttributeBusiness
    {
        AttributeDTO GetAttributeOnAttributeNumber(int attributeNumber);
        List<AttributeDTO> GetAttributesOnEntityTypeNumber(int entityTypeNumber);
        int AddAttribute(AttributeDTO attribute);
        void DeleteAttribute(AttributeDTO attribute);
        void UpdateAttribute(AttributeDTO attribute);
    }
}
