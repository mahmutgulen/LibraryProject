using Business.Abstract;
using Entities.Dtos.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(BookAddDto bookAddDto)
        {
            var result = _bookService.AddBook(bookAddDto);
            return Ok(result);
        }

        [HttpPost("UpdateBook")]
        public IActionResult UpdateBook(BookUpdateDto bookUpdateDto)
        {
            var result = _bookService.UpdateBook(bookUpdateDto);
            return Ok(result);
        }

        [HttpPost("DeleteBook")]
        public IActionResult DeleteBook(int bookId)
        {
            var result = _bookService.DeleteBook(bookId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public IActionResult GetBooks()
        {
            var result = _bookService.GetList();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int bookId)
        {
            var result = _bookService.GetById(bookId);
            return Ok(result);
        }
    }
}
