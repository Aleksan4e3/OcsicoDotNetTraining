using System;
using System.Threading;
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

            service.OnOneSecond += (sender, args) => consoleClient.WriteToConsole(args.EventInfo);
            service.OnOneSecond += (sender, args) => fileClient.WriteToFile(args.EventInfo);

            service.OnTenSecond += (sender, args) => consoleClient.WriteToConsole(args.EventInfo);

            service.Start();

            Thread.Sleep(11000);
            service.Stop();
        }
    }
}
