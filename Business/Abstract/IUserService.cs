using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult AddUser(UserAddDto userAddDto);
        IResult UpdateUser(UserUpdateDto userUpdateDto);
        IResult DeleteUser(int userId);

        IDataResult<User> GetById(int userId);
        IDataResult<List<UserListDto>> GetList();

    }
}
