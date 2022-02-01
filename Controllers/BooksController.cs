using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
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
            if (book == null) { return NotFound(new Message("no such book in the records")); }

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody]Book book){
            var newbook = await _bookService.AddBook(book);

            return Created("",newbook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]Book book ){
            try{
                var newbook= await _bookService.UpdateBook(id,book);

                return Ok(newbook);
            }
            catch(System.Exception){
                return NotFound(new Message("failed to update, no such item"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id){
            try
            {
                await _bookService.DeleteBook(id);

                return Ok(new Message("deleted successfuly"));
            }
            catch (System.Exception){
                return NotFound(new Message("failed to delete, no such item"));
            }
        }


    }
}
