using ElevatorProject.Context;
using ElevatorProject.stateInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProject.concreteClass
{
    internal class MovingUpState : IElevatorState
    {
        public void MovingDown(Elevator elevator)
        {
            /* Do Nothing */
        }

        public void MovingUp(Elevator elevator)
        {
            if (elevator.MainElevator.Top > 0)
            {
                elevator.MainElevator.Top -= elevator.ElevatorSpeed;
            }
            else
            {
                elevator.SetState(new IdleState());
                elevator.ElevatorTimer.Stop();
            }

        }
    }
}
