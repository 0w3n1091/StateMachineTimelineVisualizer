#if UNITY_EDITOR
using TimelineUtility.Interfaces;
using Timer;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineUtility.Items
{
    [System.Serializable]
    public class ProcessItem : PlayableAsset, ITimelineClipAsset, ITimelineItem, ITimeSubscriber
    {
        public ClipCaps clipCaps => ClipCaps.None;
        public TimelineClip Clip;
        
        [TextArea] public string Description;
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            Playable playable = new();
            return playable;
        }
        
        /// <summary>
        /// Updates Process duration.
        /// </summary>
        /// <param name="time">Current time.</param>
        public void UpdateTime(double time)
        {
            Clip.duration = time - Clip.start;
        }
    }
}
#endif