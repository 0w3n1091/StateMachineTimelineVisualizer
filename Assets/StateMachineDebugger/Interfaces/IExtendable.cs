using System.Collections.Generic;

namespace TimelineUtility.Interfaces
{
    public interface IExtendable<TItem> where TItem : ITimelineItem
    {
        public List<TItem> ExtendedItems { get; protected set; }
        
        /// <summary>
        /// Tries to retrieve item from ExtendedItems list.
        /// </summary>
        /// <param name="itemName">Item name.</param>
        /// <param name="item">Retrieved item.</param>
        /// <returns></returns>
        public bool TryGet(string itemName, out TItem item);
        
        /// <summary>
        /// Adds item to ExtendedItems list.
        /// </summary>
        /// <param name="item">Specific item.</param>
        /// <returns></returns>
        public TItem Add(TItem item);
    }
}
