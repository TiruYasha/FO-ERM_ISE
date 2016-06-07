using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.business
{
    class PredicaatBusiness : IPredicaatBusiness
    {
        private IPredicaatDatasource pDatasource;

        public PredicaatBusiness()
        {
            dependencyManager.DependencyManager depman = new dependencyManager.DependencyManager();
            this.pDatasource = depman.getIPredicaatDatasource();
        }

        public void AddPredicaatDelen(List<PredicaatDeelDTO> predicaten)
        {
            try
            {
                this.pDatasource.AddPredicaatDelen(predicaten);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
