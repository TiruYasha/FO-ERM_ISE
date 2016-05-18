using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.datasource.interfaces;
using System.Data;
using System.Data.Entity;
using AutoMapper;

namespace FO_ERM_ISE.datasource
{
    abstract class Datasource<T, T2> : IDatasource<T, T2>   where T : class where T2 : class
    {
        /*
         * If possible transfer mapping to own function or even own class!
         */

        protected static FO_ERMEntities1 _DB;
        protected DbSet _dbset;

        public Datasource()
        {
            if(_DB == null)
            {
                _DB = new FO_ERMEntities1();
            }

            _dbset = _DB.Set<T>();
        }

        public FO_ERMEntities1 get_DB()
        {
            return _DB;
        }

        public virtual void Create(T2 dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("entity");
            }
            T entity = Program.mapper.Map<T>(dto);

            _dbset.Add(entity);
            _DB.SaveChanges();
        }


        public virtual void Update(T2 dto)
        {
            if (dto == null) throw new ArgumentNullException("entity");
            T entity = Program.mapper.Map<T>(dto);

            _DB.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _DB.SaveChanges();
        }

        public virtual void Delete(T2 dto)
        {
            if (dto == null) throw new ArgumentNullException("entity");
            T entity = Program.mapper.Map<T>(dto);

            _dbset.Remove(entity);
            _DB.SaveChanges();
        }

        public virtual List<T2> GetAll() 
        {
            List<T> objects = _DB.Set<T>().ToList();
            List<T2> dtos = Program.mapper.Map<List<T>, List<T2>>(objects);

            return dtos;
        }
    }
}
