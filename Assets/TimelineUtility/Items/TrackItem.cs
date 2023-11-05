#if UNITY_EDITOR
using System.Collections.Generic;
using TimelineUtility.Interfaces;
using UnityEngine.Timeline;

namespace TimelineUtility.Items
{
    [TrackClipType(typeof(ProcessItem))]
    public class TrackItem : PlayableTrack, ITimelineItem, IExtendable<ProcessItem>, IExtendable<EventItem>
    {
        public ProcessItem activeProcess { get; private set; }
        private List<ProcessItem> processItems = new();
        private List<EventItem> eventItems = new();

        List<ProcessItem> IExtendable<ProcessItem>.ExtendedItems
        {
            get => processItems;
            set => processItems = value;
        }

        public bool TryGet(string itemName, out EventItem item)
        {
            foreach (EventItem eventItem in eventItems)
            {
                if (eventItem.name == itemName)
                {
                    item = eventItem;
                    return true;
                }
            }

            item = null;
            return false;
        }

        public EventItem Add(EventItem item)
        {
            eventItems.Add(item);
            return item;
        }

        public bool TryGet(string itemName, out ProcessItem item)
        {
            foreach (ProcessItem process in processItems)
            {
                if (process.Clip.displayName != itemName) 
                    continue;
                
                item = process;
                return true;
            }

            item = null;
            return false;
        }

        public ProcessItem Add(ProcessItem item)
        {
            activeProcess = item;
            processItems.Add(item);
            return item;
        }

        List<EventItem> IExtendable<EventItem>.ExtendedItems
        {
            get => eventItems;
            set => eventItems = value;
        }
    }
}
#endif