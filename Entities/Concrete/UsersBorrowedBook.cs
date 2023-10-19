using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UsersBorrowedBook : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public bool Status { get; set; }

    }
}
