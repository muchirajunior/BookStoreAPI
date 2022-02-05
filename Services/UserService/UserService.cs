using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace BookStore.Services{

    public class UserService : IUserService{

        private readonly BookStoreContext _context;
        private readonly IConfiguration _config;

        public UserService(BookStoreContext context, IConfiguration configuration){
            _context=context;
            _config=configuration;
        } 

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
               return ((int)passCheck)== 1 ? new Message("suceesfull login"){data=new UserInfo(user, GenerateJSONWebToken(user))} : new Message("invalid password");
            }
            else return new Message("invalid user");
        }

        private string GenerateJSONWebToken(User userInfo)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:secretKey"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(_config["Jwt:validIssuer"],    
              _config["Jwt:validIssuer"],    
              null,    
              expires: DateTime.Now.AddMinutes(120),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
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