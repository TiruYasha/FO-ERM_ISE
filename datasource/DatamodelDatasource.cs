﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.datasource
{
    class DatamodelDatasource : Datasource, IDatamodelDatasource
    {
        private FO_ERMEntities1 _DB;

        public DatamodelDatasource()
        {
            _DB = get_DB();
        }

        public DataModel getDataModelOnId(int datamodelNumber)
        {
            return _DB.DataModel.Where(i => i.dataModelNummer == datamodelNumber).Single();
        }

        public List<DataModel> getAllDatamodels()
        {
            try
            {
                return _DB.DataModel.ToList();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void addDatamodel(DataModel datamodel)
        {
            try
            {
                _DB.DataModel.Add(datamodel);
                this.save();
            }
            catch(Exception e)
            {
                _DB.DataModel.Remove(datamodel);
                throw e;
            }
        }

        public void deleteDataModel(DataModel datamodel)
        {
            try
            {
                _DB.DataModel.Remove(datamodel);
                this.save();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void updateDataModel()
        {
            try
            {
                this.save();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
