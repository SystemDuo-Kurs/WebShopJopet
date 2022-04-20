namespace WebShopJopet.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
