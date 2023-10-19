using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.BannedUsers
{
    public class AddBanDto:IDto
    {
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
