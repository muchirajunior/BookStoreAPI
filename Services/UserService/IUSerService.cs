using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services{

    public interface IUserService{
        Task<List<User>> GetUsers();
        Task<dynamic> RegisterUser(User user);
        Task<dynamic> LoginUser(string username, string password);
        Task<dynamic> DeleteUser(string username);
    }
}