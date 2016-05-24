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
        private FO_ERMEntities1 _db;

        protected FO_ERMEntities1 Db
        {
            get
            {
                return _db ?? new FO_ERMEntities1();
            }
        }

        protected DbSet Dbset
        {
            get { return Db.Set<T>(); }
        }

        protected Datasource()
        {
            //Db = new FO_ERMEntities1();
        }
        
        public FO_ERMEntities1 get_DB()
        {
            return Db;
        }

        public virtual void Create(T2 dto)
        {
            using (var db = new FO_ERMEntities1()) { 
                if (dto == null)
                {
                    throw new ArgumentNullException("entity");
                }
                T entity = Program.mapper.Map<T>(dto);

                db.Set<T>().Add(entity);
                db.SaveChanges();
            }
        }


        public virtual void Update(T2 dto)
        {
            using (var db = new FO_ERMEntities1())
            {
                if (dto == null) throw new ArgumentNullException("entity");
                T entity = Program.mapper.Map<T>(dto);

                db.Set<T>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();

               /* Dbset.Attach(entity);
                Db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();*/
            }
        }

        public virtual void Delete(T2 dto)
        {
            using (var db = new FO_ERMEntities1())
            {
                if (dto == null) throw new ArgumentNullException("entity");
                T entity = Program.mapper.Map<T>(dto);

                db.Set<T>().Attach(entity);
                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }

        public virtual List<T2> GetAll() 
        {
            using (Db)
            {
                List<T> objects = Db.Set<T>().ToList();
                List<T2> dtos = Program.mapper.Map<List<T>, List<T2>>(objects);
            
            return dtos;
            }
        }
    }
}
