using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels
{
    public class RemoveEmployeeViewModel
    {
        public Guid OrganizationId { get; set; }

        [Required, DisplayName("Employee")]
        public Guid? SelectedEmployeeId { get; set; }

        public List<SelectListItem> Employees { get; set; }
    }
}
