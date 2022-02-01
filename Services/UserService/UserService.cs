using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services{

    public class UserService : IUserService{

        private readonly BookStoreContext _context;

        public UserService(BookStoreContext context) => _context=context;

        public async Task<List<User>> GetUsers() =>  await _context.users.ToListAsync();


    }
}