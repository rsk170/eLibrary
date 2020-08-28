using System.Linq;
using System.Threading.Tasks;
using eLibrary.Data;
using eLibrary.Entities.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace eLibrary.Code
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly ApplicationDbContext _context;

        public CustomCookieAuthenticationEvents(ApplicationDbContext context)
        {
            _context = context;
        }

        public override Task SignedIn(CookieSignedInContext context)
        {
            var usernameClaim = context.Principal.FindFirst("preferred_username").Value;

            if (!_context.Users.Any(u => u.Username.Equals(usernameClaim)))
            {
                User user = new User();
                user.Username = usernameClaim;
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            return base.SignedIn(context);
        }
    }
}
