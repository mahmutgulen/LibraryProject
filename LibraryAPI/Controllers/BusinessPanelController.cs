using Business.Abstract;
using Entities.Dtos.BusinessPanel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPanelController : ControllerBase
    {
        private IBusinessPanelService _businessPanelService;

        public BusinessPanelController(IBusinessPanelService businessPanelService)
        {
            _businessPanelService = businessPanelService;
        }

        [HttpPost("GiveBook")]
        public IActionResult GiveBook(GiveBookDto giveBookDto)
        {
            var result = _businessPanelService.GiveBook(giveBookDto);
            return Ok(result);
        }

        [HttpPost("ReceiveBook")]
        public IActionResult ReceiveBook(ReceiveBookDto receiveBookDto)
        {
            var result = _businessPanelService.ReceiveBook(receiveBookDto);
            return Ok(result);
        }

        [HttpGet("GetUserBorrowedList")]
        public IActionResult GetUbbList()
        {
            var result = _businessPanelService.BorrowedList();
            return Ok(result);
        }
    }
}
