namespace TimelineUtility.Timer
{
    public interface ITimePublisher
    {
        public void UpdateTime();
        public void Subscribe(ITimeSubscriber subscriber);
        public void Unsubscribe(ITimeSubscriber name);
        public void UpdateSubscribers();
        public double GetTime();
    }
}
