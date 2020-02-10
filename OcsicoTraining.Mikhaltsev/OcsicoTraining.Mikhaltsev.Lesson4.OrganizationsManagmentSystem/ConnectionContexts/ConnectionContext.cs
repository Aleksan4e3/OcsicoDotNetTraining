using System;
using System.IO;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ConnectionContexts
{
    public class EmployeeConnectionContext
    {
        public StreamReader StreamReader => new StreamReader("employees.json");
        public StreamWriter StreamAppendWriter => new StreamWriter("employees.json", true);
        public StreamWriter StreamReWriter => new StreamWriter("employees.json", false);
    }
}
