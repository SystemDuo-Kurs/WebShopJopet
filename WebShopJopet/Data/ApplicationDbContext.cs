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

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}