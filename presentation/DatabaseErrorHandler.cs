using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.presentation
{
    class DatabaseErrorHandler
    {
        public string ParseErrorMessage(Exception e)
        {
            while (e.InnerException != null)
            {
                e = e.InnerException;
            }

            return e.Message;           
        }
    }
}
