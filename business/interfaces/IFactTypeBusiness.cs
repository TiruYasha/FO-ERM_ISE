using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.business.interfaces
{
    interface IFactTypeBusiness
    {
        List<FacttypeDTO> getAllFactTypes();
        void addFactType(FacttypeDTO factType);
        void deleteFactType(FacttypeDTO factType);
        void updateFactType(FacttypeDTO factType);
        List<FacttypeDTO> getAllFactTypesOnDatamodel(DatamodelDTO datamodel);
    }
}
