namespace OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter
{
    public class User
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }

        public string PrintInfo(IPrinter printer) => printer.Print(this);
    }
}
