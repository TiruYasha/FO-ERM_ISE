using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource.interfaces
{
    interface IDatasource<T, T2> where T : class where T2 : class
    {
        void Create(T2 entity);
        void Update(T2 entity);
        List<T2> GetAll();
        void Delete(T2 entity);
    }
}
