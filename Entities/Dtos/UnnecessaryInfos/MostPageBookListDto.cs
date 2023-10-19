﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UnnecessaryInfos
{
    public class MostPageBookListDto : IDto
    {
        public string? Name { get; set; }
        public int PageCount { get; set; }

    }
}
