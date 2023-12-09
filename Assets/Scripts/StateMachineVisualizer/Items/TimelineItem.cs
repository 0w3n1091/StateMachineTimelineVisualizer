#if UNITY_EDITOR
using System.Collections.Generic;
using StateMachineVisualizer.Interfaces;
using UnityEngine.Timeline;

namespace StateMachineVisualizer.Items
{
    public class TimelineItem : ITimelineItem
    {
        public TimelineItem(TimelineAsset root)
        {
            Root = root;
        }
        
        public readonly TimelineAsset Root;
        private readonly List<TrackItem> extendedItems = new();
        
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

        public void Add(TrackItem item) => extendedItems.Add(item);
    }
}
#endif