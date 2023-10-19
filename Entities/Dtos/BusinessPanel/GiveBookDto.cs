using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.BusinessPanel
{
    public class GiveBookDto:IDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
