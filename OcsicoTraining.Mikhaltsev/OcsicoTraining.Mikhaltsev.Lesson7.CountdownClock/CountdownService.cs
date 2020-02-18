using System;
using System.Threading;
using System.Threading.Tasks;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock
{
    public class CountdownService
    {
        private readonly Dispatcher dispatcher;
        private bool isRunning = true;

        public CountdownService(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public EventInfo CreateEventInfo(string message, DateTime dateTime, int milliseconds)
        {
            Thread.Sleep(milliseconds);

            var eventInfo = new EventInfo { Message = message, DateTime = dateTime };

            dispatcher.CallEvent(eventInfo);

            return eventInfo;
        }

        public void GenerateNewEvent()
        {
            while (isRunning)
            {
                Thread.Sleep(1000);

                CreateEventInfo("elapsed 1 second", DateTime.Now, 0);
            }
        }

        public Task GenerateEvenTask() => Task.Run(GenerateNewEvent);

        public void StopGenerateEvent() => isRunning = false;
    }
}
