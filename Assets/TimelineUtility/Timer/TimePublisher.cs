using System;
using System.Collections.Generic;

namespace TimelineUtility.Timer
{
    public class TimePublisher : ITimePublisher
    {
        public TimePublisher() => startTime = DateTime.Now.Ticks;
        private readonly List<ITimeSubscriber> subscribers = new();
        private readonly long startTime;
        private long time = 0;

        public void UpdateTime()
        {
            time = DateTime.Now.Ticks - startTime;
            UpdateSubscribers();
        }

        public double GetTime()
        {
            UpdateTime();
            TimeSpan timeSpan = new TimeSpan(time);
            return timeSpan.TotalSeconds;
        }

        public void Subscribe(ITimeSubscriber subscriber) => subscribers.Add(subscriber);
        public void Unsubscribe(ITimeSubscriber subscriber) => subscribers.Remove(subscriber);
        public void UpdateSubscribers()
        {
            TimeSpan timeSpan = new TimeSpan(time);
            
            foreach (ITimeSubscriber subscriber in subscribers)
                subscriber.UpdateTime(timeSpan.TotalSeconds);
        }
    }
}
