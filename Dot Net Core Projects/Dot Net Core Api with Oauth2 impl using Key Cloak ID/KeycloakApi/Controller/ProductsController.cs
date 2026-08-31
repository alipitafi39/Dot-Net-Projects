using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // --------------------------------------------------
    // Public endpoint
    // --------------------------------------------------

    [HttpGet("public")]
    [AllowAnonymous]
    public IActionResult Public()
    {
        return Ok(new
        {
            message = "This endpoint is public"
        });
    }


    // --------------------------------------------------
    // Authenticated endpoint
    // --------------------------------------------------

    [HttpGet]
    [Authorize]
    public IActionResult GetProducts()
    {
        return Ok(new
        {
            message = "You are authenticated!",
            username = User.Identity?.Name,
            userId = User.FindFirst("sub")?.Value
        });
    }


    // --------------------------------------------------
    // Admin endpoint
    // --------------------------------------------------

    [HttpGet("admin")]
    [Authorize(Roles = "admin")]
    public IActionResult Admin()
    {
        return Ok(new
        {
            message = "You are an ADMIN!"
        });
    }
}