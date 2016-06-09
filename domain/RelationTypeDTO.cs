using System.Collections.Generic;
using System.Windows.Forms;

namespace FO_ERM_ISE.domain
{
    public class RelationTypeDTO
    {
        public RelationTypeDTO()
        {
            RelatieTypeOnderdeel = new List<RelationTypePartDTO>();
        }

        public string relatieTypeNaam { get; set; }
        public int dataModelNummer { get; set; }
        public string feitTypeCode { get; set; }

        public DatamodelDTO DatamodelDto { get; set; }
        public FacttypeDTO FacttypeDto { get; set; }
        public List<RelationTypePartDTO> RelatieTypeOnderdeel { get; set; }
        
    }
}