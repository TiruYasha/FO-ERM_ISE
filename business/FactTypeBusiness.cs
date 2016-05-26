using FO_ERM_ISE.business.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.datasource;
using FO_ERM_ISE.dependencyManager;

namespace FO_ERM_ISE.business
{
    class FactTypeBusiness : IFactTypeBusiness
    {
        private IFacttypeDatasource ftDatasource;

        public FactTypeBusiness()
        {
            DependencyManager depman = new DependencyManager();
            this.ftDatasource = depman.GetIFactTypeDatasource();
        }

        public List<FacttypeDTO> GetAllFactTypes()
        {
            return ftDatasource.GetAll();
        }

        public void AddFactType(FacttypeDTO factType)
        {
            try
            {
                ftDatasource.Create(factType);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void DeleteFactType(FacttypeDTO factType)
        {
            try
            {
                ftDatasource.Delete(factType);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void UpdateFactType(FacttypeDTO factType)
        {
            try
            {
                ftDatasource.Update(factType);
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public List<FacttypeDTO> GetAllFactTypesOnDatamodel(DatamodelDTO datamodel)
        {
            return ftDatasource.GetAllFactTypesOnDatamodel(datamodel);
        }
    }
}
