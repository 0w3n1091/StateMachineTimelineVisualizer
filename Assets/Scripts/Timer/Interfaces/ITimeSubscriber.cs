namespace Timer.Interfaces
{
    /// <summary>
    /// Represents an interface for objects that can subscribe to time-related events.
    /// </summary>
    public interface ITimeSubscriber
    {
        /// <summary>
        /// Updates the subscriber with the latest time.
        /// </summary>
        /// <param name="time">The current time.</param>
        public void UpdateTime(double time);
    }
}