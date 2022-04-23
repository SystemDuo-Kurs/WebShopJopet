using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public interface IArticleList
    {
        Task GetAllAsync();
        Task DeleteAsync(List<Article> article);
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
        public async Task DeleteAsync(List<Article> article)
        {
            await ArticleService.DeleteAsync(article);
        }
    }
}
