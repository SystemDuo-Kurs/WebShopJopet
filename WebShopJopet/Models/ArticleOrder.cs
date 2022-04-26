namespace WebShopJopet.Models
{
    public class ArticleOrder
    {
        public int Id { get; set; }
        public Article Article { get; set; }
        public int Amount { get; set; }
    }
}
