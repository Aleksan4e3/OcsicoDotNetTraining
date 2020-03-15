using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public Guid ParentProductId { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Изображение")]
        public string ImageUrl { get; set; }
    }
}
