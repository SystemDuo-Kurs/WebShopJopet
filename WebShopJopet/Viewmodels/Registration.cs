using Microsoft.AspNetCore.Components;
using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public class Registration
    {
        public UserReg User { get; set; } = new();
        private UserService UserService { get; init; }
        private NavigationManager NM { get; init; }
        public Registration(UserService userService, NavigationManager nm)
        {
            UserService = userService;
            NM = nm;
        }
        public async Task RegisterAsync()
        {
            await UserService.RegisterUserAsync(User);
            User = new();
            NM.NavigateTo("/");
        }
    }
}
