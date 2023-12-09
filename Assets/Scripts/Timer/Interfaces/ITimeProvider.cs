using System;

namespace Timer.Interfaces
{
    public interface ITimeProvider
    {
        /// <summary>
        /// Retrieves the current date and time.
        /// </summary>
        /// <returns>
        /// The current date and time.
        /// </returns>
        public DateTime GetNow();
    }
}