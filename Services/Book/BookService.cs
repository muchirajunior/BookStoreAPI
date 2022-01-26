using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services{
    public class BookService :IBookService {
        private readonly BookStoreContext _context;
        public BookService(BookStoreContext context)=> _context= context;

        public async Task<List<Book>> GetAllBooks(){
               _context.Books.Add(new Book(){Id=2,Title="title",Description="my description"});
            var books= await _context.Books.ToListAsync();

            return books;
        }
    }
}