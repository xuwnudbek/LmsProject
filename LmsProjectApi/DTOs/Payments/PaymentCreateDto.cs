using System;

namespace LmsProjectApi.DTOs.Payments
{
    public class PaymentCreateDto
    {
        public int Amount { get; set; }
        public int DiscountAmount { get; set; }
        public string Comment { get; set; }

        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
