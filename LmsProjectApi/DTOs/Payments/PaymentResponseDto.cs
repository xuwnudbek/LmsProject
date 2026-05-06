using LmsProjectApi.DTOs.Groups;
using LmsProjectApi.DTOs.Users;

namespace LmsProjectApi.DTOs.Payments
{
    public class PaymentResponseDto
    {
        public string Comment { get; set; }
        public int Amount { get; set; }
        public int DiscountAmount { get; set; }

        public UserResponseDto User { get; set; }
        public GroupResponseDto Group { get; set; }
    }
}
