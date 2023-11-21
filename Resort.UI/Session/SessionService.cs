using Microsoft.AspNetCore.Http;
using Resort.Domain.SharedKernel;

namespace Resort.UI.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISession _session;
        // private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor, ISession session)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public string GetUsername()
        {
            return _session.GetString("Username");
        }

        public void SetUsername(string username)
        {
            _session.SetString("Username", username);
        }
    }
}