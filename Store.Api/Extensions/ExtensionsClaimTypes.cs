using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Api.Extensions
{
    //Razor Pages
    public static class ExtensionsClaimTypes
    {
        public static int Id(this ClaimsPrincipal user)
        {
            try
            {
                var id = user.Claims.FirstOrDefault(x => x.Type == "id")?.Value ?? "0";
                return int.Parse(id);
            }
            catch
            {
                return 0;
            }
        }

        public static string Name(this ClaimsPrincipal user)
        {
            try
            {
                var name = user.Claims.FirstOrDefault(x => x.Type == "name")?.Value ?? string.Empty;
                return name;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Email(this ClaimsPrincipal user)
        {
            try
            {
                var email = user.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? string.Empty;
                return email;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GivenName(this ClaimsPrincipal user)
        {
            try
            {
                var givenName = user.Claims.FirstOrDefault(x => x.Type == "given_name")?.Value ?? string.Empty;
                return givenName;
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
