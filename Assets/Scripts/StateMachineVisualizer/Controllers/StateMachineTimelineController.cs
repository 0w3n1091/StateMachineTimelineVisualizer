#if UNITY_EDITOR
using System;
using StateMachineVisualizer.Interfaces;
using StateMachineVisualizer.Items;
using StateMachineVisualizer.Providers;
using Timer.Interfaces;
using UnityEditor.Timeline;
using UnityEngine.Timeline;

namespace StateMachineVisualizer.Controllers
{
    public class StateMachineTimelineController : IStateMachineTimelineController
    {
        private readonly ITimelineAssetProvider assetProvider = new TimelineAssetProvider();
        private readonly ITimePublisher timePublisher;
        private readonly TimelineItem timeline;

        public StateMachineTimelineController(ITimePublisher timePublisher)
        {
            this.timePublisher = timePublisher;
            timeline = new TimelineItem(assetProvider.CreateAsset());
        }
        
        public void RefreshTimeline()
        {
            timePublisher.UpdateTime();
            TimelineEditor.Refresh(RefreshReason.ContentsModified);
        }
        
        public void StartState(string stateName, string trackName)
        {
            if (!timeline.TryGet(trackName, out TrackItem track))
            {
                track = timeline.Root.CreateTrack<TrackItem>(trackName);
                timeline.Add(track);
            }

            if (track.activeState != null)
                EndState(track.activeState);
            
            TimelineClip clip = track.CreateClip<StateItem>();
            StateItem process = clip.asset as StateItem;
            process.Clip = clip;
            process.Clip.start = timePublisher.GetTime();
            process.Clip.displayName = stateName;
            
            track.Add(process);

            timePublisher.Subscribe(process);
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }
        
        public void AddEvent<TEventItem>(string eventName, string trackName) where TEventItem : EventItem
        {
            if (!timeline.TryGet(trackName, out TrackItem track))
            {
                track = timeline.Root.CreateTrack<TrackItem>(trackName);
                timeline.Add(track);
            }
            
            EventItem eventItem = track.CreateMarker<TEventItem>(timePublisher.GetTime());
            eventItem.name = eventName;
            
            track.Add(eventItem);
            
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }
        
        public void FinishActiveState(string trackName)
        {
            if (!timeline.TryGet(trackName, out TrackItem trackItem))
                throw new Exception($"[{trackName}] track could not be found.");
            
            timePublisher.Unsubscribe(trackItem.activeState);
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }
        
        /// <summary>
        /// Ends specific event.
        /// </summary>
        /// <param name="stateItem">Specific ongoing processItem.</param>
        private void EndState(StateItem stateItem)
        {
            timePublisher.Unsubscribe(stateItem);
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }
    }
}
#endif