using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.business.interfaces
{
    interface ISegmentBusiness
    {
        List<SegmentDTO> GetAllSegmentenOnFacttype(FacttypeDTO facttype);
        void AddSegment(SegmentDTO segment);
        void DeleteSegment(SegmentDTO segment);
        void UpdateSegment(SegmentDTO segment);
        SegmentDTO getSegmentOnSegmentNummer(int segmentNumber, int datamodelNumber, string factTypeCode);
    }
}