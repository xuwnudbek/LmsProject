using LmsProjectApi.DTOs.Payments;
using LmsProjectApi.Models.Api;
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
        public async Task<ActionResult<PaymentResponseDto>> CreateAsync(PaymentCreateDto dto)
        {
            PaymentResponseDto created =
                await _paymentService.AddAsync(dto);

            return Ok(ApiResponse<PaymentResponseDto>.Ok(created, "Successfully created."));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentResponseDto>> GetAllAsync()
        {
            IEnumerable<PaymentResponseDto> payments =
                _paymentService.GetAll();

            return Ok(ApiResponse<IEnumerable<PaymentResponseDto>>.Ok(payments));
        }

        [HttpGet("{paymentId}")]
        public async Task<ActionResult<PaymentResponseDto>> GetByIdAsync(Guid paymentId)
        {
            PaymentResponseDto payment =
                await _paymentService.GetByIdAsync(paymentId);

            return Ok(ApiResponse<PaymentResponseDto>.Ok(payment));

        }

        [HttpPut("{paymentId}")]
        public async Task<ActionResult<PaymentResponseDto>> UpdateAsync(
            Guid paymentId,
            [FromBody] PaymentUpdateDto dto)
        {
            PaymentResponseDto updated =
                await _paymentService.UpdateAsync(paymentId, dto);

            return Ok(ApiResponse<PaymentResponseDto>.Ok(updated, "Successfully updated."));
        }

        [HttpDelete("{paymentId}")]
        public async Task<ActionResult<PaymentResponseDto>> DeleteAsync(Guid paymentId)
        {
            await _paymentService.DeleteAsync(paymentId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));

        }
    }
}
