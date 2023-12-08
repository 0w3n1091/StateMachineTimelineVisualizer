using StateMachineDebugger.Interfaces;

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

        /// <summary>
        /// This method is called when the state machine opens a new state.
        /// </summary>
        public virtual void OnOpen()
        {
            string stateName = GetType().Name;
            debugController.StartState(stateName, trackName, stateDescription);
        }

        /// <summary>
        /// This method is called to process a certain task.
        /// </summary>
        /// <remarks>
        /// This method should be implemented in a concrete class to define the specific task to be performed.
        /// </remarks>
        public abstract void OnProcess();

        /// <summary>
        /// This method is called when the state machine closes a current state.
        /// </summary>
        public virtual void OnClose()
        {
            debugController.FinishActiveState(trackName);
        }
    }
}