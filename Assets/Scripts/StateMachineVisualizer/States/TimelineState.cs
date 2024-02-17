using StateMachinePattern;
using StateMachineVisualizer.Interfaces;

namespace StateMachineVisualizer.States
{
    /// <summary>
    /// Represents a state in the state machine that corresponds to a timeline on the visualizer.
    /// </summary>
    public class TimelineState : State
    {
        protected readonly TimelineStateMachine timelineStateMachine;
        protected readonly string trackName;
        
        protected TimelineState(TimelineStateMachine stateMachine) : base(stateMachine)
        {
            timelineStateMachine = stateMachine;
            trackName = stateMachine.GetType().Name;
        }

        public override void OnOpen()
        {
            string stateName = GetType().Name;
            timelineStateMachine.Controller.StartState(stateName, trackName);
        }

        public override void OnProcess()
        {
            timelineStateMachine.Controller.RefreshTimeline();
        }

        public override void OnClose()
        {
            timelineStateMachine.Controller.FinishActiveState(trackName);
        }
    }
}