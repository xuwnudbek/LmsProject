using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.Models.Payments
{
    public class Payment : BaseEntity
    { 
        public int Amount { get; set; }
        public int DiscountAmount { get; set; }
        public string Comment { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
