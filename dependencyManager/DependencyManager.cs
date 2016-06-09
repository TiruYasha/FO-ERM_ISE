using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.datasource;
using FO_ERM_ISE.business;
using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.datasource.interfaces;

namespace FO_ERM_ISE.dependencyManager
{
    class DependencyManager
    {
        public IDatamodelDatasource GetIDatamodelDatasource()
        {
            return new DatamodelDatasource();
        }

        public IDatamodelBusiness GetIDatamodelBusiness()
        {
            return new DatamodelBusiness();
        }

        public IFacttypeDatasource GetIFactTypeDatasource()
        {
            return new FacttypeDatasource();
        }

        public IFactTypeBusiness GetIFactTypeBusiness()
        {
            return new FactTypeBusiness();
        }

        public ISegmentBusiness GetISegmentBusiness()
        {
            return new SegmentBusiness();
        }

        public ISegmentDatasource GetISegmentDatasource()
        {
            return new SegmentDatasource();
        }

        public IRelationTypeDataSource GetIRelationTypeDataSource()
        {
            return new RelationTypeDataSource();
        }

        public IRelationTypeBusiness GetIRelationTypeBusiness()
        {
            return new RelationTypeBusiness();
        }

        public IEntitytypeBusiness GetIEntitytypeBusiness()
        {
            return new EntitytypeBusiness();
        }

        public IEntitytypeDatasource GetIEntitytypeDatasource()
        {
            return new EntitytypeDatasource();
        }

        public IAttributeBusiness GetIAttributeBusiness()
        {
            return new AttributeBusiness();
        }

        public IAttributeDatasource GetIAttributeDatasource()
        {
            return new AttributeDatasource();
        }

        public IPredicaatBusiness getIPredicaatBusiness()
        {
            return new PredicaatBusiness();
        }
        
        public IPredicaatDatasource getIPredicaatDatasource()
        {
            return new PredicaatDatasource();
        }
    }
}
