using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.business.interfaces
{
    interface IDatamodelBusiness
    {
        DataModel getDataModelOnId(int datamodelNumber);
        List<DataModel> getAllDatamodels();
        void addDatamodel(DataModel datamodel);
        void deleteDataModel(DataModel datamodel);
        void updateDataModel();
    }
}
