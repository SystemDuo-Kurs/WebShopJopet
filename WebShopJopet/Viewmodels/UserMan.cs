using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public class UserMan
    {
        public UserReg User { get; set; } = new();
        private UserService UserService { get; init; }
        private NavigationManager NM { get; init; }
        public UserMan(UserService userService, NavigationManager nm)
        {
            UserService = userService;
            NM = nm;
        }
        public async Task RegisterAsync()
        {
            await UserService.RegisterAsync(User);
            User = new();
            NM.NavigateTo("Identity/Account/Login");
        }
      
    }
}
