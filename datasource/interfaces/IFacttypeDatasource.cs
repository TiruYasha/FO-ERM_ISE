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
        public FacttypeDTO getFacttypeOnId(String factCode, int datamodelNumber);
        public List<FacttypeDTO> getAllOnDatamodelNumber(int datamodelNumber);
        public void addFacttype(FacttypeDTO facttype);
        public void deleteFacttype(FacttypeDTO facttype);
        public void updateFacttype(FacttypeDTO factype);
    }
}
