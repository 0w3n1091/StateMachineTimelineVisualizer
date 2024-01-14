using UnityEngine.Timeline;

namespace StateMachineVisualizer.Interfaces
{
    public interface ITimelineAssetProvider
    {
        /// <summary>
        /// Creates a new instance of TimelineAsset.
        /// </summary>
        /// <returns>The created TimelineAsset instance.</returns>
        public TimelineAsset CreateAsset();
    }
}
