using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.datasource;
using FO_ERM_ISE.dependencyManager;
using FO_ERM_ISE.domain;

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

        public List<DatamodelDTO> getAllDatamodels()
        {
            return this.dmDatasource.GetAll();
        }

        public void addDatamodel(DatamodelDTO datamodel)
        {
            try
            {
                this.dmDatasource.Create(datamodel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void deleteDataModel(DatamodelDTO datamodel)
        {
            try
            {
                this.dmDatasource.Delete(datamodel);               
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void updateDataModel(DatamodelDTO datamodel)
        {
            try
            {
                this.dmDatasource.Update(datamodel);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
