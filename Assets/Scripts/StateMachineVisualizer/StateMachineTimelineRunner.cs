#if UNITY_EDITOR
using StateMachineVisualizer.Controllers;
using StateMachineVisualizer.Interfaces;
using StateMachineVisualizer.States;
using Timer;
using Timer.Interfaces;
using UnityEngine;
using StateMachine = StateMachinePattern.StateMachine;

namespace StateMachineVisualizer
{
    public class StateMachineTimelineRunner : MonoBehaviour
    {
        private readonly ITimeProvider timeProvider = new LocalTimeProvider();
        private ITimePublisher timePublisher;
        private IStateMachineTimelineController controller;
        private StateMachine stateMachine;
        
        private void Start()
        {
            timePublisher = new TimePublisher(timeProvider);
            controller = new StateMachineTimelineController(timePublisher);
            stateMachine = new StateMachine();
            
            stateMachine.NextState(new FirstState(stateMachine, controller));
        }

        private void Update() => stateMachine.Process();
    }
}
#endif