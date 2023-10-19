using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.BusinessPanel;
using Entities.Enums;

namespace Business.Concrete
{
    public class BusinessPanelManager : IBusinessPanelService
    {
        private IUserDal _userDal;
        private IBookDal _bookDal;
        private IUsersBorrowedBookDal _usersBorrowedBookDal;
        private IBannedUserDal _bannedUserDal;

        public BusinessPanelManager(IBookDal bookDal, IUserDal userDal, IUsersBorrowedBookDal usersBorrowedBookDal, IBannedUserDal bannedUserDal)
        {
            _bookDal = bookDal;
            _userDal = userDal;
            _usersBorrowedBookDal = usersBorrowedBookDal;
            _bannedUserDal = bannedUserDal;
        }

        public IDataResult<List<BorrowedListDto>> BorrowedList()
        {
            try
            {
                var ubbList = _usersBorrowedBookDal.GetList(x => x.Status == true);
                if (ubbList == null)
                {
                    return new ErrorDataResult<List<BorrowedListDto>>(Messages.borrowNotfoundInList);
                }
                List<BorrowedListDto> list = new List<BorrowedListDto>();
                foreach (var item in ubbList)
                {
                    var user = _userDal.Get(x => x.UserId == item.UserId);
                    var book = _bookDal.Get(x => x.BookId == item.BookId);
                    var bListDto = new BorrowedListDto
                    {
                        BookName = book.BookName,
                        BorrowedDateTime = item.BorrowedDateTime,
                        ReturnDateTime = item.ReturnDateTime,
                        UserFullName = user.UserName + " " + user.UserSurname,
                        UserId = item.UserId
                    };
                    list.Add(bListDto);
                }
                return new SuccessDataResult<List<BorrowedListDto>>(list);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<BorrowedListDto>>(Messages.UnknownError);
            }
        }

        public IResult GiveBook(GiveBookDto giveBookDto)
        {
            try
            {
                var BanControl = _bannedUserDal.Get(x => x.UserId == giveBookDto.UserId && x.Status == true);
                if (BanControl != null)
                {
                    return new ErrorResult(Messages.BlockedUser + $" Açıklama: '{BanControl.Description}'");
                }
                var user = _userDal.Get(x => x.UserId == giveBookDto.UserId && x.Status == 1);
                var book = _bookDal.Get(x => x.BookId == giveBookDto.BookId && x.Status == 1);
                var userBorrowedBook = _usersBorrowedBookDal.Get(x => x.UserId == giveBookDto.UserId && x.BookId == giveBookDto.BookId && x.Status == true);
                if (userBorrowedBook != null)
                {
                    return new ErrorResult(Messages.ThisUserAlreadyBorrowed);
                }
                if (book == null)
                {
                    return new ErrorResult(Messages.bookNotFound);
                }
                if (user == null)
                {
                    return new ErrorResult(Messages.UserNotFound);
                }
                if (book.Status == 2)
                {
                    return new ErrorResult(Messages.BookIsLoanedOut);
                }
                if (book.Status == 0)
                {
                    return new ErrorResult(Messages.bookNotFound);
                }
                var ubb = new UsersBorrowedBook
                {
                    UserId = giveBookDto.UserId,
                    BookId = giveBookDto.BookId,
                    BorrowedDateTime = DateTime.Now,
                    Status = true
                };
                _usersBorrowedBookDal.Add(ubb);
                var bookGive = new Book
                {
                    AddedDateTime = book.AddedDateTime,
                    BookId = book.BookId,
                    BookName = book.BookName,
                    BookPageCount = book.BookPageCount,
                    WriterId = book.WriterId,
                    PublisherId = book.PublisherId,
                    Status = (int)BookStatusesEnum.LoanedOut,
                };
                _bookDal.Update(bookGive);

                return new SuccessResult(Messages.BookBorrowedToUser);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IResult ReceiveBook(ReceiveBookDto receiveBookDto)
        {
            try
            {
                var ubb = _usersBorrowedBookDal.Get(x => x.UserId == receiveBookDto.UserId && x.BookId == receiveBookDto.BookId && x.Status == true);
                var book = _bookDal.Get(x => x.BookId == receiveBookDto.BookId && x.Status == 2);
                if (ubb == null)
                {
                    return new ErrorResult(Messages.NotFoundHistory);
                }
                if (book == null)
                {
                    return new ErrorResult(Messages.NotFoundHistory);
                }
                var ubbReceive = new UsersBorrowedBook
                {
                    BookId = ubb.BookId,
                    BorrowedDateTime = ubb.BorrowedDateTime,
                    ReturnDateTime = DateTime.Now,
                    Id = ubb.Id,
                    UserId = ubb.UserId,
                    Status = false
                };
                _usersBorrowedBookDal.Update(ubbReceive);
                var bookGive = new Book
                {
                    AddedDateTime = book.AddedDateTime,
                    BookId = book.BookId,
                    BookName = book.BookName,
                    BookPageCount = book.BookPageCount,
                    WriterId = book.WriterId,
                    PublisherId = book.PublisherId,
                    Status = (int)BookStatusesEnum.Accessible,
                };
                _bookDal.Update(bookGive);
                return new SuccessResult(Messages.bookIsReceived);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }
    }
}
