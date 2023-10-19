using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.BusinessPanel
{
    public class BorrowedListDto : IDto
    {
        public int UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? BookName { get; set; }
        public DateTime BorrowedDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
    }
}
