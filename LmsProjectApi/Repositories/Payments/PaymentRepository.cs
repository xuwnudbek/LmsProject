using LmsProjectApi.Data.Context;
using LmsProjectApi.Models.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Payments
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly AppDbContext _dbContext;

        public PaymentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> InsertAsync(Payment payment)
        {
            var entry = await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public IQueryable<Payment> SelectAll()
        {
            return _dbContext.Payments
                .AsNoTracking();
        }

        public Task<Payment> SelectByIdAsync(Guid paymentId)
        {
            return _dbContext.Payments.
                FirstOrDefaultAsync(l => l.Id == paymentId);
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Payment payment)
        {
            _dbContext.Payments.Remove(payment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
