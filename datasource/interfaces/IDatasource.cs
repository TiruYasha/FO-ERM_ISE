using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource.interfaces
{
    interface IDatasource<T, T2>    where T : class where T2 : class
    {
        void create(T2 entity);
        void update(T2 entity);
        List<T2> getAll();
        void delete(T2 entity);
    }
}
