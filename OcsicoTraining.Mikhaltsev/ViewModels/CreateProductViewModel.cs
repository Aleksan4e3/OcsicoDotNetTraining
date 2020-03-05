using System;
using System.Collections.Generic;
using EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Image Image { get; set; }

        public Guid? SelectedParentId { get; set; }
        public List<SelectListItem> ProductParents { get; set; }
    }
}
