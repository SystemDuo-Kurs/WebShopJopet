namespace WebShopJopet.Models
{
    public class UserReg
    {
        public string UserName { get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordRepeat { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
