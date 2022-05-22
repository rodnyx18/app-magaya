using MWebApi.Entities;

namespace MWebApi.Repositories
{
    public interface IOrderRepository
    {        
        public Task<Order> Add(Order entity);
        public Task<bool> Delete(int id);     
        public Task<Order?> Get(int id);
        public Task<List<Order>> GetAll();
        public Task<List<ProductOrder>> GetProductOrder(int orderId);
        public Task Update(int id, Order entity);
    }
}
