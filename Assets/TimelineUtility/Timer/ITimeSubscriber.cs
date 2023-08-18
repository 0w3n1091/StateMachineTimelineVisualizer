using UnityEngine.Timeline;

namespace TimelineUtility.Timer
{
    public interface ITimeSubscriber
    {
        public void UpdateTime(double time);
    }
}