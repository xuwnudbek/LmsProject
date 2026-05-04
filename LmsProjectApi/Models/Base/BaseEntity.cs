using System;

namespace LmsProjectApi.Models.Base
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
