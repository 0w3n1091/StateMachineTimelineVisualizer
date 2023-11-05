using System;
using TimelineUtility.Controllers;
using TimelineUtility.Interfaces;
using TimelineUtility.Items;
using TimelineUtility.Timer;
using UnityEditor.Timeline;
using UnityEngine;

namespace TimelineUtility
{
    public class TimelineUtilityTester : MonoBehaviour
    {
        private ITimePublisher timePublisher;
        private ITimelineUtilityController controller;

        [Header("Add Event")] 
        [SerializeField] private string eventName;
        [SerializeField] private string eventTrackName;
        [SerializeField] [TextArea] public string eventDescription;
        
        [Header("Add Process")] 
        [SerializeField] private string processName;
        [SerializeField] private string processTrackName;
        [SerializeField] [TextArea] public string processDescription;

        private void Start()
        {
            timePublisher = new TimePublisher();
            controller = new TimelineUtilityController(timePublisher);
        }

        private void Update() => controller.RefreshTimeline();

        public void AddEvent() => controller.AddEvent<RedEventItem>(eventName, eventTrackName, eventDescription);

        public void AddProcess() => controller.StartProcess(processName, processTrackName, processDescription);

        public void FinishProcess() => controller.FinishActiveProcess(processTrackName);
    }
}