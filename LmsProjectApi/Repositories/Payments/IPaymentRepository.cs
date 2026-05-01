using LmsProjectApi.Models.Payments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Payments
{
    public interface IPaymentRepository
    {
        Task<Payment> InsertAsync(Payment payment);
        IQueryable<Payment> SelectAll();
        Task<Payment> SelectByIdAsync(Guid paymentId);
        Task UpdateAsync();
        Task DeleteAsync(Payment payment);
    }
}
