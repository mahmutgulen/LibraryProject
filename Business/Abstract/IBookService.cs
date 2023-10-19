using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        IResult AddBook(BookAddDto bookAddDto);
        IResult UpdateBook(BookUpdateDto bookUpdateDto);
        IResult DeleteBook(int bookId);

        IDataResult<List<BookListDto>> GetList();
        IDataResult<BookListDto> GetById(int bookId);

    }
}
