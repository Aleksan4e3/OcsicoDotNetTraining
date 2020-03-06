using System;
using System.Collections.Generic;

namespace EntityModels
{
    public class Product : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid? ParentProductId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual Product ParentProduct { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
