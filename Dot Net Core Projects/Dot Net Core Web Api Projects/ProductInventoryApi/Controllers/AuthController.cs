namespace ProductInventoryApi.Controllers
{
    using global::ProductInventoryApi.Dtos;
    using global::ProductInventoryApi.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    namespace ProductInventoryApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly ProductInventoryDbContext _context;
            private readonly IConfiguration _configuration;

            public AuthController(
                ProductInventoryDbContext context,
                IConfiguration configuration)
            {
                _context = context;
                _configuration = configuration;
            }

            // POST: api/auth/register
            [HttpPost("register")]
            public async Task<IActionResult> Register(
                RegisterRequest request)
            {
                if (await _context.Users
                    .AnyAsync(u => u.Username == request.Username))
                {
                    return BadRequest(new
                    {
                        message = "Username already exists."
                    });
                }

                var allowedRoles = new[] { "Admin", "User" };

                if (!allowedRoles.Contains(request.Role))
                {
                    return BadRequest(new
                    {
                        message = "Invalid role."
                    });
                }

                var passwordHasher =
                    new PasswordHasher<User>();

                var user = new User
                {
                    Username = request.Username,
                    Role = request.Role,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow
                };

                user.PasswordHash =
                    passwordHasher.HashPassword(
                        user,
                        request.Password
                    );

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "User registered successfully."
                });
            }

            // POST: api/auth/login
            [HttpPost("login")]
            public async Task<IActionResult> Login(
                LoginRequest request)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(
                        u => u.Username == request.Username);

                if (user == null || !user.IsActive)
                {
                    return Unauthorized(new
                    {
                        message = "Invalid username or password."
                    });
                }

                var passwordHasher =
                    new PasswordHasher<User>();

                var result =
                    passwordHasher.VerifyHashedPassword(
                        user,
                        user.PasswordHash,
                        request.Password
                    );

                if (result == PasswordVerificationResult.Failed)
                {
                    return Unauthorized(new
                    {
                        message = "Invalid username or password."
                    });
                }

                var token = GenerateJwtToken(user);

                return Ok(token);
            }

            private LoginResponse GenerateJwtToken(User user)
            {
                var key = _configuration["Jwt:Key"]
                    ?? throw new InvalidOperationException(
                        "JWT Key is missing.");

                var issuer = _configuration["Jwt:Issuer"];

                var audience = _configuration["Jwt:Audience"];

                var expirationMinutes =
                    int.Parse(
                        _configuration["Jwt:ExpirationMinutes"]
                        ?? "60");

                var expiresAt =
                    DateTime.UtcNow.AddMinutes(
                        expirationMinutes);

                var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.UserId.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    user.Username),

                new Claim(
                    ClaimTypes.Role,
                    user.Role)
            };

                var securityKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key));

                var credentials =
                    new SigningCredentials(
                        securityKey,
                        SecurityAlgorithms.HmacSha256);

                var jwtToken =
                    new JwtSecurityToken(
                        issuer: issuer,
                        audience: audience,
                        claims: claims,
                        expires: expiresAt,
                        signingCredentials: credentials);

                var token =
                    new JwtSecurityTokenHandler()
                        .WriteToken(jwtToken);

                return new LoginResponse
                {
                    Token = token,
                    Username = user.Username,
                    Role = user.Role,
                    ExpiresAt = expiresAt
                };
            }
        }
    }
}
