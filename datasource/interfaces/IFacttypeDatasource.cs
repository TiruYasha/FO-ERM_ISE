using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.datasource
{
    interface IFacttypeDatasource
    {
        FacttypeDTO getFacttypeOnId(String factCode, int datamodelNumber);
        List<FacttypeDTO> getAllOnDatamodelNumber(int datamodelNumber);
        void addFacttype(FacttypeDTO facttype);
        void deleteFacttype(FacttypeDTO facttype);
        void updateFacttype(FacttypeDTO factype);
    }
}
