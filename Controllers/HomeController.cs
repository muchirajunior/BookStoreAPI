using BookStore.Services;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers{
    
    [ApiController]
    [Route("")]

    public class HomeController : ControllerBase{
        [HttpGet("")]
        public IActionResult Index(){
            return Ok(new Message("api running successfully"));
        }
    }
}