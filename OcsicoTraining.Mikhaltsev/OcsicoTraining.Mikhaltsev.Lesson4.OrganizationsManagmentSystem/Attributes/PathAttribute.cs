using System;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PathAttribute : Attribute
    {
        public PathAttribute(string path) => Path = path;

        public string Path { get; set; }
    }
}
