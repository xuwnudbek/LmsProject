using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.DTOs.Payments
{
    public class PaymentResponseDto
    {
        public string Comment { get; set; }
        public int Amount { get; set; }
        public int DiscountAmount { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}
