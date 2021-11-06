using ExamenT3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace ExamenT3.Service
{

    public interface ICookieAuthService
    {
        public void Login(ClaimsPrincipal claim);
        public Usuario GetUserLogged();
    }

    public class CookieAuthService : ICookieAuthService
    {
        private HttpContext httpContext;
        private AppNotasContext context;

        public CookieAuthService(AppNotasContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.context = context;
        }

        public void Login(ClaimsPrincipal claim)
        {
            httpContext.SignInAsync(claim);
        }

        private Claim GetClaim()
        {
            return httpContext.User.Claims.FirstOrDefault();
        }

        public Usuario GetUserLogged()
        {
            var username = this.GetClaim().Value;
            return this.context.Usuarios.Where(x => x.Username == username).First();
        }
    }
}
