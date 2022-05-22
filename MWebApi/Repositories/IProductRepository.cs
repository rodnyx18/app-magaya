using MWebApi.Entities;

namespace MWebApi.Repositories
{
    public interface IProductRepository
    {        
        public Task<Product> Add(Product entity);
        public Task<bool> Delete(int id);       
        public Task<Product?> Get(int id);
        public Task<List<Product>> GetAll();
        public Task<List<Product>> GetAll(string text);
        public Task Update(int id, Product entity);
    }
}
