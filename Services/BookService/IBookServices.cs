using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{

    public interface IBookService{
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(int id);
        Task<dynamic> AddBook(Book book);

    }
}