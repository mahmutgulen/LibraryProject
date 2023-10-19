using Business.Abstract;
using Business.Contants;
using Business.Contants.Enums;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.BannedUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BannedUserManager : IBannedUserService
    {
        private IUserDal _userDal;
        private IBannedUserDal _bannedUserDal;
        public BannedUserManager(IUserDal userDal, IBannedUserDal bannedUserDal)
        {
            _userDal = userDal;
            _bannedUserDal = bannedUserDal;
        }

        public IResult AddBanUser(AddBanDto addBanDto)
        {
            try
            {
                var u = _userDal.Get(x => x.UserId == addBanDto.UserId);
                if (u == null)
                {
                    return new ErrorResult(Messages.UserNotFound);
                }
                if (u.Status == 2)
                {
                    return new ErrorResult(Messages.userAlreadyBanned);
                }
                var bannedUser = new BannedUser
                {
                    UserId = addBanDto.UserId,
                    Description = addBanDto.Description,
                    BannedDateTime = DateTime.Now,
                    Status = true
                };
                _bannedUserDal.Add(bannedUser);
                //User
                var userUpdate = new User
                {
                    UserId = u.UserId,
                    ClosedDateTime = u.ClosedDateTime,
                    CreatedDateTime = u.CreatedDateTime,
                    Status = (int)UserStatusesEnum.Banned,
                    UserAddress = u.UserAddress,
                    UserIdentityNumber = u.UserIdentityNumber,
                    UserName = u.UserName,
                    UserPhoneNumber = u.UserPhoneNumber,
                    UserSurname = u.UserSurname
                };
                _userDal.Update(userUpdate);
                return new SuccessResult(Messages.userIsBanned);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IDataResult<List<BannedUserListDto>> GetListBannedUser()
        {
            try
            {
                var bannedUserList = _bannedUserDal.GetList(x => x.Status == true);
                if (bannedUserList == null)
                {
                    return new ErrorDataResult<List<BannedUserListDto>>(Messages.BannedUserNotFound);
                }
                List<BannedUserListDto> list = new List<BannedUserListDto>();
                foreach (var item in bannedUserList)
                {
                    var user = _userDal.Get(x => x.UserId == item.UserId);
                    var dto = new BannedUserListDto
                    {
                        ApprovedDateTime = item.ApprovedDateTime,
                        BannedDateTime = item.BannedDateTime,
                        Description = item.Description,
                        Status = item.Status,
                        UserFullName = user.UserName + " " + user.UserSurname,
                        UserId = item.UserId
                    };
                    list.Add(dto);
                }
                return new SuccessDataResult<List<BannedUserListDto>>(list);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<BannedUserListDto>>(Messages.UnknownError);
            }
        }

        public IResult RemoveBanUser(int userId)
        {
            try
            {
                var bannedUser = _bannedUserDal.Get(x => x.UserId == userId && x.Status == true);
                if (bannedUser == null)
                {
                    return new ErrorResult(Messages.notBannedUser);
                }
                var bannedUserUpdate = new BannedUser
                {
                    BannedDateTime = bannedUser.BannedDateTime,
                    ApprovedDateTime = DateTime.Now,
                    Description = bannedUser.Description,
                    Id = bannedUser.Id,
                    Status = false,
                    UserId = bannedUser.UserId
                };
                _bannedUserDal.Update(bannedUserUpdate);
                //User
                var u = _userDal.Get(x => x.UserId == userId);
                var userUpdate = new User
                {
                    ClosedDateTime = u.ClosedDateTime,
                    CreatedDateTime = u.CreatedDateTime,
                    Status = (int)UserStatusesEnum.Active,
                    UserAddress = u.UserAddress,
                    UserId = u.UserId,
                    UserIdentityNumber = u.UserIdentityNumber,
                    UserName = u.UserName,
                    UserPhoneNumber = u.UserPhoneNumber,
                    UserSurname = u.UserSurname
                };
                _userDal.Update(userUpdate);
                return new SuccessResult(Messages.RemovedBannedUser);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }
    }
}
