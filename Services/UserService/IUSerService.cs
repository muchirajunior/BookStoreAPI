using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services{

    public interface IUserService{
        Task<List<User>> GetUsers();
    }
}