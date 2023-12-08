using StateMachineDebugger.Interfaces;
using StateMachineDebugger.Items;
using StateMachinePattern.Base;
using UnityEngine;

namespace StateMachinePattern.States
{
    public class ThirdState : State
    {
        public ThirdState(IStateMachine stateMachine, IStateMachineDebugController debugController, string stateDescription = null) : base(stateMachine, debugController, stateDescription)
        {
        }

        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new FirstState(stateMachine, debugController));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                string eventDesc = "This is third state test event.";
                
                debugController.AddEvent<GreenEventItem>(eventName, trackName, eventDesc);
            }
        }
    }
}