using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UnnecessaryInfos
{
    public class MostBookReadUser : IDto
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int UserReadBookCount { get; set; }
    }
}
