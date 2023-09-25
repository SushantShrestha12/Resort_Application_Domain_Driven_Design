using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Resort.Infrastructure;
using Resort.UI.Contracts.Authorization;

namespace Resort.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private const string AccessSecretKey =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlN1c2hhbnQgU2hyZXN0aGEiLCJpYXQiOjE1MTYyMzkwMjJ9.cHZ8sR2WJY7W5ciBOBgz4joxTe7yUrnxzgOY-uP9I7g";

        private readonly SymmetricSecurityKey _accessSigningKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AccessSecretKey));

        private const string RefreshSecretKey =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0IiwibmFtZSI6IlN1c2hhbnQgU2hyZXN0aGEiLCJpYXQi.cHizMVtNP28-vvhzYEwJZByXvqlR1GSfV9b4F0t_-DI";

        private readonly SymmetricSecurityKey _refreshSigningKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(RefreshSecretKey));

        [HttpPost]
        public IActionResult CreateLogin([FromBody] LoginCreate login)
        {
            if (IsValidUser(login.username, login.password))
            {
                var now = DateTime.UtcNow;

                var accessTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, login.username),
                        new Claim(JwtRegisteredClaimNames.Email, login.username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    Issuer = "http://localhost:5194",
                    Audience = "http://localhost:5194",
                    SigningCredentials =
                        new SigningCredentials(_accessSigningKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var refreshTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, login.username),
                        new Claim(JwtRegisteredClaimNames.Email, login.username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(43200),
                    Issuer = "http://localhost:5194",
                    Audience = "http://localhost:5194",
                    SigningCredentials =
                        new SigningCredentials(_refreshSigningKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var accessTokenHandler = new JwtSecurityTokenHandler();
                var accessToken = accessTokenHandler.CreateToken(accessTokenDescriptor);
                var accessTokenString = accessTokenHandler.WriteToken(accessToken);

                var refreshTokenHandler = new JwtSecurityTokenHandler();
                var refreshToken = refreshTokenHandler.CreateToken(refreshTokenDescriptor);
                var refreshTokenString = refreshTokenHandler.WriteToken(refreshToken);

                var response = new
                {
                    IsAuthenticated = true,
                    AccessToken = accessTokenString,
                    RefreshToken = refreshTokenString,
                };
                return Ok(response);
            }

            return Unauthorized();
        }

        private readonly ResortDbContext _dbContext;

        public LoginController(ResortDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private bool IsValidUser(string username, string password)
        {
            var user = _dbContext.SignUps.Any(u => u.Username == username);
            var pass = _dbContext.SignUps.Any(u => u.Password == password);

            return user && pass;
        }
    }
}


// using Microsoft.AspNetCore.Mvc;
// using Resort.Infrastructure;
// using Resort.UI.Contracts.Authorization;
//
// namespace Resort.UI.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class LoginController : ControllerBase
//     {
//         [HttpPost]
//         public bool CreateLogin([FromBody] LoginCreate login)
//         {
//             if (IsValidUser(login.username, login.password))
//             {
//                 return true;
//             }
//             return false;
//         }
//
//         private readonly ResortDbContext _dbContext;
//
//         public LoginController(ResortDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }
//
//         private bool IsValidUser(string username, string password)
//         {
//             var user = _dbContext.SignUps.Any(u => u.Username == username);
//             var pass = _dbContext.SignUps.Any(u => u.Password == password);
//
//             return user && pass;
//         }
//     }
// }

