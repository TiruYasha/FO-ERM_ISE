using FO_ERM_ISE.business.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;
using FO_ERM_ISE.dependencyManager;
using FO_ERM_ISE.datasource.interfaces;

namespace FO_ERM_ISE.business
{
    class AttributeBusiness : IAttributeBusiness
    {

        private IAttributeDatasource datasource;

        public AttributeBusiness()
        {
            DependencyManager dm = new DependencyManager();
            datasource = dm.GetIAttributeDatasource();
        }

        public int AddAttribute(AttributeDTO attribute)
        {
            return datasource.Create(attribute);
        }

        public void DeleteAttribute(AttributeDTO attribute)
        {
            datasource.Delete(attribute);
        }

        public AttributeDTO GetAttributeOnAttributeNumber(int attributeNumber)
        {
            return datasource.GetAttributeOnAttributeNumber(attributeNumber);
        }

        public List<AttributeDTO> GetAttributesOnEntityTypeNumber(int entityTypeNumber)
        {
            return datasource.GetAttributesOnEntityTypeNumber(entityTypeNumber);
        }

        public void UpdateAttribute(AttributeDTO attribute)
        {
            datasource.Update(attribute);
        }

        public List<AttributeDTO> getAttributeForPredicate(String FeitType, int datamodelNummer)
        {
            return datasource.getAttributeForPredicate("", datamodelNummer);
        }
    }
}
