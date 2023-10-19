using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BannedUser : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime BannedDateTime { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public bool Status { get; set; }
    }
}
