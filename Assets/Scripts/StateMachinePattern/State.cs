namespace StateMachinePattern
{
    public abstract class State
    {
        protected readonly IStateMachine stateMachine;

        protected State(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        /// <summary>
        /// This method is called when the state machine opens a new state.
        /// </summary>
        public abstract void OnOpen();

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
        public abstract void OnClose();
    }
}