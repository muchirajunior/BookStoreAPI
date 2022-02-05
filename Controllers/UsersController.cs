using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

        [HttpGet("")]
        [Authorize()]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var usr = await _userService.RegisterUser(user);

            return Created("", usr);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLogin user)
        {
            var result = await _userService.LoginUser(user.username, user.password);
            return Ok(result);
        }

        [HttpPut("")]
        public IActionResult EditUser()
        {

            return NotFound(new { message = "service unavailable", data = "no content" });
        }

        [HttpDelete("{username}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromRoute] string username)
        {
            var result = await _userService.DeleteUser(username);

            return Ok(result);
        }


    }
}