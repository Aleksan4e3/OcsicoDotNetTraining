using System.Text.Json;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class EmployeeOrganizationRoleRepository : FileBaseRepository<EmployeeOrganizationRole>, IEmployeeOrganizationRoleRepository
    {
        public EmployeeOrganizationRoleRepository(IEmployeeOrganizationRoleConfiguration configuration) : base(configuration.Path) { }

        public override void Update(EmployeeOrganizationRole entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);
            entities.Add(entity);

            using (var sw = Context.StreamReWriter)
            {
                foreach (var e in entities)
                {
                    var json = JsonSerializer.Serialize(e);
                    sw.WriteLine(json);
                }
            }
        }

        public override void Remove(EmployeeOrganizationRole entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);

            using (var sw = Context.StreamReWriter)
            {
                foreach (var e in entities)
                {
                    var json = JsonSerializer.Serialize(e);
                    sw.WriteLine(json);
                }
            }
        }
    }
}
