using AutoMapper;
using FluentValidation;
using LmsProjectApi.DTOs.Payments;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Payments;
using LmsProjectApi.Repositories.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IValidator<PaymentCreateDto> _paymentCreateValidator;
        private readonly IValidator<PaymentUpdateDto> _paymentUpdateValidator;
        private readonly IMapper _mapper;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IValidator<PaymentCreateDto> paymentCreateValidator,
            IValidator<PaymentUpdateDto> paymentUpdateValidator,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _paymentCreateValidator = paymentCreateValidator;
            _paymentUpdateValidator = paymentUpdateValidator;
        }

        public async Task<PaymentResponseDto> AddAsync(PaymentCreateDto dto)
        {
            var validatorResult = _paymentCreateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

            Payment payment = _mapper.Map<Payment>(dto);

            Payment created =
                await _paymentRepository.InsertAsync(payment);

            return _mapper.Map<PaymentResponseDto>(created);
        }

        public ICollection<PaymentResponseDto> GetAll()
        {
            ICollection<Payment> payments =
                _paymentRepository
                    .SelectAll()
                    .ToList();

            return _mapper.Map<ICollection<PaymentResponseDto>>(payments);
        }

        public async Task<PaymentResponseDto> GetByIdAsync(Guid paymentId)
        {
            Payment payment =
                await _paymentRepository.SelectByIdAsync(paymentId);

            return _mapper.Map<PaymentResponseDto>(payment);
        }

        public async Task<PaymentResponseDto> UpdateAsync(
            Guid paymentId,
            PaymentUpdateDto dto)
        {
            var validatorResult = _paymentUpdateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

            Payment existingPayment =
                await _paymentRepository.SelectByIdAsync(paymentId);

            if (existingPayment is null)
                throw new NotFoundException($"Payment with id ({paymentId}) not found.");

            _mapper.Map(dto, existingPayment);

            await _paymentRepository.UpdateAsync();

            return _mapper.Map<PaymentResponseDto>(existingPayment);
        }

        public async Task DeleteAsync(Guid paymentId)
        {
            Payment existingPayment =
                await _paymentRepository.SelectByIdAsync(paymentId);

            if (existingPayment is null)
                throw new NotFoundException($"Payment with id ({paymentId}) not found.");

            await _paymentRepository.DeleteAsync(existingPayment);
        }
    }
}
