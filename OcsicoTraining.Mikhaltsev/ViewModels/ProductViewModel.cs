using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public Guid ParentProductId { get; set; }

        [Display(Name = "ProductName")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
