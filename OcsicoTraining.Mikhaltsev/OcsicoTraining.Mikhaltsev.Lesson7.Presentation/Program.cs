using System;
using OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock;
using OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock.Clients;

namespace OcsicoTraining.Mikhaltsev.Lesson7.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            RunCountdownClockTask();
            Console.ReadKey();
        }

        private static void RunCountdownClockTask()
        {
            var fileClient = new FileClient();
            var consoleClient = new ConsoleClient();
            var service = new CountdownService();

            service.OnEventCreated += (sender, args) => consoleClient.WriteToConsole(args.EventInfo);
            service.OnEventCreated += (sender, args) => fileClient.WriteToFile(args.EventInfo);

            service.GenerateEvenTask();

            service.CreateEventInfo("OneSomeEvent", DateTime.Now, 1000);
            service.CreateEventInfo("TwoSomeEvent", DateTime.Now, 3000);
            service.CreateEventInfo("ThreeSomeEvent", DateTime.Now, 2000);
            service.CreateEventInfo("FourSomeEvent", DateTime.Now, 2000);
            service.CreateEventInfo("FiveSomeEvent", DateTime.Now, 4000);

            service.StopGenerateEvent();
        }
    }
}
