using System.Collections.Generic;

namespace StateMachineDebugger.Interfaces
{
    public interface IExtendable<TItem> where TItem : ITimelineItem
    {
        public List<TItem> ExtendedItems { get; protected set; }

        /// <summary>
        /// Tries to retrieve an item from the ExtendedItems list.
        /// </summary>
        /// <param name="itemName">The name of the item to retrieve.</param>
        /// <param name="item">Output parameter to receive the retrieved item.</param>
        /// <returns>
        /// <c>true</c> if the item is found and retrieved; otherwise, <c>false</c>.
        /// </returns>
        public bool TryGet(string itemName, out TItem item);

        /// <summary>
        /// Adds an item to the ExtendedItems collection.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        /// <returns>The added item.</returns>
        public TItem Add(TItem item);
    }
}
