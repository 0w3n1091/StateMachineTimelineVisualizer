using System;
using Timer.Interfaces;

namespace Timer
{
    /// <summary>
    /// Provides the current local time.
    /// </summary>
    public class LocalTimeProvider : ITimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}