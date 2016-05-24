﻿using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.business.interfaces
{
    interface ISegmentBusiness
    {
        List<SegmentDTO> getAllSegmentenOnFacttype(FacttypeDTO facttype);
        void addSegment(SegmentDTO segment);
        void deleteSegment(SegmentDTO segment);
        void updateSegment(SegmentDTO segment);
    }
}