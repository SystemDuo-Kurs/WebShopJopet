using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public class ArticleList
    {
        public List<Article> Articles { get; private set; } = new();
        private ArticleService ArticleService { get; init; }
        public ArticleList(ArticleService articleService)
        {
            ArticleService = articleService;
        }
        public async Task GetAllAsync()
        {
            Articles = await ArticleService.GetAllAsync();
        }
    }
}
