using ElevatorProject.Context;

namespace ElevatorProject.stateInterface
{
    internal interface IElevatorState
    {
        void MovingUp(Elevator elevator);
        void MovingDown(Elevator elevator);
    }
}