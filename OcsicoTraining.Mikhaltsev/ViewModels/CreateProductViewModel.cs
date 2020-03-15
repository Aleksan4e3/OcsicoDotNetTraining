using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels
{
    public class CreateProductViewModel
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Изображение")]
        public IFormFile Image { get; set; }

        public Guid? SelectedParentId { get; set; }
        public List<SelectListItem> ProductParents { get; set; }
    }
}
