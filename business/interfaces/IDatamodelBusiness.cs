using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.business.interfaces
{
    interface IDatamodelBusiness
    {
        List<DatamodelDTO> getAllDatamodels();
        void addDatamodel(DatamodelDTO datamodel);
        void deleteDataModel(DatamodelDTO datamodel);
        void updateDataModel(DatamodelDTO datamodel);
    }
}
