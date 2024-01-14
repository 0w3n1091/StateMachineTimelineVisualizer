namespace StateMachinePattern
{
    /// <summary>
    /// Interface for a state machine.
    /// </summary>
    public interface IStateMachine
    {
        /// <summary>
        /// Transition to the next state.
        /// </summary>
        /// <param name="state">The next state to transition to.</param>
        void NextState(State state);
    }
}