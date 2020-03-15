using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class OrderDetailViewModel
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "TotalPrice")]
        public double TotalPrice { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
