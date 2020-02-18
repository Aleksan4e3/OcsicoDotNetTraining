using System;
using System.Threading;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock
{
    public class CountdownService
    {
        private readonly Dispatcher dispatcher;
        private bool flag = true;

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
            while (flag)
            {
                Thread.Sleep(1000);

                CreateEventInfo("elapsed 1 second", DateTime.Now, 0);
            }
        }

        public void StopGenerateEvent() => flag = false;
    }
}
