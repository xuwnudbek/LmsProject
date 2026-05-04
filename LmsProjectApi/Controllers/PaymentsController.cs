using LmsProjectApi.DTOs.Payments;
using LmsProjectApi.Services.Payments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentResponseDto>> PostAsync(PaymentCreateDto dto)
        {
            var payment = await _paymentService.AddAsync(dto);

            return Ok(payment);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentResponseDto>> GetAllAsync()
        {
            IEnumerable<PaymentResponseDto> payments =
                _paymentService.GetAll();

            return Ok(payments);
        }

        [HttpGet("{paymentId}")]
        public async Task<ActionResult<PaymentResponseDto>> GetByIdAsync(Guid paymentId)
        {
            PaymentResponseDto payment =
                await _paymentService.GetByIdAsync(paymentId);

            return Ok(payment);
        }

        [HttpPut("{paymentId}")]
        public async Task<ActionResult<PaymentResponseDto>> UpdateAsync(
            Guid paymentId,
            [FromBody] PaymentUpdateDto dto)
        {
            PaymentResponseDto updated =
                await _paymentService.UpdateAsync(paymentId, dto);

            return Ok(updated);
        }

        [HttpDelete("{paymentId}")]
        public async Task<ActionResult<PaymentResponseDto>> DeleteAsync(Guid paymentId)
        {
            await _paymentService.DeleteAsync(paymentId);

            return Ok();
        }
    }
}
