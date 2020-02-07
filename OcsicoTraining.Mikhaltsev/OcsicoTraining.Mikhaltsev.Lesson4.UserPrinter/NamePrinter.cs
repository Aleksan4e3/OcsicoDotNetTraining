namespace OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter
{
    public class NamePrinter : IPrinter
    {
        public string Print(User user) => $"Name: {user.Name}";
    }
}
