#if UNITY_EDITOR
using System.Collections.Generic;
using StateMachineVisualizer.Interfaces;
using UnityEngine.Timeline;

namespace StateMachineVisualizer.Items
{
    /// <summary>
    /// Represents a timeline item in the state machine.
    /// </summary>
    public class TimelineItem : ITimelineItem
    {
        public TimelineItem(TimelineAsset root)
        {
            Root = root;
        }
        
        public readonly TimelineAsset Root;
        
        private readonly List<TrackItem> extendedItems = new List<TrackItem>();

        /// <summary>
        /// Tries to get a track item by name.
        /// </summary>
        /// <param name="itemName">The name of the track item.</param>
        /// <param name="item">The retrieved track item, if found; otherwise, null.</param>
        /// <returns>True if the track item is found, false otherwise.</returns>
        public bool TryGet(string itemName, out TrackItem item)
        {
            foreach (TrackItem track in extendedItems)
            {
                if (track.name != itemName)
                    continue;

                item = track;
                return true;
            }

            item = null;
            return false;
        }

        /// <summary>
        /// Adds a track item to the list of extended items.
        /// </summary>
        /// <param name="item">The track item to add.</param>
        public void Add(TrackItem item) => extendedItems.Add(item);
    }
}
#endif