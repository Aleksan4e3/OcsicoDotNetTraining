using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class DbEmployeeOrganizationRoleRepository : DbBaseRepository<EmployeeOrganizationRole>, IEmployeeOrganizationRoleRepository
    {
        public DbEmployeeOrganizationRoleRepository(IDataContext dataContext) : base(dataContext) { }
    }
}