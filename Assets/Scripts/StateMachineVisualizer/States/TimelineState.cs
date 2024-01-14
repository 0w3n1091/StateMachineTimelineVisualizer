using StateMachinePattern;
using StateMachineVisualizer.Interfaces;

namespace StateMachineVisualizer.States
{
    /// <summary>
    /// Represents a state in the state machine that corresponds to a timeline on the visualizer.
    /// </summary>
    public class TimelineState : State
    {
        protected readonly IStateMachineTimelineController timelineController;
        protected readonly string trackName;
        
        protected TimelineState(IStateMachine stateMachine, IStateMachineTimelineController timelineController) : base(stateMachine)
        {
            this.timelineController = timelineController;
            trackName = stateMachine.GetType().Name;
        }

        public override void OnOpen()
        {
            string stateName = GetType().Name;
            timelineController.StartState(stateName, trackName);
        }

        public override void OnProcess()
        {
            timelineController.RefreshTimeline();
        }

        public override void OnClose()
        {
            timelineController.FinishActiveState(trackName);
        }
    }
}