using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ProductInventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAccount()
        {
            return Ok(new
            {
                Id = 1,
                Name = "Ali Khan",
                Email = "ali_khan@example.com",
                Role = "User",
                Message = "Account information retrieved successfully."
            });
        }
    }
}