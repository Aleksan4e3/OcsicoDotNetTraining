using System;
using System.Collections.Generic;
using EntityModels.Identity;

namespace EntityModels
{
    public class Order : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Address { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }


        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
