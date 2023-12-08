#if UNITY_EDITOR
using System;
using StateMachineDebugger.Interfaces;
using StateMachineDebugger.Items;
using StateMachineDebugger.Providers;
using Timer;
using UnityEditor.Timeline;
using UnityEngine.Timeline;

namespace StateMachineDebugger.Controllers
{
    public class StateMachineDebugController : IStateMachineDebugController
    {
        private readonly ITimelineAssetProvider assetProvider = new TimelineAssetProvider();
        private readonly ITimePublisher timePublisher;
        private readonly TimelineItem timeline;

        public StateMachineDebugController(ITimePublisher timePublisher)
        {
            this.timePublisher = timePublisher;
            timeline = new TimelineItem(assetProvider.CreateAsset());
        }
        
        public void RefreshTimeline()
        {
            timePublisher.UpdateTime();
            TimelineEditor.Refresh(RefreshReason.ContentsModified);
        }
        
        public void StartState(string stateName, string trackName, string description)
        {
            if (!timeline.TryGet(trackName, out TrackItem track))
            {
                track = timeline.Root.CreateTrack<TrackItem>(trackName);
                timeline.Add(track);
            }

            if (track.activeProcess != null)
                EndState(track.activeProcess);
            
            TimelineClip clip = track.CreateClip<StateItem>();
            StateItem process = clip.asset as StateItem;
            process.Clip = clip;
            process.Clip.start = timePublisher.GetTime();
            process.Clip.displayName = stateName;
            process.Description = description;
            
            track.Add(process);

            timePublisher.Subscribe(process);
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }
        
        public void AddEvent<TEventItem>(string eventName, string trackName, string description) where TEventItem : EventItem
        {
            if (!timeline.TryGet(trackName, out TrackItem track))
            {
                track = timeline.Root.CreateTrack<TrackItem>(trackName);
                timeline.Add(track);
            }
            
            EventItem eventItem = track.CreateMarker<TEventItem>(timePublisher.GetTime());
            eventItem.name = eventName;
            eventItem.Description = description;
            
            track.Add(eventItem);
            
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }
        
        public void FinishActiveState(string trackName)
        {
            if (!timeline.TryGet(trackName, out TrackItem trackItem))
                throw new Exception($"[{trackName}] track could not be found.");
            
            timePublisher.Unsubscribe(trackItem.activeProcess);
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