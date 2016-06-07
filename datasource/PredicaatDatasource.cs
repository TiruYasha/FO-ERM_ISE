using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    class PredicaatDatasource : Datasource<PredicaatDeel, PredicaatDeelDTO>, IPredicaatDatasource
    {
        public void AddPredicaatDelen(List<PredicaatDeelDTO> predicaten)
        {
            using (Db = new FO_ERMEntities1())
            {
                List<PredicaatDeel> predicaatEntiteiten = dtoMapper.MapDTOsToEntities(predicaten);
                foreach(var predicaatDeel in predicaatEntiteiten)
                {
                    DbSet dbset = Db.Set<PredicaatDeel>();
                    dbset.Attach(predicaatDeel);
                    Db.Entry(predicaatDeel).State = EntityState.Added;
                }
                Db.SaveChanges();
            }
        }
    }
}
