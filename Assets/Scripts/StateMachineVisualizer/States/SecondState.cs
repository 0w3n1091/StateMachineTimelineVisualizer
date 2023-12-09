using StateMachinePattern;
using StateMachineVisualizer.Interfaces;
using StateMachineVisualizer.Items;
using UnityEngine;

namespace StateMachineVisualizer.States
{
    public class SecondState : TimelineState
    {
        public SecondState(IStateMachine stateMachine, IStateMachineTimelineController timelineController) : base(stateMachine, timelineController) { }

        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new ThirdState(stateMachine, timelineController));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                timelineController.AddEvent<BlueEventItem>(eventName, trackName);
            }
            
            base.OnProcess();
        }
    }
}