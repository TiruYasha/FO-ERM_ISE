using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.datasource.interfaces;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using AutoMapper;

namespace FO_ERM_ISE.datasource
{
    abstract class Datasource<T, T2> : IDatasource<T, T2>   where T : class where T2 : class
    {
        public  DTOMapper<T, T2> dtoMapper;
        protected FO_ERMEntities1 Db { get; set; }

        protected DbSet<T> Dbset
        {
            get { return Db.Set<T>(); }
        }

        protected Datasource()
        {
            this.dtoMapper = new DTOMapper<T, T2>();
        }

        public virtual void Create(T2 dto)
        {
            using (Db = new FO_ERMEntities1()) 
            {
                try
                {
                    if (dto == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    T entity = dtoMapper.MapDTOToEntity(dto);

                    Dbset.Add(entity);
                    Db.SaveChanges();
                }
                catch (Exception dbEx)
                {
                    throw dbEx;
                }
            }
        }

        public virtual void Update(T2 dto)
        {
            using (Db = new FO_ERMEntities1())
            {
                try
                {
                    if (dto == null) throw new ArgumentNullException("entity");
                    T entity = dtoMapper.MapDTOToEntity(dto);

                    Dbset.Attach(entity);
                    Db.Entry(entity).State = EntityState.Modified;
                    Db.SaveChanges();
                }
                catch (Exception dbEx)
                {
                    throw dbEx;
                }
            }
        }

        public virtual void Delete(T2 dto)
        {
            using (Db = new FO_ERMEntities1())
            {
                try
                {
                    if (dto == null) throw new ArgumentNullException("entity");
                    T entity = dtoMapper.MapDTOToEntity(dto);

                    Dbset.Attach(entity);
                    Dbset.Remove(entity);

                    Db.SaveChanges();
                }
                catch (Exception dbEx)
                {
                    throw dbEx;
                }
            }
        }

        public virtual List<T2> GetAll() 
        {
            using (Db = new FO_ERMEntities1())
            {
                List<T> objects = Dbset.ToList(); 
                List<T2> dtos = dtoMapper.MapEntitiesToDTOs(objects);
            
                return dtos;
            }
        }
    }
}
