#if UNITY_EDITOR
using StateMachineDebugger.Controllers;
using StateMachineDebugger.Interfaces;
using StateMachinePattern.States;
using Timer;
using UnityEngine;
using StateMachine = StateMachinePattern.Base.StateMachine;

namespace StateMachineDebugger
{
    public class TimelineUtilityTester : MonoBehaviour
    {
        private ITimePublisher timePublisher;
        private IStateMachineDebugController controller;
        private StateMachine stateMachine;
        
        private void Start()
        {
            timePublisher = new TimePublisher();
            controller = new StateMachineDebugController(timePublisher);
            stateMachine = new StateMachine();
            
            stateMachine.NextState(new FirstState(stateMachine, controller));
        }

        private void Update()
        {
            controller.RefreshTimeline();
            stateMachine.Process();
        }
    }
}
#endif