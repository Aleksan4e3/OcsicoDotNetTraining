using System.IO;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock.Clients
{
    public class FileClient
    {
        private static readonly object SynchronizationObject = new object();

        public void WriteToFile(EventInfo eventInfo)
        {
            lock (SynchronizationObject)
            {
                File.AppendAllText("Log.txt", $"{eventInfo.DateTime.ToLongTimeString()} {eventInfo.Message}\n");
            }
        }
    }
}
