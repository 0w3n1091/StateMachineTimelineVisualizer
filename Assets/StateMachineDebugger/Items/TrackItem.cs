#if UNITY_EDITOR
using System.Collections.Generic;
using StateMachineDebugger.Interfaces;
using UnityEngine.Timeline;

namespace StateMachineDebugger.Items
{
    [TrackClipType(typeof(StateItem))]
    public class TrackItem : PlayableTrack, ITimelineItem, IExtendable<StateItem>, IExtendable<EventItem>
    {
        public StateItem activeProcess { get; private set; }
        private List<StateItem> processItems = new();
        private List<EventItem> eventItems = new();

        List<StateItem> IExtendable<StateItem>.ExtendedItems
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

        public bool TryGet(string itemName, out StateItem item)
        {
            foreach (StateItem process in processItems)
            {
                if (process.Clip.displayName != itemName) 
                    continue;
                
                item = process;
                return true;
            }

            item = null;
            return false;
        }

        public StateItem Add(StateItem item)
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