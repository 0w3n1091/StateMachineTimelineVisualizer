using System;
using Timer.Interfaces;

namespace Timer
{
    public class LocalTimeProvider : ITimeProvider
    {
        public DateTime GetNow() => DateTime.Now;
    }
}