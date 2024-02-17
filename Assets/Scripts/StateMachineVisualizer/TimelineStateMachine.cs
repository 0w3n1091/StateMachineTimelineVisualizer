using StateMachinePattern;
using StateMachineVisualizer.Controllers;
using StateMachineVisualizer.Interfaces;
using Timer;
using Timer.Interfaces;

namespace StateMachineVisualizer
{
    public class TimelineStateMachine : StateMachine
    {
        public IStateMachineTimelineController Controller { get; private set; }
        private readonly ITimeProvider timeProvider = new LocalTimeProvider();

        public TimelineStateMachine()
        {
            ITimePublisher timePublisher = new TimePublisher(timeProvider);
            Controller = new StateMachineTimelineController(timePublisher);
        }
    }
}