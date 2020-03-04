using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public class Customer : IEntityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
