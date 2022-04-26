using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShopJopet.Models;

namespace WebShopJopet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>().HasKey(a => a.Id);

            builder.Entity<Order>().HasKey(o => o.Id);
            builder.Entity<Order>().HasMany(o => o.Articles);

            builder.Entity<Buyer>().HasMany(b => b.Orders)
                .WithOne();
            builder.Entity<Buyer>().HasOne(b => b.CurrentOrder);

            builder.Entity<ArticleOrder>().HasKey(ao => ao.Id);
            builder.Entity<ArticleOrder>().HasOne(ao => ao.Article);

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ArticleOrder> ArticleOrders { get; set; }
    }
}