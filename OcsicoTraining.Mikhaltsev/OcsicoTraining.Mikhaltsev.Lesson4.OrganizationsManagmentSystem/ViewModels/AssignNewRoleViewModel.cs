using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels
{
    public class AssignNewRoleViewModel
    {
        public Guid OrganizationId { get; set; }

        public Guid EmployeeId { get; set; }

        [Required, DisplayName("Add role")]
        public Guid? SelectedRoleAddId { get; set; }

        [DisplayName("Remove role")]
        public Guid? SelectedRoleRemoveId { get; set; }

        public List<SelectListItem> RolesAdd { get; set; }

        public List<SelectListItem> RolesRemove { get; set; }
    }
}
