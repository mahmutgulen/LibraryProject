using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UnnecessaryInfos
{
    public class HowManyDaysLeftDto: IDto
    {
        public string? BookName { get; set; }
        public TimeSpan Time { get; set; }
    }
}
