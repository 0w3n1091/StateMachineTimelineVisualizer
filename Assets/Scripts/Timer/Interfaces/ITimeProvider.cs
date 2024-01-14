using System;

namespace Timer.Interfaces
{
    /// <summary>
    /// Represents an interface for providing current date and time.
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// Gets the current date and time.
        /// </summary>
        /// <returns>The current date and time.</returns>
        public DateTime GetNow();
    }
}