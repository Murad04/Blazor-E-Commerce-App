using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blazor_E_Commerce.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string user, [FromQuery] string password)
        {
            if (user == "admin" && password == "admin1234")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user),
                    new Claim(ClaimTypes.Email,"admin@blazor_e_commerce_app"),
                    new Claim(ClaimTypes.MobilePhone,"11111111"),
                };

                var userIdentity=new ClaimsIdentity(userClaims, "Blazor_E_Commerce.CookieAuth");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("Blazor_E_Commerce.CookieAuth", userPrincipal);
            }

            return Redirect("/outstandingorders");
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/outstandingorders");
        }
    }
}
