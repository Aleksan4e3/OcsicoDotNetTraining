using System;
using System.ComponentModel;

namespace ViewModels
{
    public class ProductForOrderViewModel
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Цена")]
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Вес")]
        public int Weight { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }
    }
}
