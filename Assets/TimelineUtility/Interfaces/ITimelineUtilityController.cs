using TimelineUtility.Items;

namespace TimelineUtility.Interfaces
{
    public interface ITimelineUtilityController
    {
        public void RefreshTimeline();
        public void StartProcess(string processName, string trackName, string description);
        public void FinishActiveProcess(string trackName);
        public void AddEvent<TEventItem>(string eventName, string trackName, string description) where TEventItem : EventItem;
    }
}