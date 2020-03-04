using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public class Order : IEntityModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }


        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
