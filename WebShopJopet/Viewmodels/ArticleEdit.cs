using WebShopJopet.Models;
using WebShopJopet.Services;

namespace WebShopJopet.Viewmodels
{
    public interface IArticleEditVM
    {
        Task SaveAsync();
        Article Article { get; set; }
    }
    public class ArticleEditVM : IArticleEditVM
    {
        public Article Article { get; set; } = new();

        private IArticleService ArticleService { init; get; }

        public ArticleEditVM(IArticleService articleService)
        {
            ArticleService = articleService;
        }
        public async Task SaveAsync()
        {
            await ArticleService.SaveAsync(Article);
            Article = new();
        }
    }
}
