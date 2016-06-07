using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;

namespace FO_ERM_ISE.datasource
{
    class DatamodelDatasource : Datasource<DataModel, DatamodelDTO>, IDatamodelDatasource
    {
        public override void Delete(DatamodelDTO dto)
        {
            using (Db = new FO_ERMEntities1())
            {
                var relatieTypen = Db.Relatietype.Where(i => i.dataModelNummer == dto.dataModelNummer).ToList();
                
                if(relatieTypen.Any())
                {
                    Db.Relatietype.RemoveRange(relatieTypen);
                }
                Db.SaveChanges();
                base.Delete(dto);
            }
        }
    }
}
