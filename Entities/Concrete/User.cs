using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? UserAddress { get; set; }
        public string? UserIdentityNumber { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ClosedDateTime { get; set; }
        public int Status { get; set; }
    }
}
