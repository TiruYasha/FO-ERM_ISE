using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.domain
{
    class FacttypeDTO
    {
        public string feitTypeCode { get; set; }
        public int dataModelNummer { get; set; }
        public string verwoording { get; set; }
        public DatamodelDTO DataModel { get; set; }
    }
}
