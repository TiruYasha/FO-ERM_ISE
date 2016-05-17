﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.datasource
{
    interface IDatamodelDatasource
    {
        DataModel getDataModelOnId(int datamodelNumber);
        List<DataModel> getAllDatamodels();
        void addDatamodel(DataModel datamodel);
        void deleteDataModel(DataModel datamodel);
        void updateDataModel();
    }
}
