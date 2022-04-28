using WebShopJopet.Models;
using WebShopJopet.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
namespace WebShopJopet.Viewmodels
{
    public interface IShopping
    {
        List<ArticleOrder> Articles { get; }
        Order CurrentOrder { get; }
        Task GetAllAsync();
        Task AddToCartAsync(ArticleOrder art);
        Task GetCurrentOrder();
    }
    public class Shopping : IShopping
    {
        public List<ArticleOrder> Articles { get; private set; } = new();
        public Order CurrentOrder { get; private set; } = new();
        private IOrderService OrderService { init; get; }
        private IArticleService ArticleService { init; get; }
        private ProtectedLocalStorage ProtectedLocalStorage { init; get; }
        public Shopping(IOrderService orderService, IArticleService articleService,
            ProtectedLocalStorage protectedLocalStorage)
        {
            OrderService = orderService;
            ArticleService = articleService;
            ProtectedLocalStorage = protectedLocalStorage;

            
        }
        public async Task GetCurrentOrder()
        {
            var result = await ProtectedLocalStorage.GetAsync<Order>("currentOrder");
            if (result.Success)
                CurrentOrder = result.Value;
        }

        public async Task GetAllAsync()
            => (await ArticleService.GetAllAsync())
                .ForEach(article => Articles.Add(new ArticleOrder {Article = article, Amount=1}));
        
        public async Task AddToCartAsync(ArticleOrder art)
        {
            var old = CurrentOrder.Articles.Find(ao => ao.Article == art.Article);
            if (old is null)
            {
                CurrentOrder.Articles.Add(art);
                var index = Articles.FindIndex(ao => ao.Article == art.Article);
                Articles[index] = new ArticleOrder { Article = art.Article, Amount = 1 };
            }
            else
                old.Amount = art.Amount;
            await ProtectedLocalStorage.SetAsync("currentOrder", CurrentOrder);
        }
        

    }
}
