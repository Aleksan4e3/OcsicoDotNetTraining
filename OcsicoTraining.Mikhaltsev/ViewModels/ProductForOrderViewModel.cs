using System;
using System.ComponentModel;
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

        [DisplayName("Price")]
        public double Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [DisplayName("Weight")]
        public int Weight { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }
    }
}
