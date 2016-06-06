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
    public class EntitytypeBusiness : IEntitytypeBusiness
    {

        private IEntitytypeDatasource datasource;

        public EntitytypeBusiness()
        {
            DependencyManager dp = new DependencyManager();
            datasource = dp.GetIEntitytypeDatasource();
        }

        public int AddEntiteittype(EntiteittypeDTO entiteitype)
        {
            return datasource.Create(entiteitype);
        }

        public void DeleteEntiteittype(EntiteittypeDTO entiteitype)
        {
            datasource.Delete(entiteitype);
        }

        public List<EntiteittypeDTO> GetEntitytype()
        {
            return datasource.GetAll();
        }

        public List<EntiteittypeDTO> GetEntitytypeOnDataModel(int dataModelNumber)
        {
            return datasource.GetEntitytypeOnDataModel(dataModelNumber);
        }

        public EntiteittypeDTO GetEntitytypeOnEntityTypeNumber(int entityTypeNumber)
        {
            return datasource.GetEntitytypeOnEntityTypeNumber(entityTypeNumber);
        }

        public void UpdateEntiteittype(EntiteittypeDTO entiteitype)
        {
            datasource.Update(entiteitype);
        }

    }
}
