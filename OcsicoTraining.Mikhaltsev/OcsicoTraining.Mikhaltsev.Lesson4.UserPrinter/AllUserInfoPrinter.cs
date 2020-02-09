namespace OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter
{
    public class AllUserInfoPrinter : IPrinter
    {
        public string Print(User user) => $"Name: {user.Name}, PhoneNumber: {user.PhoneNumber}, Salary: {user.Salary}";
    }
}
