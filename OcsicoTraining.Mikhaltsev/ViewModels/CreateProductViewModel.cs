using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels
{
    public class CreateProductViewModel
    {
        [Display(Name = "ProductName")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        public Guid? SelectedParentId { get; set; }
        public List<SelectListItem> ProductParents { get; set; }
    }
}
