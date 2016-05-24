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
            dmDatasource = depman.getISegmentDatasource();
        }

        public void addSegment(SegmentDTO segment)
        {
            this.dmDatasource.Create(segment);
        }

        public void deleteSegment(SegmentDTO segment)
        {
            this.dmDatasource.Delete(segment);
        }

        public List<SegmentDTO> getAllSegmentenOnFacttype(FacttypeDTO facttype)
        {
            return this.dmDatasource.getAllSegmentenOnFacttype(facttype);
        }

        public void updateSegment(SegmentDTO segment)
        {
            this.dmDatasource.Update(segment);
        }
    }
}
