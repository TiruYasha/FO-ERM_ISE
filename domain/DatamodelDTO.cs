using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    class DatamodelDTO
    {
        public int dataModelNumber { get; set; }
        public string dataModelName { get; set; }
        public List<FacttypeDTO> facttypes { get; set; }

        public void addFacttype(FacttypeDTO facttype)
        {
            facttypes.Add(facttype);
        }

        public void addFacttypes(List<FacttypeDTO> facttypes)
        {
            this.facttypes.AddRange(facttypes);
        }
    }
}
