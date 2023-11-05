using System.Collections.Generic;
using TimelineUtility.Interfaces;
using UnityEngine.Timeline;

namespace TimelineUtility.Items
{
    public class TimelineItem : ITimelineItem, IExtendable<TrackItem>
    {
        public TimelineItem(TimelineAsset root)
        {
            Root = root;
        }
        
        public readonly TimelineAsset Root;
        private List<TrackItem> extendedItems = new();

        List<TrackItem> IExtendable<TrackItem>.ExtendedItems
        {
            get => extendedItems;
            set => extendedItems = value;
        }

        public bool TryGet(string itemName, out TrackItem item)
        {
            foreach (TrackItem track in extendedItems)
            {
                if (track.name == itemName)
                {
                    item = track;
                    return true;
                }
            }

            item = null;
            return false;
        }

        public TrackItem Add(TrackItem item)
        {
            extendedItems.Add(item);
            return item;
        }
    }
}