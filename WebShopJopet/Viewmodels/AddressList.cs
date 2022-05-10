using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public interface IAddressList
    {
        Task GetAllAsync(string username);
        Task DeleteAsync(Address address);
        List<Address> Addresses { get; }
    }
    public class AddressList : IAddressList
    {
        public List<Address> Addresses { get; private set; } = new();
        private IAddressService AddressService { get; init; }
        public AddressList(IAddressService addressService)
        {
            AddressService = addressService;
        }
        public async Task GetAllAsync(string username)
        {
            Addresses = await AddressService.GetAllAsync(username);
        }
        public async Task DeleteAsync(Address address)
        {
            await AddressService.DeleteAsync(address);
        }
    }
}
