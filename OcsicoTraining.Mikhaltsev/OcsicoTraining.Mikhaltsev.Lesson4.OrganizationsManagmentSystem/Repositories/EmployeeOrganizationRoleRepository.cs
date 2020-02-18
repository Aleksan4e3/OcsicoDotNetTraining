using System.Text.Json;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class EmployeeOrganizationRoleRepository : FileBaseRepository<EmployeeOrganizationRole>, IEmployeeOrganizationRoleRepository
    {
        public EmployeeOrganizationRoleRepository(IEmployeeOrganizationRoleConfiguration configuration) : base(configuration.Path) { }

        public override async Task UpdateAsync(EmployeeOrganizationRole entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);
            entities.Add(entity);

            using (var sw = Context.StreamReWriter)
            {
                foreach (var e in entities)
                {
                    var json = JsonSerializer.Serialize(e);
                    await sw.WriteLineAsync(json);
                }
            }
        }

        public override async Task RemoveAsync(EmployeeOrganizationRole entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);

            using (var sw = Context.StreamReWriter)
            {
                foreach (var e in entities)
                {
                    var json = JsonSerializer.Serialize(e);
                    await sw.WriteLineAsync(json);
                }
            }
        }
    }
}
