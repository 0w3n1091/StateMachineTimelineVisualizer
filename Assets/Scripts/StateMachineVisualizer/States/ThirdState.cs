using StateMachinePattern;
using StateMachineVisualizer.Interfaces;
using StateMachineVisualizer.Items;
using StateMachineVisualizer.Items.Events;
using UnityEngine;

namespace StateMachineVisualizer.States
{
    public class ThirdState : TimelineState
    {
        public ThirdState(TimelineStateMachine stateMachine) : base(stateMachine) { }

        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new FourthState(timelineStateMachine));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                timelineStateMachine.Controller.AddEvent<GreenEventItem>(eventName, trackName);
            }
            
            base.OnProcess();
        }
    }
}