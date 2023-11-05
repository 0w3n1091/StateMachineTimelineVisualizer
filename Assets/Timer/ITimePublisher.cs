namespace Timer
{
    public interface ITimePublisher
    {
        /// <summary>
        /// Updates time. Call it in one of MonoBehaviours Update() method.
        /// </summary>
        public void UpdateTime();
        
        /// <summary>
        /// Subscribe to TimePublisher.
        /// </summary>
        /// <param name="subscriber"></param>
        public void Subscribe(ITimeSubscriber subscriber);
        
        /// <summary>
        /// Unsubscribe from TimePublisher.
        /// </summary>
        /// <param name="name"></param>
        public void Unsubscribe(ITimeSubscriber name);
        
        /// <summary>
        /// Update Subscribers.
        /// </summary>
        public void UpdateSubscribers();
        
        /// <summary>
        /// Returns current time.
        /// </summary>
        /// <returns></returns>
        public double GetTime();
    }
}
