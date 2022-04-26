namespace WebShopJopet.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<ArticleOrder> Articles { get; set; } = new();
        public decimal TotalPrice => Articles.Aggregate<ArticleOrder, decimal>
            (0, (total, artOr) => total += artOr.Amount * artOr.Article.Price);

        public decimal TotalWithFor()
        {
            decimal total = 0;
            foreach(var artOr in Articles)
            {
                total += artOr.Amount * artOr.Article.Price;
            }
            return total;
        }
        public DateTime OrderDate { get; set; }

    }
}
