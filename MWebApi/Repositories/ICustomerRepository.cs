using MWebApi.Entities;

namespace MWebApi.Repositories
{
    public interface ICustomerRepository
    {        
        public Task<Customer> Add(Customer entity);
        public Task<bool> Delete(int id);     
        public Task<Customer?> Get(int id);
        public Task<List<Customer>> GetAll();
        public Task Update(int id, Customer entity);
    }
}
