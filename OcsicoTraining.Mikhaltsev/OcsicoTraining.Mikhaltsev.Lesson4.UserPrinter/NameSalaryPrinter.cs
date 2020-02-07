namespace OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter
{
    public class NameSalaryPrinter : IPrinter
    {
        public string Print(User user) => $"Name: {user.Name}, Salary: {user.Salary}";
    }
}
