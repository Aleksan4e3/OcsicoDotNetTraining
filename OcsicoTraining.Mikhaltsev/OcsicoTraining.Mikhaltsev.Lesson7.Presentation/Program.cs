using System;
using System.Threading.Tasks;
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
            var dispatcher = new Dispatcher();
            var fileClient = new FileClient();
            var consoleClient = new ConsoleClient();

            dispatcher.OnEventCreated += (sender, args) => consoleClient.WriteToConsole(args.EventInfo);
            dispatcher.OnEventCreated += (sender, args) => fileClient.WriteToFile(args.EventInfo);

            var service = new CountdownService(dispatcher);

            Task.Run(() => service.GenerateNewEvent());

            service.CreateEventInfo("OneSomeEvent", DateTime.Now, 1000);
            service.CreateEventInfo("TwoSomeEvent", DateTime.Now, 3000);
            service.CreateEventInfo("ThreeSomeEvent", DateTime.Now, 2000);
            service.CreateEventInfo("FourSomeEvent", DateTime.Now, 2000);
            service.CreateEventInfo("FiveSomeEvent", DateTime.Now, 4000);

            service.StopGenerateEvent();
        }
    }
}
