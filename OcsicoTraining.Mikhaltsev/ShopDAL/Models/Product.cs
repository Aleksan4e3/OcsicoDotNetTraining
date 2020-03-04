using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public class Product : IEntityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string Image { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
