using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;
using FO_ERM_ISE.datasource.interfaces;

namespace FO_ERM_ISE.datasource
{
    interface IDatamodelDatasource : IDatasource<DataModel, DatamodelDTO>
    {       
        
    }
}
