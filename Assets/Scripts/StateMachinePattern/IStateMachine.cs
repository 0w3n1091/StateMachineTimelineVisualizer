namespace StateMachinePattern
{
    public interface IStateMachine
    {
        /// <summary>
        /// Updates the current state to the next state.
        /// </summary>
        /// <param name="state">The next state to transition to.</param>
        void NextState(State state);
    }
}