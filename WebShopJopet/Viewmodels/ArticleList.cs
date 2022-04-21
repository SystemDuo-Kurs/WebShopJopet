using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public interface IArticleList
    {
        Task GetAllAsync();
        List<Article> Articles { get; }
    }
    public class ArticleList : IArticleList
    {
        public List<Article> Articles { get; private set; } = new();
        private IArticleService ArticleService { get; init; }
        public ArticleList(IArticleService articleService)
        {
            ArticleService = articleService;
        }
        public async Task GetAllAsync()
        {
            Articles = await ArticleService.GetAllAsync();
        }
    }
}
