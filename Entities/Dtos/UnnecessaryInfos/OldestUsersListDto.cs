using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UnnecessaryInfos
{
    public class OldestUsersListDto : IDto
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public DateTime UserRegisterDateTime { get; set; }
    }
}
