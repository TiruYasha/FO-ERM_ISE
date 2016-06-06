using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.business.interfaces
{
    public interface IEntitytypeBusiness
    {
        List<EntiteittypeDTO> GetEntitytype();
        List<EntiteittypeDTO> GetEntitytypeOnDataModel(int dataModelNumber);
        EntiteittypeDTO GetEntitytypeOnEntityTypeNumber(int entityTypeNumber);
        int AddEntiteittype(EntiteittypeDTO entiteitype);
        void DeleteEntiteittype(EntiteittypeDTO entiteitype);
        void UpdateEntiteittype(EntiteittypeDTO entiteitype);
    }
}
