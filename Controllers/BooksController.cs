using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class BooksController{
        private readonly  IBookService _bookService;
        public BooksController(IBookService bookService)=> _bookService=bookService;

        [HttpGet("")]
        public async Task<dynamic> GetAllBooks(){
            var books = await _bookService.GetAllBooks();

            return books;
        }

    }
}
