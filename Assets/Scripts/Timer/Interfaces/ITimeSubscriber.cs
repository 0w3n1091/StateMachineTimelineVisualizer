namespace Timer.Interfaces
{
    public interface ITimeSubscriber
    {
        /// <summary>
        /// Updates the time value.
        /// </summary>
        /// <param name="time">The new time value.</param>
        public void UpdateTime(double time);
    }
}