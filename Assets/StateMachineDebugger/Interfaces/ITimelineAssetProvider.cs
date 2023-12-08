using UnityEngine.Timeline;

namespace StateMachineDebugger.Interfaces
{
    public interface ITimelineAssetProvider
    {
        /// <summary>
        /// Creates a new timeline asset.
        /// </summary>
        /// <returns>The newly created timeline asset.</returns>
        public TimelineAsset CreateAsset();
    }
}
