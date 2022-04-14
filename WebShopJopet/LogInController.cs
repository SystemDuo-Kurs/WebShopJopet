using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShopJopet.Models;

namespace WebShopJopet
{
    [Controller]
    [Route("/api/{name}")]
    public class LogInController : ControllerBase
    {
        private UserManager<IdentityUser> UserManager { get; init; }
        private SignInManager<IdentityUser> SignInManager { get; init; }
        public LogInController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [HttpGet]
        public string Test()
            => "Radi geeet";
        [HttpPost]
        public async Task LogInAsync([FromBody]UserReg user)
        {
            var u = await UserManager.FindByEmailAsync(user.Email);
            var rez = await SignInManager.PasswordSignInAsync(u, user.Password, false, false);
        }
    }
}
