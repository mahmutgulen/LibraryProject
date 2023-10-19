using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
        public int BookPageCount { get; set; }
        //public int ReadCount { get; set; } // Bu kolon kaldırılıp yalnızca kitaplar listelenirken database üzerinden bu kayıt hesaplanabilir.
        public DateTime AddedDateTime { get; set; }
        public int Status { get; set; }
    }
}
