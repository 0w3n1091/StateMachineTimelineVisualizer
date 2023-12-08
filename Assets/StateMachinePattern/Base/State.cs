using TimelineUtility.Interfaces;

namespace StateMachinePattern.Base
{
    public abstract class State
    {
        protected readonly IStateMachine stateMachine;
        protected readonly IStateMachineDebugController debugController;
        protected readonly string trackName;
        private readonly string stateDescription;

        protected State(IStateMachine stateMachine, IStateMachineDebugController debugController, string stateDescription = null)
        {
            this.stateMachine = stateMachine;
            this.debugController = debugController;
            this.stateDescription = stateDescription;
            trackName = stateMachine.GetType().Name;
        }

        public virtual void OnOpen()
        {
            string stateName = GetType().Name;
            debugController.StartState(stateName, trackName, stateDescription);
        }

        public abstract void OnProcess();

        public virtual void OnClose()
        {
            debugController.FinishActiveState(trackName);
        }
    }
}