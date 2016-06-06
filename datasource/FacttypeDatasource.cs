using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    class FacttypeDatasource : Datasource<FeitType, FacttypeDTO>, IFacttypeDatasource 
    {
        public List<FacttypeDTO> GetAllFactTypesOnDatamodel(DatamodelDTO datamodel)
        {
            using (Db = new FO_ERMEntities1())
            {
                DataModel entity = Program.mapper.Map<DataModel>(datamodel);

                List<FeitType> objects =
                    this.Db.FeitType.Where(i => i.dataModelNummer == entity.dataModelNummer).ToList();
                List<FacttypeDTO> dtos = Program.mapper.Map<List<FeitType>, List<FacttypeDTO>>(objects);

                return dtos;
            }
        }

        public void verifyFactType(FacttypeDTO factType)
        {
            using (Db = new FO_ERMEntities1())
            {
                try
                {
                    Db.spr_FactTypeValidation(factType.dataModelNummer, factType.feitTypeCode);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
