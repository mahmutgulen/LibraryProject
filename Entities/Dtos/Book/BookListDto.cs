using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Book
{
    public class BookListDto : IDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int WriterId { get; set; }
        public int BookPageCount { get; set; }
        public int PublisherId { get; set; }
        public int ReadCount { get; set; }
        public DateTime AddedDateTime { get; set; }
        public int Status { get; set; }
    }
}
