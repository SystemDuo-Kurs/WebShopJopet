namespace WebShopJopet.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string City { get; set; } = string.Empty;
        public string PO { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
    }
}
