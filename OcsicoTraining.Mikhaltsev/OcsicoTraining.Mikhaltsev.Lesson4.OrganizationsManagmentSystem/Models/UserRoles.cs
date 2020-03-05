namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Organization = "Organization";
        public const string Employee = "Employee";
        public const string AdminOrOrganization = Admin + "," + Organization;
    }
}
