using ElevatorProject.Context;
using ElevatorProject.stateInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProject.concreteClass
{
    internal class IdleState : IElevatorState
    {
        public void MovingDown(Elevator lift)
        {
            /* Do Nothing*/
        }

        public void MovingUp(Elevator lift)
        {
            /* Do Nothing*/
        }
    }
}
