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
            SegmentDTO sdto = this.dmDatasource.getSegmentOnSegmentNummer(segment.segmentNummer, segment.dataModelNummer, segment.feitTypeCode);
            
            if(sdto == null)
            {
                this.dmDatasource.Create(segment);
            }
            else
            {
                List<SegmentDeelDTO> newSegmentDelen = segment.SegmentDeel.Where(i => i.segmentDeelNummer > sdto.SegmentDeel.Max(x => x.segmentDeelNummer)).ToList();
                foreach(var i in newSegmentDelen)
                {
                    this.dmDatasource.addNewSegmentDeel(i);
                }
            }
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

        public SegmentDTO getSegmentOnSegmentNummer(int segmentNumber, int datamodelNumber, string factTypeCode)
        {
            return this.dmDatasource.getSegmentOnSegmentNummer(segmentNumber, datamodelNumber, factTypeCode);
        }
    }
}
