using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    abstract class Datasource
    {
        protected static FO_ERMEntities1 _DB;

        public Datasource()
        {
            if(_DB == null)
            {
                _DB = new FO_ERMEntities1();
            }
        }

        public FO_ERMEntities1 get_DB()
        {
            return _DB;
        }

        public void save()
        {
            try
            {
                _DB.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
