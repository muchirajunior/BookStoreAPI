using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Controllers{
    
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase {

        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService=userService;

        [HttpGet("")]
        public async Task<IActionResult> GetUsers(){
            var users = await _userService.GetUsers();
            
            return Ok(users);
        }

        
    }
}