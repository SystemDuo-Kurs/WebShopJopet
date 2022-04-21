using Microsoft.AspNetCore.Identity;
using WebShopJopet.Models;

namespace WebShopJopet.Services
{
    public interface IUserService
    {
        Task RegisterAsync(UserReg user);
    }
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> UserManager { get; init; }
        public UserService(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
        }
        public async Task RegisterAsync(UserReg user)
        {
            IdentityUser iu;
            if (user.IsAdmin)
            {
                iu = new Admin { Email = user.Email, UserName = user.UserName };
            } else
            {
                iu = new Buyer { Email = user.Email, UserName = user.UserName };
            }
            var result = await UserManager.CreateAsync(iu, user.Password);
            var u = await UserManager.FindByEmailAsync(user.Email);
            if (user.IsAdmin)
            {
                await UserManager.AddToRoleAsync(u, "admin");
            } else
            {
                await UserManager.AddToRoleAsync(u, "user");
            }
        }
    }
}
