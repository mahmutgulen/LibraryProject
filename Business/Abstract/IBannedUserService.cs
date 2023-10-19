using Core.Utilities.Results;
using Entities.Dtos.BannedUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBannedUserService
    {
        IResult AddBanUser(AddBanDto addBanDto);
        IResult RemoveBanUser(int userId);
        IDataResult<List<BannedUserListDto>> GetListBannedUser();
    }
}
