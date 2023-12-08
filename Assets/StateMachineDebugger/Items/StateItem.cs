#if UNITY_EDITOR
using StateMachineDebugger.Interfaces;
using Timer;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StateMachineDebugger.Items
{
    [System.Serializable]
    public class StateItem : PlayableAsset, ITimelineClipAsset, ITimelineItem, ITimeSubscriber
    {
        public ClipCaps clipCaps => ClipCaps.None;
        public TimelineClip Clip;
        
        [TextArea] public string Description;
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            Playable playable = new Playable();
            return playable;
        }
        
        /// <summary>
        /// Updates state duration.
        /// </summary>
        /// <param name="time">Current time.</param>
        public void UpdateTime(double time)
        {
            Clip.duration = time - Clip.start;
        }
    }
}
#endif