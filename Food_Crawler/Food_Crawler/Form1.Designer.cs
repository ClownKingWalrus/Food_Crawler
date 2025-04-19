namespace Food_Crawler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button inventoryButton;
        private Button increaseHealthButton, increaseSpeedButton; // (Tony) added buttons to allow the player to allocate the stat points
        private Button room1Button, room2Button, fightRoomButton;
        private Button returnToMenuButton;
        private Button shopButton;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartScreenPictureBox = new PictureBox();
            StartMenuButton = new Button();
            StartMenuTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)StartScreenPictureBox).BeginInit();
            SuspendLayout();
            // 
            // StartScreenPictureBox
            // 
            StartScreenPictureBox.BackColor = SystemColors.ActiveCaption;
            StartScreenPictureBox.Image = Properties.Resources.paintdoors;
            StartScreenPictureBox.Location = new Point(1, 0);
            StartScreenPictureBox.Name = "StartScreenPictureBox";
            StartScreenPictureBox.Size = new Size(2091, 1127);
            StartScreenPictureBox.TabIndex = 0;
            StartScreenPictureBox.TabStop = false;
            // 
            // StartMenuButton
            // 
            StartMenuButton.Location = new Point(1197, 987);
            StartMenuButton.Name = "StartMenuButton";
            StartMenuButton.Size = new Size(895, 140);
            StartMenuButton.TabIndex = 1;
            StartMenuButton.Text = "Click to Continue";
            StartMenuButton.UseVisualStyleBackColor = true;
            StartMenuButton.Click += StartMenuButton_Click;
            // 
            // StartMenuTextBox
            // 
            StartMenuTextBox.BackColor = SystemColors.ControlLight;
            StartMenuTextBox.Font = new Font("Poor Richard", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartMenuTextBox.Location = new Point(37, 987);
            StartMenuTextBox.Multiline = true;
            StartMenuTextBox.Name = "StartMenuTextBox";
            StartMenuTextBox.Size = new Size(895, 141);
            StartMenuTextBox.TabIndex = 2;
            StartMenuTextBox.Text = "You find yourself at the doors of this dungeon. You take a moment to reflect on your past";


            //(Tony) added buttons to change the Rooms based on users choise
            room1Button = new Button();
            room1Button.Text = "Enter Reflection Room";
            room1Button.Size = new Size(300, 50);
            room1Button.Location = new Point(400, 800);
            room1Button.Click += (s, e) => SelectRoom("Room1");
            Controls.Add(room1Button);

            room2Button = new Button();
            room2Button.Text = "Enter Stat Allocation Room";
            room2Button.Size = new Size(300, 50);
            room2Button.Location = new Point(800, 800);
            room2Button.Click += (s, e) => SelectRoom("Room2");
            Controls.Add(room2Button);

            fightRoomButton = new Button();
            fightRoomButton.Text = "Enter Arena";
            fightRoomButton.Size = new Size(300, 50);
            fightRoomButton.Location = new Point(1200, 800);
            fightRoomButton.Click += (s, e) => SelectRoom("FightRoom");
            Controls.Add(fightRoomButton);

            //(Tony) added a Button For inventory
            // inventoryButton
            inventoryButton = new Button();
            inventoryButton.Location = new Point(1920/2, 900); //change this if you want the button somewhere else
            inventoryButton.Size = new Size(180, 50);
            inventoryButton.Text = "Open Inventory";
            inventoryButton.Click += InventoryButton_Click;
            Controls.Add(inventoryButton);

            increaseHealthButton = new Button();        //(Tony) added a button to increase health(with lsp)
            increaseHealthButton.Text = "+ Health";
            increaseHealthButton.Location = new Point(1100, 850);
            increaseHealthButton.Click += (s, e) => AllocateStat("health");
            Controls.Add(increaseHealthButton);

            increaseSpeedButton = new Button();         // (tony) added a button to increase the character speed(with lsp)
            increaseSpeedButton.Text = "+ Speed";
            increaseSpeedButton.Location = new Point(1300, 850);
            increaseSpeedButton.Click += (s, e) => AllocateStat("speed");
            Controls.Add(increaseSpeedButton);

            returnToMenuButton = new Button();
            returnToMenuButton.Text = "Return to Menu";
            returnToMenuButton.Size = new Size(180, 50);
            returnToMenuButton.Location = new Point(1800, 1000);
            returnToMenuButton.Click += ReturnToMenuButton_Click;
            returnToMenuButton.Visible = false; 
            Controls.Add(returnToMenuButton);

            shopButton = new Button();
            shopButton.Text = "Enter Shop";
            shopButton.Size = new Size(300, 50);
            shopButton.Location = new Point(1600, 800);  
            shopButton.Click += (s, e) => SelectRoom("Shop");
            Controls.Add(shopButton);


            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2091, 1127);
            Controls.Add(StartMenuTextBox);
            Controls.Add(StartMenuButton);
            Controls.Add(StartScreenPictureBox);
            Name = "Form1";
            Text = "Food Crawler";
            ((System.ComponentModel.ISupportInitialize)StartScreenPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox StartScreenPictureBox;
        private Button StartMenuButton;
        private TextBox StartMenuTextBox;
    }
}

