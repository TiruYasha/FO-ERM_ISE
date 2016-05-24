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
        public IDatamodelDatasource getIDatamodelDatasource()
        {
            return new DatamodelDatasource();
        }

        public IDatamodelBusiness getIDatamodelBusiness()
        {
            return new DatamodelBusiness();
        }

        public IFacttypeDatasource getIFactTypeDatasource()
        {
            return new FacttypeDatasource();
        }

        public IFactTypeBusiness getIFactTypeBusiness()
        {
            return new FactTypeBusiness();
        }

        public ISegmentBusiness getISegmentBusiness()
        {
            return new SegmentBusiness();
        }

        public ISegmentDatasource getISegmentDatasource()
        {
            return new SegmentDatasource();
        }
    }
}
