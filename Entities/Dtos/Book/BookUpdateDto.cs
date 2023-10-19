using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Book
{
    public class BookUpdateDto : IDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public int WriterId { get; set; }
        [Required]
        public int BookPageCount { get; set; }
        [Required]
        public int PublisherId { get; set; }
    }
}
