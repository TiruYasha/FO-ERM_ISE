using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.dependencyManager;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.business
{
    public class RelationTypeBusiness : IRelationTypeBusiness
    {
        private IRelationTypeDataSource rtDatasource;

        public RelationTypeBusiness()
        {
            DependencyManager depman = new DependencyManager();
            rtDatasource = depman.GetIRelationTypeDataSource();
        }

        public List<RelationTypeDTO> GetAllRelationTypes()
        {
            List<RelationTypeDTO> relationTypes = rtDatasource.GetAll();

            return relationTypes;
        }

        public void AddRelationType(RelationTypeDTO relationTypeDto)
        {
            rtDatasource.Create(relationTypeDto);
        }

        public void DeleteRelationType(RelationTypeDTO relationTypeDto)
        {
            rtDatasource.Delete(relationTypeDto);
        }

        public void UpdateRelationType(RelationTypeDTO relationTypeDto)
        {
            rtDatasource.Update(relationTypeDto);
        }
    }
}
