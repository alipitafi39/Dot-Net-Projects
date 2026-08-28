using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// =====================================================
// JWT AUTHENTICATION
// =====================================================

var jwtSettings = builder.Configuration.GetSection("Jwt");

var key = jwtSettings["Key"]!;
var issuer = jwtSettings["Issuer"]!;
var audience = jwtSettings["Audience"]!;

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,

                ValidateAudience = true,
                ValidAudience = audience,

                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)),

                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
    });


// =====================================================
// AUTHORIZATION
// =====================================================

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("authenticated", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

// ============================================
// RATE LIMITING
// ============================================

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddFixedWindowLimiter(
        "api-policy",
        limiterOptions =>
        {
            limiterOptions.PermitLimit = 10;

            limiterOptions.Window = TimeSpan.FromMinutes(1);

            limiterOptions.QueueLimit = 0;
        });
});

// =====================================================
// YARP
// =====================================================

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(
        builder.Configuration.GetSection("ReverseProxy"));


var app = builder.Build();


// =====================================================
// HTTP PIPELINE / Middleware
// =====================================================

app.UseAuthentication();

app.UseAuthorization();

app.UseRateLimiter();

// =====================================================
// YARP
// =====================================================

app.MapReverseProxy();

app.Run();