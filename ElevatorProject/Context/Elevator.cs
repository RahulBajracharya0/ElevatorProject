using ElevatorProject.concreteClass;
using ElevatorProject.stateInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorProject.Context
{
    internal class Elevator
    {

        public IElevatorState _CurrentState;

        public Button MainElevator;
        public int ElevatorSpeed;
        public int FormSize;
        public System.Windows.Forms.Timer ElevatorTimer;
        public System.Windows.Forms.Timer ElevatorTimerDown;

        public Elevator(Button mainElevator, int elevatorSpeed, int formSize, System.Windows.Forms.Timer elevatorTimer, System.Windows.Forms.Timer elevatorTimerDown)
        {
            MainElevator = mainElevator;
            ElevatorSpeed = elevatorSpeed;
            FormSize = formSize;
            ElevatorTimer = elevatorTimer;
            _CurrentState = new IdleState();
            ElevatorTimerDown = elevatorTimerDown;
        }

        public void SetState(IElevatorState state)
        {
            _CurrentState = state;
        }

        public void MovingUp()
        {
            _CurrentState.MovingUp(this);
        }

        public void MovingDown()
        {
            _CurrentState.MovingDown(this);
        }

    }
}
