using StateMachineVisualizer.Items.Events;
using UnityEngine;
using Input = UnityEngine.Input;

namespace StateMachineVisualizer.States
{
    public class FirstState : TimelineState
    {
        public FirstState(TimelineStateMachine stateMachine) : base(stateMachine) { }
        
        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new SecondState(timelineStateMachine));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                timelineStateMachine.Controller.AddEvent<RedEventItem>(eventName, trackName);
            }
            
            base.OnProcess();
        }
    }
}