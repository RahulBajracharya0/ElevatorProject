using ElevatorProject.concreteClass;
using ElevatorProject.Context;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ElevatorProject
{
    public partial class Form1 : Form
    {
        private int floor1Top = 313;
        private int floor2Top = 50;

        int doorOpenMaxWidth;
        int doorSpped = 10;
        int liftSpeed = 20;
        int currentFloor = 1;   // elevator current floor
        int doorFloor = 1;      // floor whose doors are moving
        bool isOpening = false;
        bool isClosing = false;
        bool moveUpAfterDoorClose = false;
        bool moveDownAfterDoorClose = false;

        DataTable dt = new DataTable();
        DBContext dBContext = new DBContext();
        private Elevator elevator;

        public Form1()
        {
            InitializeComponent();

            // Initialize Elevator class
            elevator = new Elevator(btnLift, liftSpeed, this.ClientSize.Height, liftTimer, liftTimerDown);
            doorOpenMaxWidth = btnLift.Width / 2 - 10;

            // Setup log grid
            dataGridViewLogs.ColumnCount = 2;
            dataGridViewLogs.Columns[0].Name = "Time";
            dataGridViewLogs.Columns[1].Name = "Event";

            dt.Columns.Add("LogTime");
            dt.Columns.Add("EventDescription");
        }

        // 
        // Utility: Log events
        // 
        private void logEvents(string message)
        {
            string time = DateTime.Now.ToString("hh:mm:ss");
            dt.Rows.Add(time, message);
            dataGridViewLogs.Rows.Add(time, message);
            dBContext.InsertLogsIntoDB(dt);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 
        // Button events
        // 
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (currentFloor == 2)
            {
                logEvents("Already at 2nd Floor");
                OpenDoors(2);
                return;
            }

            if (!isClosing && !isOpening)
            {
                CloseDoors(currentFloor);
                moveUpAfterDoorClose = true;
            }

            UpdateButtonStates();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (currentFloor == 1)
            {
                logEvents("Already at 1st Floor");
                OpenDoors(1);
                return;
            }

            if (!isClosing && !isOpening)
            {
                CloseDoors(currentFloor);
                moveDownAfterDoorClose = true;
            }

            UpdateButtonStates();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenDoors(currentFloor);
            UpdateButtonStates();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseDoors(currentFloor);
            UpdateButtonStates();
        }

        // 
        // Door control
        // 
        private void OpenDoors(int floor)
        {
            doorFloor = floor;
            if (isOpening) return;
            isOpening = true;
            isClosing = false;

            Button leftDoor = (floor == 1) ? leftDoor1 : leftDoor2;
            Button rightDoor = (floor == 1) ? rightDoor1 : rightDoor2;

            // reset if partially open
            if (leftDoor.Left > btnLift.Left) leftDoor.Left = btnLift.Left;
            if (rightDoor.Left < btnLift.Left + btnLift.Width / 2)
                rightDoor.Left = btnLift.Left + btnLift.Width / 2;

            doorTimer.Start();
            logEvents(floor == 1 ? "1st Floor Door Opening..." : "2nd Floor Door Opening...");
            UpdateButtonStates();
        }

        private void CloseDoors(int floor)
        {
            doorFloor = floor;
            if (isClosing) return;
            isClosing = true;
            isOpening = false;

            Button leftDoor = (floor == 1) ? leftDoor1 : leftDoor2;
            Button rightDoor = (floor == 1) ? rightDoor1 : rightDoor2;

            // reset if partially closed
            if (leftDoor.Left < btnLift.Left - doorOpenMaxWidth)
                leftDoor.Left = btnLift.Left - doorOpenMaxWidth;
            if (rightDoor.Left > btnLift.Left + btnLift.Width / 2 + doorOpenMaxWidth)
                rightDoor.Left = btnLift.Left + btnLift.Width / 2 + doorOpenMaxWidth;

            doorTimer.Start();
            logEvents(floor == 1 ? "1st Floor Door Closing..." : "2nd Floor Door Closing...");
            UpdateButtonStates();
        }

        private void doorTimer_Tick(object sender, EventArgs e)
        {
            Button leftDoor = (doorFloor == 1) ? leftDoor1 : leftDoor2;
            Button rightDoor = (doorFloor == 1) ? rightDoor1 : rightDoor2;

            if (isOpening)
            {
                if (leftDoor.Left > btnLift.Left - doorOpenMaxWidth)
                {
                    leftDoor.Left -= doorSpped;
                    rightDoor.Left += doorSpped;
                }
                else
                {
                    leftDoor.Left = btnLift.Left - doorOpenMaxWidth;
                    rightDoor.Left = btnLift.Left + btnLift.Width / 2 + doorOpenMaxWidth;
                    isOpening = false;
                    doorTimer.Stop();
                    logEvents(doorFloor == 1 ? "1st Floor Door Fully Opened" : "2nd Floor Door Fully Opened");
                    UpdateButtonStates();
                }
            }
            else if (isClosing)
            {
                if (leftDoor.Left < btnLift.Left)
                {
                    leftDoor.Left += doorSpped;
                    rightDoor.Left -= doorSpped;
                }
                else
                {
                    leftDoor.Left = btnLift.Left;
                    rightDoor.Left = btnLift.Left + btnLift.Width / 2;
                    isClosing = false;
                    doorTimer.Stop();
                    logEvents(doorFloor == 1 ? "1st Floor Door Fully Closed" : "2nd Floor Door Fully Closed");

                    // Move elevator after doors close
                    if (moveUpAfterDoorClose)
                    {
                        moveUpAfterDoorClose = false;
                        elevator.SetState(new MovingUpState());
                        elevator.ElevatorTimer.Start();
                        logEvents($"Lift Moving Up from Floor {currentFloor}");
                    }
                    else if (moveDownAfterDoorClose)
                    {
                        moveDownAfterDoorClose = false;
                        elevator.SetState(new MovingDownState());
                        elevator.ElevatorTimerDown.Start();
                        logEvents($"Lift Moving Down from Floor {currentFloor}");
                    }

                    UpdateButtonStates();
                }
            }
        }

        // 
        // Elevator movement timers
        // 
        private void liftTimer_Tick(object sender, EventArgs e)
        {
            elevator.MovingUp();

            if (btnLift.Top <= 50)
            {
                elevator.ElevatorTimer.Stop();
                btnLift.Top = 50;
                currentFloor = 2;
                doorFloor = 2;
                logEvents("Reached 2nd Floor");
                OpenDoors(2);
                UpdateButtonStates();
            }
        }

        private void liftTimerDown_Tick(object sender, EventArgs e)
        {
            elevator.MovingDown();

            if (btnLift.Top >= 313)
            {
                elevator.ElevatorTimerDown.Stop();
                currentFloor = 1;
                doorFloor = 1;
                logEvents("Reached 1st Floor");
                OpenDoors(1);
                UpdateButtonStates();
            }
        }


        // 
        // Log controls
        // 
        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            dataGridViewLogs.Rows.Clear();
            dBContext.ClearLogsFromDB();
            MessageBox.Show("All logs cleared successfully!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dBContext.loadLogsFromDB(dt, dataGridViewLogs);
            UpdateButtonStates();
        }

        // 
        // Door State Check Methods
        // 
        public bool IsDoorOpening() => isOpening;
        public bool IsDoorClosing() => isClosing;

        public string GetDoorState()
        {
            if (isOpening) return "Opening";
            if (isClosing) return "Closing";

            Button leftDoor = (doorFloor == 1) ? leftDoor1 : leftDoor2;
            if (leftDoor.Left <= btnLift.Left - doorOpenMaxWidth)
                return "Open";
            return "Closed";
        }

        // 
        // Button State Logic
        // 
        private void UpdateButtonStates()
        {
            bool isDoorMoving = isOpening || isClosing;
            bool isLiftMoving = elevator.ElevatorTimer.Enabled || elevator.ElevatorTimerDown.Enabled;

            // Disable all during motion
            btnUp.Enabled = !isLiftMoving && !isDoorMoving && currentFloor != 2;
            btnDown.Enabled = !isLiftMoving && !isDoorMoving && currentFloor != 1;
            btnOpen.Enabled = !isLiftMoving && !isDoorMoving;
            btnClose.Enabled = !isLiftMoving && !isDoorMoving;

            //  visually indicate disabled
            btnUp.BackColor = btnUp.Enabled ? Color.LightGreen : Color.Gray;
            btnDown.BackColor = btnDown.Enabled ? Color.LightGreen : Color.Gray;
            btnOpen.BackColor = btnOpen.Enabled ? Color.LightBlue : Color.Gray;
            btnClose.BackColor = btnClose.Enabled ? Color.Orange : Color.Gray;
        }

        private void leftDoor1_Click(object sender, EventArgs e)
        {

        }

        private void leftDoor1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
