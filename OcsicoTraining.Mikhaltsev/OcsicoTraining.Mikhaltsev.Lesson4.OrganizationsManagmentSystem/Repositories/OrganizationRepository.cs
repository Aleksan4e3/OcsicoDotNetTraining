using System.Text.Json;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class OrganizationRepository : FileBaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(IOrganizationConfiguration configuration) : base(configuration.Path) { }

        public override async Task UpdateAsync(Organization entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.Id == entity.Id);
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

        public override async Task RemoveAsync(Organization entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.Id == entity.Id);

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
