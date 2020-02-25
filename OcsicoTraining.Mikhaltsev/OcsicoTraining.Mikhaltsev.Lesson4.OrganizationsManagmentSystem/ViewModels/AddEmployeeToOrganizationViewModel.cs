using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels
{
    public class AddEmployeeToOrganizationViewModel
    {
        public Guid OrganizationId { get; set; }
        public Guid? SelectedEmployeeId { get; set; }
        public List<SelectListItem> Employees { get; set; }
    }
}
