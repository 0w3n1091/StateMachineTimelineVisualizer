#if UNITY_EDITOR
using StateMachinePattern.States;
using TimelineUtility.Controllers;
using TimelineUtility.Interfaces;
using Timer;
using UnityEngine;
using StateMachine = StateMachinePattern.Base.StateMachine;

namespace TimelineUtility
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