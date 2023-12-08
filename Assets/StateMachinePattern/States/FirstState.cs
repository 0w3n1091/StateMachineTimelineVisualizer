using StateMachineDebugger.Interfaces;
using StateMachineDebugger.Items;
using StateMachinePattern.Base;
using UnityEngine;
using Input = UnityEngine.Input;

namespace StateMachinePattern.States
{
    public class FirstState : State
    {
        public FirstState(IStateMachine stateMachine, IStateMachineDebugController debugController, string stateDescription = null) : base(stateMachine, debugController, stateDescription)
        {
        }

        public override void OnProcess()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.NextState(new SecondState(stateMachine, debugController));
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                string eventName = RandomStringGenerator.GenerateRandomString(5);
                string eventDesc = "This is First state test event.";
                
                debugController.AddEvent<RedEventItem>(eventName, trackName, eventDesc);
            }
        }
    }
}