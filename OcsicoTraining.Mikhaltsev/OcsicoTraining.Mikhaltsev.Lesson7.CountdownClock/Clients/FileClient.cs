using System.IO;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock.Clients
{
    public class FileClient
    {
        public void WriteToFile(EventInfo eventInfo) =>
            File.AppendAllText("Log.txt", $"{eventInfo.DateTime.ToLongTimeString()} {eventInfo.Message}");
    }
}
