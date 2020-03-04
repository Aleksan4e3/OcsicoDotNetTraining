using System;
using System.Collections.Generic;

namespace EntityModels
{
    public class Product : IEntityModel
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public Guid? ParentProductId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public virtual Image Image { get; set; }
        public virtual Product ParentProduct { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
