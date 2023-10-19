using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.UnnecessaryInfos;

namespace Business.Concrete
{
    public class UnnecessaryInfosManager : IUnnecessaryInfosService
    {
        private IUserDal _userDal;
        private IBookDal _bookDal;
        private IUsersBorrowedBookDal _usersBorrowedBookDal;

        public UnnecessaryInfosManager(IUserDal userDal, IBookDal bookDal, IUsersBorrowedBookDal usersBorrowedBookDal)
        {
            _userDal = userDal;
            _bookDal = bookDal;
            _usersBorrowedBookDal = usersBorrowedBookDal;
        }

        public IDataResult<HowManyDaysLeftDto> HowManyDaysLeft()
        {
            try
            {
                TimeSpan time = TimeSpan.Zero;

                var ubb = _usersBorrowedBookDal.GetList().ToList();
                var most = ubb.GroupBy(x => x.BookId).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
                var bookId = most;
                if (ubb == null)
                {
                    return new ErrorDataResult<HowManyDaysLeftDto>(Messages.notFoundInReadBook);
                }
                var book = _bookDal.Get(x => x.BookId == bookId);
                var list = _usersBorrowedBookDal.GetList(x => x.BookId == bookId).ToList();
                foreach (var item in list)
                {
                    time = time + (item.ReturnDateTime - item.BorrowedDateTime);
                }
                var dto = new HowManyDaysLeftDto
                {
                    BookName = book.BookName,
                    Time = time
                };
                return new SuccessDataResult<HowManyDaysLeftDto>(dto);
            }
            catch (Exception)
            {
                return new ErrorDataResult<HowManyDaysLeftDto>(Messages.UnknownError);
            }
        }

        public IDataResult<List<MostBookReadUser>> MostBookReadUsers()
        {
            try
            {
                LibraryContext _context = new LibraryContext();
                var ubbUsers = _context.UsersBorrowedBooks.GroupBy(g => g.UserId).Where(x => x.Count() > 0).Select(s => new
                {
                    userId = s.FirstOrDefault().UserId,
                    readCount = s.Count()
                }).ToList();
                List<MostBookReadUser> list = new List<MostBookReadUser>();
                if (ubbUsers == null)
                {
                    return new ErrorDataResult<List<MostBookReadUser>>(Messages.borrowNotfoundInList);
                }
                foreach (var item in ubbUsers)
                {
                    var userId = item.userId;
                    var userDb = _userDal.Get(x => x.UserId == userId);
                    var dto = new MostBookReadUser
                    {
                        UserId = userDb.UserId,
                        UserFullName = userDb.UserName + " " + userDb.UserSurname,
                        UserReadBookCount = item.readCount
                    };
                    list.Add(dto);
                }
                return new SuccessDataResult<List<MostBookReadUser>>(list);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<MostBookReadUser>>(Messages.UnknownError);
            }
        }

        public IDataResult<List<MostPageBookListDto>> MostPageBooks()
        {
            try
            {
                var books = _bookDal.GetList().OrderByDescending(x => x.BookPageCount);
                if (books == null)
                {
                    return new SuccessDataResult<List<MostPageBookListDto>>(Messages.bookNotFound);
                }
                List<MostPageBookListDto> list = new List<MostPageBookListDto>();
                foreach (var book in books)
                {
                    list.Add(new MostPageBookListDto
                    {
                        Name = book.BookName,
                        PageCount = book.BookPageCount,
                    });
                }
                return new SuccessDataResult<List<MostPageBookListDto>>(list);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<MostPageBookListDto>>(Messages.UnknownError);
            }
        }

        public IDataResult<List<MostReadBookListDto>> MostReadBooks()
        {
            try
            {
                var ubb = _usersBorrowedBookDal.GetList().ToList();
                var mostReadBook = ubb.GroupBy(x => x.BookId).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
                var bookId = mostReadBook;
                var book = _bookDal.Get(x => x.BookId == bookId);
                if (mostReadBook == null)
                {
                    return new ErrorDataResult<List<MostReadBookListDto>>(Messages.notFoundInReadBook);
                }
                var readers = _usersBorrowedBookDal.GetList().Where(x => x.BookId == bookId).ToList();

                List<MostReadBookListDto> list = new List<MostReadBookListDto>();
                List<MostReadBookListDto.Readers> readersList = new List<MostReadBookListDto.Readers>();

                foreach (var item in readers)
                {
                    var user = _userDal.Get(x => x.UserId == item.UserId);
                    var readersListDto = new MostReadBookListDto.Readers
                    {
                        UserId = item.UserId,
                        UserFullName = user.UserName + " " + user.UserSurname
                    };
                    readersList.Add(readersListDto);
                }
                //kaç kez okundu
                var deneme = _usersBorrowedBookDal.GetList(x => x.BookId == bookId).ToList();
                var readCount = 0;
                foreach (var item in deneme)
                {
                    readCount++;
                }
                var mostReadBookListDto = new MostReadBookListDto
                {
                    BookName = book.BookName,
                    ReadCount = readCount,
                    readers = readersList
                };
                list.Add(mostReadBookListDto);
                return new SuccessDataResult<List<MostReadBookListDto>>(list);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<MostReadBookListDto>>(Messages.UnknownError);
            }
        }

        public IDataResult<List<OldestUsersListDto>> OldestUsers()
        {
            var users = _userDal.GetList().OrderBy(x => x.CreatedDateTime);
            if (users == null)
            {
                return new ErrorDataResult<List<OldestUsersListDto>>(Messages.UserNotFound);
            }
            List<OldestUsersListDto> list = new List<OldestUsersListDto>();
            foreach (var item in users)
            {
                list.Add(new OldestUsersListDto
                {
                    UserId = item.UserId,
                    UserFullName = item.UserName + " " + item.UserSurname,
                    UserRegisterDateTime = item.CreatedDateTime
                });
            }
            return new SuccessDataResult<List<OldestUsersListDto>>(list);
        }

        public IResult TryStoredProcedure()
        {
            throw new NotImplementedException();
        }
    }
}
