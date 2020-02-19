using System;

namespace OcsicoTraining.Mikhaltsev.Lesson7.CountdownClock
{
    public class MessageSenderEventArgs : EventArgs
    {
        public MessageSenderEventArgs(EventInfo eventInfo)
        {
            EventInfo = eventInfo;
        }

        public EventInfo EventInfo { get; set; }
    }
}
