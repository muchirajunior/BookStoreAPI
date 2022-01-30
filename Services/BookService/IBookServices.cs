using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{

    public interface IBookService{
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(int id);
        Task<dynamic> AddBook(Book book);
        Task<dynamic> UpdateBook(int id, Book book);
        Task DeleteBook(int id);

    }
}