#if UNITY_EDITOR
using StateMachineVisualizer.States;
using UnityEngine;

namespace StateMachineVisualizer
{
    /// <summary>
    /// Represents a runner for the state machine with a visualized timeline in the Unity Editor.
    /// </summary>
    public class StateMachineTimelineRunner : MonoBehaviour
    {
        private TimelineStateMachine stateMachine;
        
        private void Start()
        {
            stateMachine = new TimelineStateMachine();
            stateMachine.NextState(new FirstState(stateMachine));
        }

        private void Update() => stateMachine.Process();
    }
}
#endif