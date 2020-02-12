namespace OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter
{
    public class SalaryPrinter : IPrinter
    {
        public string Print(User user) => $"Salary: {user.Salary}";
    }
}
