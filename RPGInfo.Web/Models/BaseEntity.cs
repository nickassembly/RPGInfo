using System.Collections.Generic;

namespace RPGInfo.Web.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new();
    }
}
