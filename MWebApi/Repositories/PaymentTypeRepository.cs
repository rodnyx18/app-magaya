using Microsoft.EntityFrameworkCore;
using MWebApi.Contexts;
using MWebApi.Entities;

namespace MWebApi.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private OrdersDBContext _context = default!;

        public PaymentTypeRepository(OrdersDBContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _context.Payments.ToListAsync();
        }
    }
}
