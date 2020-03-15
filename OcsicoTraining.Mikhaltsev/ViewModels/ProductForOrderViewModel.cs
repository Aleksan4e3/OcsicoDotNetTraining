using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ProductForOrderViewModel
    {
        public Guid ProductId { get; set; }

        [Display(Name = "ProductName")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
