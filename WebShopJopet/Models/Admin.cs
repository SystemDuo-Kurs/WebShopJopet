using Microsoft.AspNetCore.Identity;

namespace WebShopJopet.Models
{
    public class Admin : IdentityUser
    {
        public Address? Address { get; set; }
    }
}
