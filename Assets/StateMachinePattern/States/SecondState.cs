using StateMachineDebugger.Interfaces;
using StateMachineDebugger.Items;
using StateMachinePattern.Base;
using UnityEngine;

namespace StateMachinePattern.States
{
    public class SecondState : State
    {
        public SecondState(IStateMachine stateMachine, IStateMachineDebugController debugController, string stateDescription = null) : base(stateMachine, debugController, stateDescription)
        {
        }

        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new ThirdState(stateMachine, debugController));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                string eventDesc = "This is second state test event.";
                
                debugController.AddEvent<BlueEventItem>(eventName, trackName, eventDesc);
            }
        }
    }
}