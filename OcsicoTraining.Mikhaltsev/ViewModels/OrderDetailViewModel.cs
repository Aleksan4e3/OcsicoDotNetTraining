using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class OrderDetailViewModel
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Вес")]
        public int Weight { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Стоимость")]
        public double TotalPrice { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
