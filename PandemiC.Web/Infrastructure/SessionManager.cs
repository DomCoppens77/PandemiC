using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PandemiC.Web.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public SessionUser User
        {
            get
            {
                if (!_session.Keys.Contains(nameof(User))) return null;
                return JsonSerializer.Deserialize<SessionUser>(_session.GetString(nameof(User)));
            }
    
            set
            {
                string json = JsonSerializer.Serialize(value);
                _session.SetString(nameof(User), json);
            }
        }
    }
}
