namespace ElevatorProject
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Elevator UI
        private System.Windows.Forms.Button btnLift;
        private System.Windows.Forms.Button leftDoor1;
        private System.Windows.Forms.Button rightDoor1;
        private System.Windows.Forms.Button leftDoor2;
        private System.Windows.Forms.Button rightDoor2;

        // Control buttons
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClearLogs;

        // DataGridView for logs
        private System.Windows.Forms.DataGridView dataGridViewLogs;

        // Timers
        private System.Windows.Forms.Timer doorTimer;
        private System.Windows.Forms.Timer liftTimer;
        private System.Windows.Forms.Timer liftTimerDown;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rightDoor1 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.doorTimer = new System.Windows.Forms.Timer(this.components);
            this.liftTimer = new System.Windows.Forms.Timer(this.components);
            this.liftTimerDown = new System.Windows.Forms.Timer(this.components);
            this.leftDoor1 = new System.Windows.Forms.Button();
            this.leftDoor2 = new System.Windows.Forms.Button();
            this.rightDoor2 = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLift = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rightDoor1
            // 
            this.rightDoor1.BackColor = System.Drawing.Color.Silver;
            this.rightDoor1.BackgroundImage = global::ElevatorProject.Properties.Resources.lift_door_right;
            this.rightDoor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightDoor1.Location = new System.Drawing.Point(198, 304);
            this.rightDoor1.Name = "rightDoor1";
            this.rightDoor1.Size = new System.Drawing.Size(67, 137);
            this.rightDoor1.TabIndex = 2;
            this.rightDoor1.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(906, 242);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 40);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(906, 178);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(80, 40);
            this.btnClearLogs.TabIndex = 10;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.AllowUserToAddRows = false;
            this.dataGridViewLogs.AllowUserToDeleteRows = false;
            this.dataGridViewLogs.ColumnHeadersHeight = 29;
            this.dataGridViewLogs.Location = new System.Drawing.Point(772, 12);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.ReadOnly = true;
            this.dataGridViewLogs.RowHeadersWidth = 51;
            this.dataGridViewLogs.Size = new System.Drawing.Size(321, 150);
            this.dataGridViewLogs.TabIndex = 11;
            // 
            // doorTimer
            // 
            this.doorTimer.Interval = 20;
            this.doorTimer.Tick += new System.EventHandler(this.doorTimer_Tick);
            // 
            // liftTimer
            // 
            this.liftTimer.Interval = 20;
            this.liftTimer.Tick += new System.EventHandler(this.liftTimer_Tick);
            // 
            // liftTimerDown
            // 
            this.liftTimerDown.Interval = 20;
            this.liftTimerDown.Tick += new System.EventHandler(this.liftTimerDown_Tick);
            // 
            // leftDoor1
            // 
            this.leftDoor1.BackColor = System.Drawing.Color.Silver;
            this.leftDoor1.BackgroundImage = global::ElevatorProject.Properties.Resources.lift_door_left;
            this.leftDoor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftDoor1.Location = new System.Drawing.Point(135, 303);
            this.leftDoor1.Name = "leftDoor1";
            this.leftDoor1.Size = new System.Drawing.Size(67, 138);
            this.leftDoor1.TabIndex = 1;
            this.leftDoor1.UseVisualStyleBackColor = false;
            this.leftDoor1.Click += new System.EventHandler(this.leftDoor1_Click_1);
            // 
            // leftDoor2
            // 
            this.leftDoor2.BackColor = System.Drawing.Color.Silver;
            this.leftDoor2.BackgroundImage = global::ElevatorProject.Properties.Resources.lift_door_left;
            this.leftDoor2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftDoor2.Location = new System.Drawing.Point(135, 47);
            this.leftDoor2.Name = "leftDoor2";
            this.leftDoor2.Size = new System.Drawing.Size(67, 137);
            this.leftDoor2.TabIndex = 3;
            this.leftDoor2.UseVisualStyleBackColor = false;
            // 
            // rightDoor2
            // 
            this.rightDoor2.BackColor = System.Drawing.Color.Silver;
            this.rightDoor2.BackgroundImage = global::ElevatorProject.Properties.Resources.lift_door_right;
            this.rightDoor2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightDoor2.Location = new System.Drawing.Point(198, 47);
            this.rightDoor2.Name = "rightDoor2";
            this.rightDoor2.Size = new System.Drawing.Size(67, 137);
            this.rightDoor2.TabIndex = 4;
            this.rightDoor2.UseVisualStyleBackColor = false;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnUp.BackgroundImage = global::ElevatorProject.Properties.Resources.firstfloorbutton11;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.Location = new System.Drawing.Point(506, 79);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(80, 68);
            this.btnUp.TabIndex = 5;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::ElevatorProject.Properties.Resources.Groundfloorbutton2;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.Location = new System.Drawing.Point(506, 180);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(80, 67);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "Down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackgroundImage = global::ElevatorProject.Properties.Resources.opendoorbutton1;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Location = new System.Drawing.Point(461, 291);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 71);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::ElevatorProject.Properties.Resources.closedoorsbutton1;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(557, 291);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 71);
            this.btnClose.TabIndex = 8;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLift
            // 
            this.btnLift.BackColor = System.Drawing.Color.DarkGray;
            this.btnLift.BackgroundImage = global::ElevatorProject.Properties.Resources.Inside_of_the_lift;
            this.btnLift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLift.Location = new System.Drawing.Point(135, 303);
            this.btnLift.Name = "btnLift";
            this.btnLift.Size = new System.Drawing.Size(130, 137);
            this.btnLift.TabIndex = 0;
            this.btnLift.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ElevatorProject.Properties.Resources.panel;
            this.pictureBox1.Location = new System.Drawing.Point(447, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 378);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1127, 676);
            this.Controls.Add(this.leftDoor1);
            this.Controls.Add(this.rightDoor1);
            this.Controls.Add(this.leftDoor2);
            this.Controls.Add(this.rightDoor2);
            this.Controls.Add(this.btnUp)
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.dataGridViewLogs);
            this.Controls.Add(this.btnLift);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Elevator Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
