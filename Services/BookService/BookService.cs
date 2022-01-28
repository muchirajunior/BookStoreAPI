using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services{
    public class BookService :IBookService {
        private readonly BookStoreContext _context;
        public BookService(BookStoreContext context)=> _context= context;

        public async Task<List<Book>> GetAllBooks(){
            var books= await _context.books.ToListAsync();

            return books;
        }
    }
}