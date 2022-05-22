using Microsoft.EntityFrameworkCore;
using System.Linq;
using MWebApi.Contexts;
using MWebApi.Entities;

namespace MWebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OrdersDBContext _context = default!;

        public OrderRepository(OrdersDBContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order order)
        {
            var productsOrder = new List<ProductOrder>();
            order.ProductOrders?.ToList().ForEach(p => productsOrder.Add(p.DeepCopy()));

            order.Number = Guid.NewGuid().ToString();
            order.Date = DateTime.Now;
            order.ProductOrders = new List<ProductOrder>();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            productsOrder.ForEach(p => p.OrderId = order.Id);
            _context.ProductOrders.AddRange(productsOrder);
            order.Number = (order.Id + 1000).ToString();
            await _context.SaveChangesAsync();

            order.ProductOrders = productsOrder;

            return order;
        }

        public async Task<bool> Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                var productOrder = await _context.ProductOrders.Where(po => po.OrderId == id).ToListAsync();
                _context.ProductOrders.RemoveRange(productOrder);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Order?> Get(int id)
        {
            var order = await _context
                .Orders
                .Include(o => o.Payment)
                .FirstAsync(o => o.Id == id);                                  

            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task Update(int id, Order order)
        {
            _context.Entry(order).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductOrder>> GetProductOrder(int orderId)
        {
            var productOrder = await _context
                .ProductOrders
                .Include(o => o.Product)
                .Where(o => o.OrderId == orderId)
                .ToListAsync();

            return productOrder;
        }
    }
}
