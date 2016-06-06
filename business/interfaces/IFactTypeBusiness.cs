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
        List<FacttypeDTO> GetAllFactTypes();
        void AddFactType(FacttypeDTO factType);
        void DeleteFactType(FacttypeDTO factType);
        void UpdateFactType(FacttypeDTO factType);
        List<FacttypeDTO> GetAllFactTypesOnDatamodel(DatamodelDTO datamodel);
        void verifyFactType(FacttypeDTO factType);
    }
}
