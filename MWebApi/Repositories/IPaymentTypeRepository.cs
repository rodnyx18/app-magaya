using MWebApi.Entities;

namespace MWebApi.Repositories
{
    public interface IPaymentTypeRepository
    {
        public Task<List<Payment>> GetAll();
    }
}
