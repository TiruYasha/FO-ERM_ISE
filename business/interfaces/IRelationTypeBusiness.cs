using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.business.interfaces
{
    interface IRelationTypeBusiness
    {
        List<RelationTypeDTO> GetAllRelationTypes();
        void AddRelationType(RelationTypeDTO relationTypeDto);
        void DeleteRelationType(RelationTypeDTO relationTypeDto);
        void UpdateRelationType(RelationTypeDTO relationTypeDto);
        List<RelationTypeDTO> GetRelationTypesByDataModelFactType(int dataModelNummer, string feitTypeCode);
        void UpdateRelationTypeAndParts(RelationTypeDTO relationTypeDTO);
    }
}
