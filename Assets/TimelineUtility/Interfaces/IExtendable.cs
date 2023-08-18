using System.Collections.Generic;
using TimelineUtility.Interfaces;

namespace TimelineUtility.Core.Interfaces
{
    public interface IExtendable<TItem> where TItem : ITimelineItem
    {
        public List<TItem> ExtendedItems { get; protected set; }
        
        public bool TryGet(string itemName, out TItem item);
        public TItem Add(TItem item);
    }
}
