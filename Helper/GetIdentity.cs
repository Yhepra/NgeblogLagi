using System.Linq;
using System.Security.Claims;

namespace NgeblogLagi.Helper
{
    public static class GetIdentity
    {
        public static string GetName(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(x => 
                    x.Type == "Name")?
                    .Value ?? string.Empty;
            }
            return string.Empty;
        }

        public static string GetUsername(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(x =>
                    x.Type == "Username")?
                    .Value ?? string.Empty;
            }
            return string.Empty;
        }

        public static string GetRole(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(x =>
                    x.Type == "Role")?
                    .Value ?? string.Empty;
            }
            return string.Empty;
        }
    }
}
