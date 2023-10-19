using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos.Book;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;
        private IWriterDal _writerDal;
        private IPublisherDal _publisherDal;

        public BookManager(IBookDal bookDal, IWriterDal writerDal, IPublisherDal publisherDal)
        {
            _bookDal = bookDal;
            _writerDal = writerDal;
            _publisherDal = publisherDal;
        }

        public IResult AddBook(BookAddDto bookAddDto)
        {
            try
            {
                var bookExists = _bookDal.Get(x => x.BookName == bookAddDto.BookName && x.Status == 1);
                var writer = _writerDal.Get(x => x.Id == bookAddDto.WriterId);
                var publisher = _publisherDal.Get(x => x.Id == bookAddDto.PublisherId);
                if (bookExists != null)
                {
                    return new ErrorResult(Messages.BookAlreadyExists);
                }
                if (writer == null)
                {
                    return new ErrorResult(Messages.NotFoundWriter);
                }
                if (publisher == null)
                {
                    return new ErrorResult(Messages.NotFoundPublisher);
                }

                var book = new Book
                {
                    AddedDateTime = DateTime.Now,
                    BookName = bookAddDto.BookName,
                    BookPageCount = bookAddDto.BookPageCount,
                    WriterId = bookAddDto.WriterId,
                    PublisherId = bookAddDto.PublisherId,
                    Status = (int)BookStatusesEnum.Accessible
                };
                _bookDal.Add(book);
                return new SuccessResult(Messages.bookAdded);

            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IResult DeleteBook(int bookId)
        {
            try
            {
                var b = _bookDal.Get(x => x.BookId == bookId && x.Status == 1);
                if (b != null)
                {
                    var book = new Book
                    {
                        AddedDateTime = b.AddedDateTime,
                        BookName = b.BookName,
                        BookId = b.BookId,
                        BookPageCount = b.BookPageCount,
                        WriterId = b.WriterId,
                        PublisherId = b.PublisherId,
                        Status = (int)BookStatusesEnum.NotFound
                    };
                    _bookDal.Update(book);
                    return new SuccessResult(Messages.bookDeleted);
                }
                return new ErrorResult(Messages.bookNotFound);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IDataResult<BookListDto> GetById(int bookId)
        {
            try
            {
                LibraryContext _context = new LibraryContext();
                var ReadCount = _context.UsersBorrowedBooks.Distinct().Where(x => x.BookId == bookId).ToList();
                var book = _bookDal.Get(x => x.BookId == bookId);
                if (book == null)
                {
                    return new ErrorDataResult<BookListDto>(Messages.bookNotFound);
                }
                var dto = new BookListDto
                {
                    BookId = bookId,
                    AddedDateTime = book.AddedDateTime,
                    BookName = book.BookName,
                    BookPageCount = book.BookPageCount,
                    PublisherId = book.PublisherId,
                    ReadCount = ReadCount.Count,
                    Status = book.Status,
                    WriterId = book.WriterId
                };
                return new SuccessDataResult<BookListDto>(dto);
            }
            catch (Exception)
            {
                return new ErrorDataResult<BookListDto>(Messages.UnknownError);
            }
        }

        public IDataResult<List<BookListDto>> GetList()
        {
            try
            {
                LibraryContext _context = new LibraryContext();
                List<BookListDto> list = new List<BookListDto>();
                var book = _bookDal.GetList(x => x.Status == 1);
                if (book != null)
                {
                    foreach (var item in book)
                    {
                        var bookId = item.BookId;
                        var ReadCount = _context.UsersBorrowedBooks.Distinct().Where(x => x.BookId == bookId).ToList();

                        var bookDto = new BookListDto
                        {
                            AddedDateTime = item.AddedDateTime,
                            BookId = item.BookId,
                            BookName = item.BookName,
                            BookPageCount = item.BookPageCount,
                            WriterId = item.WriterId,
                            PublisherId = item.PublisherId,
                            ReadCount = ReadCount.Count,
                            Status = item.Status
                        };
                        list.Add(bookDto);
                    }
                    return new SuccessDataResult<List<BookListDto>>(list);
                }
                return new ErrorDataResult<List<BookListDto>>(Messages.BookNotFoundInList);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<BookListDto>>(Messages.UnknownError);
            }
        }

        public IResult UpdateBook(BookUpdateDto bookUpdateDto)
        {
            try
            {
                var b = _bookDal.Get(x => x.BookId == bookUpdateDto.BookId && x.Status == 1);
                if (b != null)
                {
                    return new ErrorResult(Messages.bookNotFound);
                }
                var book = new Book
                {
                    BookId = bookUpdateDto.BookId,
                    BookName = bookUpdateDto.BookName,
                    WriterId = bookUpdateDto.WriterId,
                    BookPageCount = bookUpdateDto.BookPageCount,
                    PublisherId = bookUpdateDto.PublisherId,
                    AddedDateTime = b.AddedDateTime,
                    Status = b.Status
                };
                _bookDal.Update(book);

                return new SuccessResult(Messages.bookUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }
    }
}
