using Microsoft.EntityFrameworkCore;
using WebShopJopet.Data;
using WebShopJopet.Models;

namespace WebShopJopet.Services
{
    public class ArticleService
    {
        private ApplicationDbContext Db { get; init; }
        public ArticleService(ApplicationDbContext db)
        {
            Db = db;
        }
        public async Task<List<Article>> GetAllAsync()
            => await Db.Articles.ToListAsync();
    }
}
