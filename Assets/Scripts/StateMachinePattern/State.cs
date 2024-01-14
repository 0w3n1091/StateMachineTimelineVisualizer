namespace StateMachinePattern
{
    /// <summary>
    /// Abstract class representing a state in a state machine.
    /// </summary>
    public abstract class State
    {
        /// <summary>
        /// Reference to the state machine associated with this state.
        /// </summary>
        protected readonly IStateMachine stateMachine;
        
        protected State(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        /// <summary>
        /// Called when the state is opened or entered.
        /// </summary>
        public abstract void OnOpen();

        /// <summary>
        /// Called when the state is being processed or updated.
        /// </summary>
        public abstract void OnProcess();

        /// <summary>
        /// Called when the state is closed or exited.
        /// </summary>
        public abstract void OnClose();
    }
}