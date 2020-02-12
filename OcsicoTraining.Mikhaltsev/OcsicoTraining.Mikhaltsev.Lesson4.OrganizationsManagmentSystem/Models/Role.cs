namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Id} {Name};";
    }
}
