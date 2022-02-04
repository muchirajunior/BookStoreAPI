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

        [HttpPost("")]
        public async Task<IActionResult> CreateUser([FromBody]User user){
            var usr = await _userService.RegisterUser(user);

            return Created("",usr);
        }

        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> LoginUser([FromRoute]string username, [FromRoute]string password){
            var result= await _userService.LoginUser(username,password);
            return Ok(result);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser([FromRoute]string username){
            var result = await _userService.DeleteUser(username);

            return Ok(result);
        }

        
    }
}