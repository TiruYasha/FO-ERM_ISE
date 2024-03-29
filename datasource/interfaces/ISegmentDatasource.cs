﻿using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource.interfaces
{
    interface ISegmentDatasource : IDatasource<Segment, SegmentDTO>
    {
        List<SegmentDTO> GetAllSegmentenOnFacttype(FacttypeDTO facttype);
        SegmentDTO getSegmentOnSegmentNummer(int segmentNumber, int datamodelNumber, string factTypeCode);
        void addNewSegmentDeel(SegmentDeelDTO segmentDeelDTO);
        void deleteSegmentDeel(SegmentDeelDTO segmentDeelDTO);
    }
}
