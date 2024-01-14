namespace Timer.Interfaces
{
    /// <summary>
    /// Represents an interface for publishing and managing time-related events.
    /// </summary>
    public interface ITimePublisher
    {
        /// <summary>
        /// Updates the current time.
        /// </summary>
        public void UpdateTime();

        /// <summary>
        /// Subscribes an object to receive time-related events.
        /// </summary>
        /// <param name="subscriber">The subscriber to be added.</param>
        public void Subscribe(ITimeSubscriber subscriber);

        /// <summary>
        /// Unsubscribes an object from receiving time-related events.
        /// </summary>
        /// <param name="subscriber">The subscriber to be removed.</param>
        public void Unsubscribe(ITimeSubscriber subscriber);

        /// <summary>
        /// Updates all subscribed objects with the latest time.
        /// </summary>
        public void UpdateSubscribers();

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>The current time.</returns>
        public double GetTime();
    }
}