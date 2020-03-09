using System;

namespace ViewModels
{
    public class OrderDetailViewModel
    {
        public Guid ProductId { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
