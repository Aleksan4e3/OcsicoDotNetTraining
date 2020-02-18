using System.IO;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ConnectionContexts
{
    public class ConnectionContext<T>
    {
        public ConnectionContext(string path) => Path = path;

        public string Path { get; set; }
        public StreamReader StreamReader => new StreamReader(Path);
        public StreamWriter StreamAppendWriter => new StreamWriter(Path, true);
        public StreamWriter StreamReWriter => new StreamWriter(Path, false);
    }
}
