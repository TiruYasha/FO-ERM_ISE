using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    public class DatamodelDTO
    {
        public int dataModelNummer { get; set; }
        public string dataModelNaam { get; set; }
        public List<FacttypeDTO> FeitType { get; set; }

        public void addFacttype(FacttypeDTO facttype)
        {
            FeitType.Add(facttype);
        }

        public void addFacttypes(List<FacttypeDTO> facttypes)
        {
            this.FeitType.AddRange(facttypes);
        }
    }
}
