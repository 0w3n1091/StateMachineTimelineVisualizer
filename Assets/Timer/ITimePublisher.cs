namespace Timer
{
    public interface ITimePublisher
    {
        /// <summary>
        /// Updates the time.
        /// </summary>
        public void UpdateTime();

        /// <summary>
        /// Subscribes an object to receive time updates.
        /// </summary>
        /// <param name="subscriber">The object that wishes to receive time updates.</param>
        public void Subscribe(ITimeSubscriber subscriber);

        /// <summary>
        /// Unsubscribe from a TimePublisher.
        /// </summary>
        /// <param name="name">The ITimeSubscriber instance to unsubscribe.</param>
        public void Unsubscribe(ITimeSubscriber name);

        /// <summary>
        /// Updates the subscribers.
        /// </summary>
        public void UpdateSubscribers();

        /// <summary>
        /// Returns the current time as a double value.
        /// </summary>
        /// <returns>The current time in seconds as a double value.</returns>
        public double GetTime();
    }
}
