using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class DbRoleRepository : DbBaseRepository<Role>, IRoleRepository
    {
        public DbRoleRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
