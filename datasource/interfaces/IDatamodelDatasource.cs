using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.datasource
{
    interface IDatamodelDatasource
    {
        public DatamodelDTO getDataModelOnId(int datamodelNumber);
        public List<DatamodelDTO> getAllDatamodels();
        public void addDatamodel(DatamodelDTO datamodel);
        public void deleteDataModel(DatamodelDTO datamodel);
        public void updateDataModel(DatamodelDTO datamodel);
    }
}
