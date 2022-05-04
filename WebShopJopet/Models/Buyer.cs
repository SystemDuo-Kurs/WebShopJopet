using Microsoft.AspNetCore.Identity;
using WebShopJopet.Viewmodels;

namespace WebShopJopet.Models
{
    public class Buyer : IdentityUser
    {
        public Order CurrentOrder { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}
