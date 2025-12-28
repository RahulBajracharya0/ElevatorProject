using ElevatorProject.Context;
using ElevatorProject.stateInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProject.concreteClass
{
    internal class MovingDownState : IElevatorState
    {
        public void MovingDown(Elevator elevator)
        {
            // Move down
            elevator.MainElevator.Top += elevator.ElevatorSpeed;

            // Clamp to 1st floor position (313)
            if (elevator.MainElevator.Top >= 313)
            {
                elevator.MainElevator.Top = 313;
            }
        }


        public void MovingUp(Elevator elevator)
        {
            /* Do Nothing */
        }
    }
}
