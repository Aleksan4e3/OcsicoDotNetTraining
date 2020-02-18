using System.Text.Json;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class EmployeeRepository : FileBaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IEmployeeConfiguration configuration) : base(configuration.Path) { }

        public override async void UpdateAsync(Employee entity)
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

        public override async void RemoveAsync(Employee entity)
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
