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
        public string Status { get; set; }


        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
