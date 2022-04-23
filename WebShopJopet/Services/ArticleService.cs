using Microsoft.EntityFrameworkCore;
using WebShopJopet.Data;
using WebShopJopet.Models;

namespace WebShopJopet.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllAsync();
        Task SaveAsync(Article article);
        Task DeleteAsync(List<Article> article);
    }
    public class ArticleService : IArticleService
    {
        private ApplicationDbContext Db { get; init; }
        public ArticleService(ApplicationDbContext db)
        {
            Db = db;
        }
        public async Task<List<Article>> GetAllAsync()
            => await Db.Articles.ToListAsync();
        public async Task SaveAsync(Article article)
        {
            Db.Update(article);
            await Db.SaveChangesAsync();
        }
        public async Task DeleteAsync(List<Article> article)
        {
            article.ForEach(a => Db.Remove(a));
            await Db.SaveChangesAsync();
        }
    }
}
