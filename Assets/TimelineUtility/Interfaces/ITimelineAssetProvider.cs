using UnityEngine.Timeline;

namespace TimelineUtility.Interfaces
{
    public interface ITimelineAssetProvider
    {
        public TimelineAsset CreateAsset();
    }
}