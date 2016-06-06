using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource.interfaces
{
    interface IEntitytypeDatasource : IDatasource<EntiteitType, EntiteittypeDTO>
    {
        EntiteittypeDTO GetEntitytypeOnEntityTypeNumber(int entityTypeNumber);
        List<EntiteittypeDTO> GetEntitytypeOnDataModel(int dataModelNumber);
        new int Create(EntiteittypeDTO dto);
    }
}
