#if UNITY_EDITOR
using System.Collections.Generic;
using StateMachineVisualizer.Interfaces;
using UnityEngine.Timeline;

namespace StateMachineVisualizer.Items
{
    [TrackClipType(typeof(StateItem))]
    public class TrackItem : PlayableTrack, ITimelineItem
    {
        public StateItem activeState { get; private set; }
        private readonly List<StateItem> stateItems = new();
        private readonly List<EventItem> eventItems = new();

        /// <summary>
        /// Tries to get an event item with the provided name.
        /// </summary>
        /// <param name="itemName">The name of the event item to search for.</param>
        /// <param name="item">When this method returns, contains the event item with the specified name, if found; otherwise, null.</param>
        /// <returns>
        /// true if the event item with the specified name is found; otherwise, false.
        /// </returns>
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
        /// Tries to get the state item with the provided  name.
        /// </summary>
        /// <param name="itemName">The name of the state item to search for.</param>
        /// <param name="item">When this method returns, contains the state item with the specified item name, if found; otherwise, null.</param>
        /// <returns>True if the state item with the specified item name is found; otherwise, false.</returns>
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
        /// Adds a StateItem to the active state and list of stateItems.
        /// </summary>
        /// <param name="item">The StateItem to add.</param>
        public void Add(StateItem item)
        {
            activeState = item;
            stateItems.Add(item);
        }

        /// <summary>
        /// Adds an EventItem to the eventItems collection.
        /// </summary>
        /// <param name="item">The EventItem to add.</param>
        public void Add(EventItem item) => eventItems.Add(item);
    }
}
#endif