using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductInventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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