using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using mid_assignment_backend.Common;
using mid_assignment_backend.Models;
using mid_assignment_backend.Repositories;

namespace mid_assignment_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;

    private string GenerateJwtToken(AuthenticationRequest model)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.SIGNATURE_KEY);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username ?? "UNKNOWN"),
                new Claim(ClaimTypes.Role, "Admin"),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;

    }
    
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] AuthenticationRequest model)
    {
        // return null if user not found
        //var hasUsername = _context.Users.ToList().FirstOrDefault(x => x.Username == model.Username);
        //if(hasUsername == null) return NotFound("User not found");
        if (model.Username == null || model.Password == null || model.Username != "admin" || model.Password != "admin") return BadRequest("Invalid username or password");

        // authentication successful so generate jwt token
        var tokenString = GenerateJwtToken(model);

        // return token
        return Ok(new
        {
            Username = model.Username,
            token = tokenString
        });
    }
    
    
}


