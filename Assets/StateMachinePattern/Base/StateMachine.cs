namespace StateMachinePattern.Base
{
    public class StateMachine : IStateMachine
    {
        private State currentState;
        
        public void Process()
        {
            currentState?.OnProcess();
        }

        public void NextState(State state)
        {
            currentState?.OnClose();
            currentState = state;
            currentState.OnOpen();
        }
    }
}