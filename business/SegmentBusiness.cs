using FO_ERM_ISE.business.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO_ERM_ISE.domain;
using FO_ERM_ISE.datasource;
using FO_ERM_ISE.dependencyManager;
using FO_ERM_ISE.datasource.interfaces;

namespace FO_ERM_ISE.business
{
    class SegmentBusiness : ISegmentBusiness
    {
        public ISegmentDatasource dmDatasource;

        public SegmentBusiness()
        {
            DependencyManager depman = new DependencyManager();
            dmDatasource = depman.GetISegmentDatasource();
        }

        public void AddSegment(SegmentDTO segment)
        {
            this.dmDatasource.Create(segment);
        }

        public void DeleteSegment(SegmentDTO segment)
        {
            this.dmDatasource.Delete(segment);
        }

        public List<SegmentDTO> GetAllSegmentenOnFacttype(FacttypeDTO facttype)
        {
            return this.dmDatasource.GetAllSegmentenOnFacttype(facttype);
        }

        public void UpdateSegment(SegmentDTO segment)
        {
            this.dmDatasource.Update(segment);
        }
    }
}
