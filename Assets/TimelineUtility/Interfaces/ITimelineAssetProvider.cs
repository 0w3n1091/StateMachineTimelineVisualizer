using UnityEngine.Timeline;

namespace TimelineUtility.Interfaces
{
    public interface ITimelineAssetProvider
    {
        /// <summary>
        /// Creates new timeline asset.
        /// </summary>
        /// <returns></returns>
        public TimelineAsset CreateAsset();
    }
}
