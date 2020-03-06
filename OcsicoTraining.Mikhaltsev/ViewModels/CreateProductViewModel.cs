using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModels
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; } // TODO: int?

        public Guid? SelectedParentId { get; set; }
        public List<SelectListItem> ProductParents { get; set; }
    }
}
