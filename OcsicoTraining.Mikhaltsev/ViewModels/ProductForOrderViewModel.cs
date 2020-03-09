using System;

namespace ViewModels
{
    public class ProductForOrderViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Weight { get; set; }
        public int Quantity { get; set; }
    }
}
