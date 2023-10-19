using Business.Abstract;
using Business.Contants;
using Business.Contants.Enums;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.User;

namespace Business.Concrete
{

    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult AddUser(UserAddDto userAddDto)
        {
            try
            {
                var userExists = _userDal.Get(x => x.UserIdentityNumber == userAddDto.UserIdentityNumber && x.Status == 1);
                if (userExists != null)
                {
                    return new ErrorResult(Messages.UserAlreadyExists);
                }
                var users = new User
                {
                    UserAddress = userAddDto.UserAddress,
                    CreatedDateTime = DateTime.Now,
                    Status = (int)UserStatusesEnum.Active,
                    UserIdentityNumber = userAddDto.UserIdentityNumber,
                    UserName = userAddDto.UserName,
                    UserPhoneNumber = userAddDto.UserPhoneNumber,
                    UserSurname = userAddDto.UserSurname
                };
                _userDal.Add(users);
                return new SuccessResult(Messages.UserAdded);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IResult DeleteUser(int userId)
        {
            try
            {
                var user = _userDal.Get(x => x.UserId == userId && x.Status == 1);
                if (user != null)
                {
                    var users = new User
                    {
                        ClosedDateTime = DateTime.Now,
                        CreatedDateTime = user.CreatedDateTime,
                        Status = (int)UserStatusesEnum.Dropped,
                        UserIdentityNumber = user.UserIdentityNumber,
                        UserName = user.UserName,
                        UserAddress = user.UserAddress,
                        UserId = user.UserId,
                        UserPhoneNumber = user.UserPhoneNumber,
                        UserSurname = user.UserSurname
                    };
                    _userDal.Update(users);
                    return new SuccessResult(Messages.UserDeleted);
                }
                return new ErrorResult(Messages.UserNotFound);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IDataResult<User> GetById(int userId)
        {
            try
            {
                var result = _userDal.Get(x => x.UserId == userId && x.Status == 1);
                if (result != null)
                {
                    return new SuccessDataResult<User>(result);
                }
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(Messages.UnknownError);
            }

        }

        public IDataResult<List<UserListDto>> GetList()
        {
            try
            {
                var user = _userDal.GetList(x => x.Status == 1);
                List<UserListDto> list = new List<UserListDto>();
                if (user != null)
                {
                    foreach (var item in user)
                    {
                        var userListDto = new UserListDto
                        {
                            UserId = item.UserId,
                            UserName = item.UserName,
                            UserSurname = item.UserSurname,
                            UserIdentityNumber = item.UserIdentityNumber,
                            UserPhoneNumber = item.UserPhoneNumber,
                            UserAddress = item.UserAddress,
                            CreatedDateTime = item.CreatedDateTime,
                            ClosedDateTime = item.ClosedDateTime,
                            Status = item.Status
                        };
                        list.Add(userListDto);
                    }
                    return new SuccessDataResult<List<UserListDto>>(list);
                }
                return new ErrorDataResult<List<UserListDto>>(Messages.UserNotFoundInList);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<UserListDto>>(Messages.UnknownError);
            }
        }
        public IResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = _userDal.Get(x => x.UserId == userUpdateDto.UserId && x.Status == 1);
                if (user != null)
                {
                    var users = new User
                    {
                        UserIdentityNumber = userUpdateDto.UserIdentityNumber,
                        UserName = userUpdateDto.UserName,
                        UserAddress = userUpdateDto.UserAddress,
                        UserId = user.UserId,
                        UserPhoneNumber = userUpdateDto.UserPhoneNumber,
                        UserSurname = userUpdateDto.UserSurname,
                        CreatedDateTime = user.CreatedDateTime,
                        ClosedDateTime = user.ClosedDateTime,
                        Status = user.Status
                    };
                    _userDal.Update(users);
                    return new SuccessResult(Messages.UserUpdated);
                }
                return new ErrorResult(Messages.UserNotFound);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<User>>(Messages.UnknownError);
            }
        }


    }
}
