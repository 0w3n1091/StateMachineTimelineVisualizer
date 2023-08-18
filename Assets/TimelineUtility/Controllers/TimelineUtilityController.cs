using System;
using TimelineUtility.Core.Interfaces;
using TimelineUtility.Interfaces;
using TimelineUtility.Items;
using TimelineUtility.Providers;
using TimelineUtility.Timer;
using UnityEditor.Timeline;
using UnityEngine.Timeline;

namespace TimelineUtility.Controllers
{
    public class TimelineUtilityController : ITimelineUtilityController
    {
        private readonly ITimelineAssetProvider assetProvider = new TimelineAssetProvider();
        private readonly ITimePublisher timePublisher;
        private readonly TimelineItem timeline;

        public TimelineUtilityController(ITimePublisher timePublisher)
        {
            this.timePublisher = timePublisher;
            timeline = new TimelineItem(assetProvider.CreateAsset());
        }
        
        public void RefreshTimeline()
        {
            timePublisher.UpdateTime();
            TimelineEditor.Refresh(RefreshReason.ContentsModified);
        }
        
        public void StartProcess(string processName, string trackName, string description)
        {
            if (!timeline.TryGet(trackName, out TrackItem track))
            {
                track = timeline.Root.CreateTrack<TrackItem>(trackName);
                timeline.Add(track);
            }

            if (track.activeProcess != null)
                EndProcess(track.activeProcess);
            
            TimelineClip clip = track.CreateClip<ProcessItem>();
            ProcessItem process = clip.asset as ProcessItem;
            process.Clip = clip;
            process.Clip.start = timePublisher.GetTime();
            process.Clip.displayName = processName;
            process.Description = description;
            
            track.Add(process);

            timePublisher.Subscribe(process);
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }

        public void FinishActiveProcess(string trackName)
        {
            if (!timeline.TryGet(trackName, out TrackItem trackItem))
                throw new Exception($"[{trackName}] track could not be found.");
            
            timePublisher.Unsubscribe(trackItem.activeProcess);
            TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        }
        
        public void EndProcess(ProcessItem processItem)
        {
            timePublisher.Unsubscribe(processItem);
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
    }
}