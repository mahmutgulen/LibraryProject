using Business.Abstract;
using Entities.Dtos.BannedUsers;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedUserController : ControllerBase
    {
        private IBannedUserService _bannedUserService;

        public BannedUserController(IBannedUserService bannedUserService)
        {
            _bannedUserService = bannedUserService;
        }

        [HttpPost("AddBanUser")]
        public IActionResult AddBanUser(AddBanDto addBanDto)
        {
            var result = _bannedUserService.AddBanUser(addBanDto);
            return Ok(result);
        }

        [HttpPost("RemoveBanUser")]
        public IActionResult RemoveBanUser(int userId)
        {
            var result = _bannedUserService.RemoveBanUser(userId);
            return Ok(result);
        }

        [HttpPost("GetBannedUsers")]
        public IActionResult GetBannedUserList()
        {
            var result = _bannedUserService.GetListBannedUser();
            return Ok(result);
        }
    }
}
