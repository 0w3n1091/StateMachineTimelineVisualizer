using System;
using System.Collections.Generic;
using Timer.Interfaces;

namespace Timer
{
    /// <summary>
    /// Publishes time updates to subscribers.
    /// </summary>
    public class TimePublisher : ITimePublisher
    {
        private readonly List<ITimeSubscriber> subscribers = new();
        private readonly ITimeProvider timeProvider;
        private readonly long startTicks; 
        private long nowTicks = 0;
        
        public TimePublisher(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
            startTicks = timeProvider.GetNow().Ticks;
        }
        
        public void UpdateTime()
        {
            nowTicks = timeProvider.GetNow().Ticks - startTicks;
            UpdateSubscribers();
        }

        public double GetTime()
        {
            UpdateTime();
            TimeSpan timeSpan = new TimeSpan(nowTicks);
            return timeSpan.TotalSeconds;
        }

        public void Subscribe(ITimeSubscriber subscriber) => subscribers.Add(subscriber);
        public void Unsubscribe(ITimeSubscriber subscriber) => subscribers.Remove(subscriber);
        public void UpdateSubscribers()
        {
            TimeSpan timeSpan = new TimeSpan(nowTicks);
            
            foreach (ITimeSubscriber subscriber in subscribers)
                subscriber.UpdateTime(timeSpan.TotalSeconds);
        }
    }
}
