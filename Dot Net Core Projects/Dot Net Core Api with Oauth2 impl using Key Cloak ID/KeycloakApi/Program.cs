using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);


// ==================================================
// Controllers
// ==================================================

builder.Services.AddControllers();


// ==================================================
// Authentication - Keycloak JWT
// ==================================================

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority =
            builder.Configuration["Keycloak:Authority"];

        options.Audience =
            builder.Configuration["Keycloak:Audience"];

        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                RoleClaimType = "roles"
            };


        // ------------------------------------------
        // Convert Keycloak realm_access.roles
        // into ASP.NET Core role claims
        // ------------------------------------------

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var identity =
                    context.Principal?.Identity
                    as ClaimsIdentity;

                var realmAccess =
                    context.Principal?
                        .FindFirst("realm_access")?
                        .Value;

                if (realmAccess != null)
                {
                    using var document =
                        JsonDocument.Parse(realmAccess);

                    if (document.RootElement.TryGetProperty(
                            "roles",
                            out var roles))
                    {
                        foreach (var role in roles.EnumerateArray())
                        {
                            var roleName =
                                role.GetString();

                            if (!string.IsNullOrEmpty(roleName))
                            {
                                identity?.AddClaim(
                                    new Claim(
                                        "roles",
                                        roleName));
                            }
                        }
                    }
                }

                return Task.CompletedTask;
            }
        };
    });


// ==================================================
// Authorization
// ==================================================

builder.Services.AddAuthorization();


// ==================================================
// Swagger
// ==================================================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,

        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(
                    "http://localhost:8080/realms/myrealm/protocol/openid-connect/auth"),

                TokenUrl = new Uri(
                    "http://localhost:8080/realms/myrealm/protocol/openid-connect/token"),

                Scopes = new Dictionary<string, string>
                {
                    ["openid"] = "OpenID",
                    ["profile"] = "Profile",
                    ["email"] = "Email"
                }
            }
        }
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new[] { "openid", "profile", "email" }
        }
    });
});

var app = builder.Build();


// ==================================================
// HTTP Pipeline
// ==================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId("my-api-client");

        // Authorization Code + PKCE
        options.OAuthUsePkce();
    });
}


//app.UseHttpsRedirection();


// VERY IMPORTANT ORDER
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();