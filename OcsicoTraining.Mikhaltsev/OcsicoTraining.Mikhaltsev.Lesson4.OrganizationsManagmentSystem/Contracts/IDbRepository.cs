namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IDbRepository<T> : IRepository<T> where T : class
    {
    }
}
