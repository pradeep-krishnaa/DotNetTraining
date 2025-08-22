using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BugTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static List<User> _users = new(); // ✅ In-memory store for demo
        private readonly PasswordHasher<User> _passwordHasher = new();

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ✅ POST: api/auth/register
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (_users.Any(u => u.Username == request.UserName))
                return BadRequest(new { Message = "Username already exists" });

            var user = new User { Username = request.UserName };
            user.Password = _passwordHasher.HashPassword(user, request.Password);

            _users.Add(user);
            return Ok(new { Message = "User created successfully" });
        }

        // ✅ POST: api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _users.FirstOrDefault(u => u.Username == request.UserName);
            if (user == null)
                return Unauthorized(new { Message = "Invalid username or password" });

            // Verify password hash
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { Message = "Invalid username or password" });

            var token = GenerateJwtToken(user.Username);
            return Ok(new { Token = token });
        }

        // ✅ JWT generator
        private string GenerateJwtToken(string username)
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expirationMinutes = Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"]);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
