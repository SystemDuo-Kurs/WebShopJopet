using Microsoft.EntityFrameworkCore;
using WebShopJopet.Data;
using WebShopJopet.Models;

namespace WebShopJopet.Services
{
    public interface IAddressService
    {
        Task<List<Address>> GetAllAsync(string username);
        Task SaveAsync(Address address, string username);
        Task DeleteAsync(Address address);
    }
    public class AddressService : IAddressService
    {
        private ApplicationDbContext Db { get; init; }
        private IUserService UserService { get; init; } 
        public AddressService(ApplicationDbContext db, IUserService userService)
        {
            UserService = userService;
            Db = db;
        }
        public async Task<List<Address>> GetAllAsync(string username)
        {
            var user = await UserService.GetUserByNameAsync(username);
            Db.Addresses.ToList();
            switch (user)
            {
                case Admin admin:
                    return (new Address[] { admin.Address is null ? new Address() : admin.Address }).ToList();
                case Buyer buyer:
                    return buyer.Addresses;
            }
            return new List<Address>();
        }
        public async Task SaveAsync(Address address, string username)
        {
            var user = await UserService.GetUserByNameAsync(username);
            switch(user)
            {
                case Admin admin:
                    admin.Address = address;
                    break;
                case Buyer buyer:
                    buyer.Addresses.Add(address);
                    break;
            }
            Db.Update(address);
            await Db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Address address)
        {
            Db.Remove(address);
            await Db.SaveChangesAsync();
        }
    }
}
