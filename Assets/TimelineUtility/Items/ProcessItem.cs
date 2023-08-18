using TimelineUtility.Core.Interfaces;
using TimelineUtility.Interfaces;
using TimelineUtility.Timer;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;
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

        public void UpdateTime(double time)
        {
            Clip.duration = time - Clip.start;
        }
    }
}