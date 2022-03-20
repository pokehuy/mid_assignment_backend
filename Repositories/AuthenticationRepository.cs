using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mid_assignment_backend.Common;
using mid_assignment_backend.Models;

namespace mid_assignment_backend.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    private string GenerateJwtToken(AuthenticationRequest model, string role)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Constants.SIGNATURE_KEY);
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username ?? "UNKNOWN"),
                new Claim(ClaimTypes.Role, role ?? "User"),
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

    public async Task<ResponseUser> Login(AuthenticationRequest model)
    {
        // return null if user not found
        var userLogin = await _context.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
        if (model.Username == null || model.Password == null || userLogin == null) return new ResponseUser { Message = "Invalid username or password" };
        if (userLogin != null && userLogin.Password != model.Password) return new ResponseUser { Message = "Invalid password!" };
        if (userLogin != null && userLogin.Password == model.Password)
            {
                // authentication successful so generate jwt token
                var tokenString = GenerateJwtToken(model, userLogin.Role);

                // return token
                return new ResponseUser
                {
                    Username = model.Username,
                    Token = tokenString,
                    Message = "Login successful"
                };
            }
        
        return new ResponseUser{ Message = "Error" };
    }
    }
}