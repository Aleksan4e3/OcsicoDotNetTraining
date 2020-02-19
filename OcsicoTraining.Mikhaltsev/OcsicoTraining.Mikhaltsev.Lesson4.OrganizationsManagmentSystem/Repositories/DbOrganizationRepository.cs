using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class DbOrganizationRepository : DbBaseRepository<Organization>, IOrganizationRepository
    {
        public DbOrganizationRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
