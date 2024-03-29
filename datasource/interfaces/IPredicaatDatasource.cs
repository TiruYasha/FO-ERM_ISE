﻿using FO_ERM_ISE.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO_ERM_ISE.datasource.interfaces
{
    interface IPredicaatDatasource : IDatasource<PredicaatDeel, PredicaatDeelDTO>
    {
        void AddPredicaatDelen(List<PredicaatDeelDTO> predicaten);
    }
}
