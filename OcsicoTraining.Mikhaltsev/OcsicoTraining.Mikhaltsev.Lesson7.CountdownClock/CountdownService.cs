using System;
using System.Threading;
using System.Threading.Tasks;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock
{
    public class CountdownService
    {
        private bool isRunning = true;

        public event EventHandler<MessageSenderEventArgs> OnEventCreated;

        public void CallEvent(EventInfo eventInfo) =>
            OnEventCreated?.Invoke(this, new MessageSenderEventArgs(eventInfo));

        public EventInfo CreateEventInfo(string message, DateTime dateTime, int milliseconds)
        {
            Thread.Sleep(milliseconds);

            var eventInfo = new EventInfo { Message = message, DateTime = dateTime };

            CallEvent(eventInfo);

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
