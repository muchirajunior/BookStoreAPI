using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace BookStore.Services{
    public class BookService :IBookService {
        private readonly BookStoreContext _context;
        public BookService(BookStoreContext context)=> _context= context;

        public async Task<List<Book>> GetAllBooks(){
            var books= await _context.books.ToListAsync();

            return books;
        }

        public async  Task<Book> GetBook(int id){
            var book = await _context.books.Where( book => book.id ==id ).FirstOrDefaultAsync();

            return book;  
        }

        public async Task<dynamic> AddBook( Book book ){
            _context.books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<dynamic> UpdateBook(int id, Book book){
            var newbook= new Book(){
                id=id, 
                title=book.title, 
                description=book.description
            };

             _context.books.Update(newbook);
            await _context.SaveChangesAsync();

            return newbook;

        }

        public async Task DeleteBook(int id){
            var book= new Book(){ id=id};

            _context.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}