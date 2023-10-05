using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resort.Infrastructure;

namespace Resort.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private readonly ResortDbContext _context;
        private readonly ISession _session;

        public LogoutController(ResortDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var username = _session.GetString("Username");
            
            var accessToken = await _context.AccessTokens
                .Where(token => token.Username == username)
                .FirstOrDefaultAsync();

            if (accessToken == null)
            {
                return BadRequest();
            }

            _context.AccessTokens.Remove(accessToken);
            await _context.SaveChangesAsync();
            
            _session.Remove("Username");
            _session.Clear();
            return Ok();
        }
    }
}