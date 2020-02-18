using System;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock.Clients
{
    public class ConsoleClient
    {
        public void WriteToConsole(EventInfo eventInfo) =>
            Console.WriteLine($"{eventInfo.DateTime.ToLongTimeString()} {eventInfo.Message}");
    }
}
