using Microsoft.EntityFrameworkCore;
using WebShopJopet.Data;
using WebShopJopet.Models;

namespace WebShopJopet.Services
{
    public interface IOrderService
    {
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
        Task<List<Order>> GetAllAsync();
    }
    public class OrderService : IOrderService
    {
        private ApplicationDbContext Db { get; init; }
        public OrderService(ApplicationDbContext db)
        {
            Db = db;
        }
        public async Task UpdateAsync(Order order)
        {
            Db.Update(order);
            await Db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Order order)
        {
            Db.Remove(order);
            await Db.SaveChangesAsync();
        }
        public async Task<List<Order>> GetAllAsync()
            => await Db.Orders.ToListAsync();
    }
}
