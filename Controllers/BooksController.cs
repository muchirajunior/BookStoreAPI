using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BookStore.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class BooksController : ControllerBase{
        private readonly  IBookService _bookService;
        public BooksController(IBookService bookService)=> _bookService=bookService;

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks(){
            var books = await _bookService.GetAllBooks();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook( [FromRoute]int id){
            var book = await _bookService.GetBook(id);
            if (book == null) { return NotFound(); }

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody]Book book){
            var newbook = await _bookService.AddBook(book);

            return Created("",newbook);
        }

    }
}
