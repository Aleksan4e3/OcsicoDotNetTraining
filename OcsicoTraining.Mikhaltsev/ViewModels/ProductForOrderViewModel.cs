using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ProductForOrderViewModel
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [DisplayName("Цена")]
        public double Price { get; set; }

        [Display(Name = "Изображение")]
        public string ImageUrl { get; set; }

        [DisplayName("Вес")]
        public int Weight { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }
    }
}
