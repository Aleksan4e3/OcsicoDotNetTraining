using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class DbEmployeeRepository : DbBaseRepository<Employee>, IEmployeeRepository
    {
        public DbEmployeeRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
