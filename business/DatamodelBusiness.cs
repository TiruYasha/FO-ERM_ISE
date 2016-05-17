using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.datasource;
using FO_ERM_ISE.dependencyManager;

namespace FO_ERM_ISE.business
{
    class DatamodelBusiness : IDatamodelBusiness
    {
        public IDatamodelDatasource dmDatasource;       

        public DatamodelBusiness()
        {
            DependencyManager depman = new DependencyManager();
            dmDatasource = depman.getIDatamodelDatasource();
        }

        public DataModel getDataModelOnId(int datamodelNumber)
        {
            return this.dmDatasource.getDataModelOnId(datamodelNumber);
        }

        public List<DataModel> getAllDatamodels()
        {
            return this.dmDatasource.getAllDatamodels();
        }

        public void addDatamodel(DataModel datamodel)
        {
            try
            {
                this.dmDatasource.addDatamodel(datamodel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void deleteDataModel(DataModel datamodel)
        {
            try
            {
                this.dmDatasource.deleteDataModel(datamodel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void updateDataModel()
        {
            try
            {
                this.dmDatasource.updateDataModel();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
