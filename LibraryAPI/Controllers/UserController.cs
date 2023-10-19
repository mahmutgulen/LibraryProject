using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetList();
            return Ok(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(int userId)
        {
            var result = _userService.GetById(userId);
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserAddDto userAddDto)
        {
            var result = _userService.AddUser(userAddDto);
            return Ok(result);
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            var result = _userService.UpdateUser(userUpdateDto);
            return Ok(result);
        }
        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            var result = _userService.DeleteUser(userId);
            return Ok(result);
        }

    }
}
