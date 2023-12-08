#if UNITY_EDITOR
using StateMachineDebugger.Interfaces;
using UnityEngine;
using UnityEngine.Timeline;

namespace StateMachineDebugger.Items
{
    public class EventItem : Marker, ITimelineItem
    {
        public string EventName;
        [TextArea] public string Description;
    }
}
#endif