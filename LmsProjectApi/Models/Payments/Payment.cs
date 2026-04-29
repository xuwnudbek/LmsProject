using LmsProjectApi.Models.Users;
using System;
using System.Text.RegularExpressions;

namespace LmsProjectApi.Models.Payments
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Amount { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
