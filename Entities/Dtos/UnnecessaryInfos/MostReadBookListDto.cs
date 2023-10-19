using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UnnecessaryInfos
{
    public class MostReadBookListDto : IDto
    {
        public string BookName { get; set; }
        public int ReadCount { get; set; }
        public List<Readers> readers { get; set; }

        public class Readers
        {
            public int UserId { get; set; }
            public string UserFullName { get; set; }
        }
    }
}
