using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Writer : IEntity
    {
        public int Id { get; set; }
        public string? WriterName { get; set; }
        public string? WriterDescription { get; set; }
    }
}
