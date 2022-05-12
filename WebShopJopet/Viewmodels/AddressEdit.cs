using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public interface IAddressEdit
    {
        Task SaveAsync(string username);
        Address Address { get; set; }
    }
    public class AddressEdit : IAddressEdit
    {
        public Address Address { get; set; } = new();

        private IAddressService AddressService { init; get; }

        public AddressEdit(IAddressService addressService)
        {
            AddressService = addressService;
        }
        public async Task SaveAsync(string username)
        {
            await AddressService.SaveAsync(Address, username);
            Address = new();
        }
    }
}
