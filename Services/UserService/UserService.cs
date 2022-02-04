using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace BookStore.Services{

    public class UserService : IUserService{

        private readonly BookStoreContext _context;

        public UserService(BookStoreContext context) => _context=context;

        public async Task<List<User>> GetUsers() =>  await _context.users.ToListAsync();

        public async Task<dynamic> RegisterUser(User user){
           var pass=new PasswordHasher<object>().HashPassword(null, user.password);
           user.password=pass;
           _context.users.Add(user);
           await _context.SaveChangesAsync();

           return user;
        }

        public async Task<dynamic> LoginUser(string username, string password){
            var user = await _context.users.Where(usr=> usr.username==username).FirstOrDefaultAsync();

            if (user != null){
                var passCheck = new PasswordHasher<object>().VerifyHashedPassword(null, user.password, password);
               return ((int)passCheck)== 1 ? user : new Message("invalid password");
            }
            else return new Message("invalid user");
        }

        public async Task<dynamic> DeleteUser(string username){
            var user = await _context.users.Where(usr=> usr.username==username).FirstOrDefaultAsync();
            
            if (user != null){
                _context.users.Remove(user);
               await _context.SaveChangesAsync();

               return new Message("user deleted successfuly");
            }
            else return new Message("unable to delete user");
            
        }


    }
}