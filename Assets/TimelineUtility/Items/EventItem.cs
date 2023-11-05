#if UNITY_EDITOR
using TimelineUtility.Interfaces;
using UnityEngine;
using UnityEngine.Timeline;

namespace TimelineUtility.Items
{
    public class EventItem : Marker, ITimelineItem
    {
        public string EventName;
        [TextArea] public string Description;
    }
}
#endif