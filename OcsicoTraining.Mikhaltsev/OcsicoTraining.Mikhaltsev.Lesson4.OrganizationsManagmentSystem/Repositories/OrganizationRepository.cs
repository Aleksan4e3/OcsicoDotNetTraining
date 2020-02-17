using System.Text.Json;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class OrganizationRepository : FileBaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(IOrganizationConfiguration configuration) : base(configuration.Path) { }

        public override void Update(Organization entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.Id == entity.Id);
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

        public override void Remove(Organization entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.Id == entity.Id);

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