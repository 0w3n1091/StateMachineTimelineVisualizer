using StateMachinePattern;
using StateMachineVisualizer.Interfaces;
using StateMachineVisualizer.Items;
using UnityEngine;
using Input = UnityEngine.Input;

namespace StateMachineVisualizer.States
{
    public class FirstState : TimelineState
    {
        public FirstState(IStateMachine stateMachine, IStateMachineTimelineController timelineController) : base(stateMachine, timelineController) { }
        
        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new SecondState(stateMachine, timelineController));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                timelineController.AddEvent<RedEventItem>(eventName, trackName);
            }
            
            base.OnProcess();
        }
    }
}