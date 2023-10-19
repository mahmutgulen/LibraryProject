using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.BannedUsers
{
    public class BannedUserListDto:IDto
    {
        public int UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? Description { get; set; }
        public DateTime BannedDateTime { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public bool Status { get; set; }
    }
}
