using System;
using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
