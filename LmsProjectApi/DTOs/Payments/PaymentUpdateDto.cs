using System;

namespace LmsProjectApi.DTOs.Payments
{
    public class PaymentUpdateDto
    {
        public string Comment { get; set; }
        public int Amount { get; set; }
        public int DiscountAmount { get; set; }

        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
