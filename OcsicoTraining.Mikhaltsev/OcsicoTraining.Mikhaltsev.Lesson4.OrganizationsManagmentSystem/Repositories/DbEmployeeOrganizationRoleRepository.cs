using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class DbEmployeeOrganizationRoleRepository : DbBaseRepository<EmployeeOrganizationRole>, IEmployeeOrganizationRoleRepository
    {
        public DbEmployeeOrganizationRoleRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
