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
        List<DatamodelDTO> GetAllDatamodels();
        void AddDatamodel(DatamodelDTO datamodel);
        void DeleteDataModel(DatamodelDTO datamodel);
        void UpdateDataModel(DatamodelDTO datamodel);
    }
}
