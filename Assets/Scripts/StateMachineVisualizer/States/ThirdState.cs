using StateMachinePattern;
using StateMachineVisualizer.Interfaces;
using StateMachineVisualizer.Items;
using UnityEngine;

namespace StateMachineVisualizer.States
{
    public class ThirdState : TimelineState
    {
        public ThirdState(IStateMachine stateMachine, IStateMachineTimelineController timelineController) : base(stateMachine, timelineController) { }

        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new FirstState(stateMachine, timelineController));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                timelineController.AddEvent<GreenEventItem>(eventName, trackName);
            }
            
            base.OnProcess();
        }
    }
}