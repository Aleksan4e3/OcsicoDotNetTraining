using System;

namespace ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public Guid ParentProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
