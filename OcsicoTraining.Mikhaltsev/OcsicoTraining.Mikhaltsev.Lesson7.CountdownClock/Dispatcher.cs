using System;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock
{
    public class Dispatcher
    {
        public event EventHandler<MessageSenderEventArgs> OnEventCreated;

        public void CallEvent(EventInfo eventInfo) =>
            OnEventCreated?.Invoke(this, new MessageSenderEventArgs(eventInfo));
    }
}
