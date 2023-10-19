using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnnecessaryInfoController : ControllerBase
    {
        private IUnnecessaryInfosService _unnecessaryInfosService;

        public UnnecessaryInfoController(IUnnecessaryInfosService unnecessaryInfosService)
        {
            _unnecessaryInfosService = unnecessaryInfosService;
        }

        [HttpGet("GetMostReadBook")]
        public IActionResult GetMostReadBooks()
        {
            var result = _unnecessaryInfosService.MostReadBooks();
            return Ok(result);
        }

        [HttpGet("GetMostPageBooks")]
        public IActionResult GetMostPageBooks()
        {
            var result = _unnecessaryInfosService.MostPageBooks();
            return Ok(result);
        }

        [HttpGet("GetOldestUsers")]
        public IActionResult GetOldestUsers()
        {
            var result = _unnecessaryInfosService.OldestUsers();
            return Ok(result);
        }

        [HttpGet("GetMostBookReadUsers")]
        public IActionResult MostBookReadUsers()
        {
            var result = _unnecessaryInfosService.MostBookReadUsers();
            return Ok(result);
        }

        [HttpGet("HowManyDaysLeft")]
        public IActionResult HowManyDaysLeft()
        {
            var result = _unnecessaryInfosService.HowManyDaysLeft();
            return Ok(result);
        }


        [HttpGet("TryStoredProcedure")]
        public IActionResult TryStoredProcedure()
        {
            var result = _unnecessaryInfosService.TryStoredProcedure();
            return Ok(result);
        }
    }
}
