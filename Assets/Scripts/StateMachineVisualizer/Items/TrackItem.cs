#if UNITY_EDITOR
using System.Collections.Generic;
using StateMachineVisualizer.Interfaces;
using StateMachineVisualizer.Items.Events;
using UnityEngine.Timeline;

namespace StateMachineVisualizer.Items
{
    /// <summary>
    /// Represents a track item in the state machine timeline.
    /// </summary>
    [TrackClipType(typeof(StateItem))]
    public class TrackItem : PlayableTrack, ITimelineItem
    {
        public StateItem activeState { get; private set; }
        private readonly List<StateItem> stateItems = new();
        private readonly List<EventItem> eventItems = new();
        
        /// <summary>
        /// Tries to get an event item by name.
        /// </summary>
        /// <param name="itemName">The name of the event item.</param>
        /// <param name="item">The retrieved event item, if found; otherwise, null.</param>
        /// <returns>True if the event item is found, false otherwise.</returns>
        public bool TryGet(string itemName, out EventItem item)
        {
            foreach (EventItem eventItem in eventItems)
            {
                if (eventItem.name != itemName)
                    continue;

                item = eventItem;
                return true;
            }

            item = null;
            return false;
        }
        
        /// <summary>
        /// Tries to get a state item by name.
        /// </summary>
        /// <param name="itemName">The name of the state item.</param>
        /// <param name="item">The retrieved state item, if found; otherwise, null.</param>
        /// <returns>True if the state item is found, false otherwise.</returns>
        public bool TryGet(string itemName, out StateItem item)
        {
            foreach (StateItem process in stateItems)
            {
                if (process.Clip.displayName != itemName) 
                    continue;
                
                item = process;
                return true;
            }

            item = null;
            return false;
        }
        
        /// <summary>
        /// Adds a state item to the track.
        /// </summary>
        /// <param name="item">The state item to add.</param>
        public void Add(StateItem item)
        {
            activeState = item;
            stateItems.Add(item);
        }
        
        /// <summary>
        /// Adds an event item to the track.
        /// </summary>
        /// <param name="item">The event item to add.</param>
        public void Add(EventItem item) => eventItems.Add(item);
    }
}
#endif