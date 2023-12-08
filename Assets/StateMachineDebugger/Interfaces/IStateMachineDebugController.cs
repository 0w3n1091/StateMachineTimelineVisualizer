using StateMachineDebugger.Items;

namespace StateMachineDebugger.Interfaces
{
    public interface IStateMachineDebugController
    {
        /// <summary>
        /// Refreshes the timeline of the editor. Call it in any MonoBehaviour Update() method.
        /// </summary>
        public void RefreshTimeline();

        /// <summary>
        /// Starts a new state on the timeline.
        /// </summary>
        /// <param name="stateName">The name of the state.</param>
        /// <param name="trackName">The track on which the state will be placed.</param>
        /// <param name="description">The description of the state.</param>
        public void StartState(string stateName, string trackName, string description);

        /// <summary>
        /// FFinishes the active state on specified track.
        /// </summary>
        /// <param name="trackName">The name of the track to stop.</param>
        public void FinishActiveState(string trackName);

        /// <summary>
        /// Adds an event to a track.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="trackName">The name of the track on which the event will be placed.</param>
        /// <param name="description">The description of the event.</param>
        /// <typeparam name="TEventItem">The type of the event item, for example RedEvent. Used for graphics representation only.</typeparam>
        public void AddEvent<TEventItem>(string eventName, string trackName, string description) where TEventItem : EventItem;
    }
}