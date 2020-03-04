using System;

namespace EntityModels.Models
{
    public class OrderDetail : IEntityModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
