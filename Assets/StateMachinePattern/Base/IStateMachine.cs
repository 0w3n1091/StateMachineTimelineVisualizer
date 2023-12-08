namespace StateMachinePattern.Base
{
    public interface IStateMachine
    {
        void NextState(State state);
    }
}