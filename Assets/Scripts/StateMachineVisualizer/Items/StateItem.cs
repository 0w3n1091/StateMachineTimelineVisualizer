#if UNITY_EDITOR
using StateMachineVisualizer.Interfaces;
using Timer.Interfaces;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace StateMachineVisualizer.Items
{
    /// <summary>
    /// Represents a state item in the state machine timeline.
    /// </summary>
    [System.Serializable]
    public class StateItem : PlayableAsset, ITimelineClipAsset, ITimelineItem, ITimeSubscriber
    {
        public ClipCaps clipCaps => ClipCaps.None;
        public TimelineClip Clip;
        
        /// <summary>
        /// Creates a playable instance for the state item.
        /// </summary>
        /// <param name="graph">The playable graph.</param>
        /// <param name="owner">The owner GameObject.</param>
        /// <returns>The created playable instance.</returns>
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            Playable playable = new Playable();
            return playable;
        }
        
        /// <summary>
        /// Updates the duration of the timeline clip based on the specified time.
        /// </summary>
        /// <param name="time">The current time.</param>
        public void UpdateTime(double time)
        {
            Clip.duration = time - Clip.start;
        }
    }
}
#endif