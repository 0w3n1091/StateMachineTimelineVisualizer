using TimelineUtility.Items;

namespace TimelineUtility.Interfaces
{
    public interface ITimelineUtilityController
    {
        /// <summary>
        /// Refreshes Editor. Call it in any of your MonoBehaviour Update() method.
        /// </summary>
        public void RefreshTimeline();
        
        /// <summary>
        /// Starts new process on the timeline. 
        /// </summary>
        /// <param name="processName">Process name.</param>
        /// <param name="trackName">The track on which the process will be placed.</param>
        /// <param name="description">Process description.</param>
        public void StartProcess(string processName, string trackName, string description);
        
        /// <summary>
        /// Finishes active process on track.
        /// </summary>
        /// <param name="trackName">Track name.</param>
        /// <exception cref="Exception">Throws when track could not be found.</exception>
        public void FinishActiveProcess(string trackName);
        
        /// <summary>
        /// Adds event to a track.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="trackName">Track name on which event will be placed.</param>
        /// <param name="description">Event description.</param>
        /// <typeparam name="TEventItem">Event type, for example RedEvent. For graphics representation only.</typeparam>
        public void AddEvent<TEventItem>(string eventName, string trackName, string description) where TEventItem : EventItem;
    }
}