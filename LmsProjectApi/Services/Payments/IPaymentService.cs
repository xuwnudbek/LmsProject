using LmsProjectApi.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Payments
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> AddAsync(PaymentCreateDto dto);
        ICollection<PaymentResponseDto> GetAll();
        Task<PaymentResponseDto> GetByIdAsync(Guid paymentId);
        Task<PaymentResponseDto> UpdateAsync(Guid paymentId, PaymentUpdateDto dto);
        Task DeleteAsync(Guid paymentId);
    }
}
