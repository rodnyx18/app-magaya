using Microsoft.EntityFrameworkCore;
using MWebApi.Contexts;
using MWebApi.Entities;

namespace MWebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private OrdersDBContext _context = default!;

        public ProductRepository(OrdersDBContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product entity)
        {
            _context.Products.Add(entity);

            await _context.SaveChangesAsync();

            return await _context.Products.FirstAsync(p => p.Id == entity.Id);        
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                var productsOrder = await _context.ProductOrders.Where(po => po.ProductId == id).ToListAsync();
                var ordersId = productsOrder.Select(po => po.OrderId).ToList();
                var orders = await _context.Orders.Where(o => ordersId.Contains(o.Id)).ToListAsync();

                _context.ProductOrders.RemoveRange(productsOrder);
                await _context.SaveChangesAsync();

                _context.Orders.RemoveRange(orders);
                await _context.SaveChangesAsync();

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Product?> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAll(string text)
        {
            return await _context.Products.Where(p => p.Description.Contains(text)).ToListAsync();
        }

        public async Task Update(int id, Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
