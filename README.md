PL:
Zestaw klas bazowych umożliwiających użytkownikowi rozszerzenie maszyny stanu o graficzną wizualizację jej przebiegu z wykorzystaniem pakietu Timeline. 
Przebieg jest aktualizowany na biężąco oraz zapisywany do pliku co umożliwia późniejszą analizę. Klasy bazowe umożliwiają również wsparcie dla rejestrowania zdarzeń w postaci pinezek na konkretnych stanach.

Do prawidłowego działania należy upewnić się że użyte w projekcie maszyny stanu dziedziczą po TimelineStateMachine, a stany po TimelineState. W repozytorium zawarta jest scena demonstracyjna w której wykorzystano przykładowe stany: FirstState, SecondState, ThirdState, FourthState.


ENG:
Base classes set enabling the user to extend the state machine with graphical visualization of its progress using the Timeline package. The progress is updated in real-time and saved to a file for later analysis. The base classes also support event logging in the form of pins on specific states.

For proper operation, ensure that the state machines used in the project inherit from TimelineStateMachine, and the states inherit from TimelineState. The repository contains a demonstration scene in which example states are utilized: FirstState, SecondState, ThirdState, FourthState.

![image](https://github.com/0w3n1091/StateMachineTimelineVisualizer/assets/59802118/7b8a7c91-1001-47af-b594-d1adc6b86f6c)
