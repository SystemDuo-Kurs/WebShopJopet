using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public interface IUserMan
    {
        UserReg User { get; set; }
        Task RegisterAsync();
    }
    public class UserMan : IUserMan
    {
        public UserReg User { get; set; } = new();
        private IUserService UserService { get; init; }
        private NavigationManager NM { get; init; }
        public UserMan(IUserService userService, NavigationManager nm)
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
