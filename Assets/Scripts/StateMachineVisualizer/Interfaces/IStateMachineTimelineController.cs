using StateMachineVisualizer.Items;
using StateMachineVisualizer.Items.Events;

namespace StateMachineVisualizer.Interfaces
{
    public interface IStateMachineTimelineController
    {
        /// <summary>
        /// Refreshes the state machine timeline.
        /// </summary>
        public void RefreshTimeline();
        
        /// <summary>
        /// Starts a new state on the timeline.
        /// </summary>
        /// <param name="stateName">The name of the state.</param>
        /// <param name="trackName">The name of the track.</param>
        public void StartState(string stateName, string trackName);
        
        /// <summary>
        /// Adds an event to the timeline.
        /// </summary>
        /// <typeparam name="TEventItem">Type of the event item.</typeparam>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="trackName">The name of the track.</param>
        public void AddEvent<TEventItem>(string eventName, string trackName) where TEventItem : EventItem;
        
        /// <summary>
        /// Finishes the active state on the timeline.
        /// </summary>
        /// <param name="trackName">The name of the track.</param>
        public void FinishActiveState(string trackName);
    }
}