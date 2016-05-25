using FO_ERM_ISE.datasource.interfaces;
using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource
{
    class SegmentDatasource : Datasource<Segment, SegmentDTO>, ISegmentDatasource
    {
        public List<SegmentDTO> getAllSegmentenOnFacttype(FacttypeDTO facttype)
        {
            throw new NotImplementedException();
        }

        public void Create(SegmentDTO segment)
        {
            // roep sp aan

            // voeg extra segmentdelen toe aan db 

            throw new NotImplementedException();
        }

    }
}
