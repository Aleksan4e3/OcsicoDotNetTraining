using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }

        public Guid? SelectedParentId { get; set; }
        public List<SelectListItem> ProductParents { get; set; }
    }
}
