namespace StateMachinePattern.Base
{
    public class StateMachine : IStateMachine
    {
        private State currentState;

        /// <summary>
        /// Processes the current state.
        /// </summary>
        public void Process()
        {
            currentState?.OnProcess();
        }

        /// <summary>
        /// Transition to the next state.
        /// </summary>
        /// <param name="state">The new state to transition to.</param>
        public void NextState(State state)
        {
            currentState?.OnClose();
            currentState = state;
            currentState.OnOpen();
        }
    }
}