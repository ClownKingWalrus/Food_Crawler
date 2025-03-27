namespace Food_Crawler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            StartMenuButton.Location = new Point(1184, 987);
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
