using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Food_Crawler
{
    public partial class Form1
    {
        //private List<Action<int>> functions;
        public void Room1()
        {   //Self Reflection Room
            String ReflectionPath = ResourcesPath + "/ReflectionOfSelf.png";
            TestImage = Image.FromFile(ReflectionPath);
            StartScreenPictureBox.Image = TestImage;
            StartMenuTextBox.Text = "Well your not as dashing as you remeber";

        }
        public void Room2()
        {
            //Stats Room for inital point investment
            String ReflectionPath = ResourcesPath + "/StatusScreen.png";
            TestImage = Image.FromFile(ReflectionPath);
            StartScreenPictureBox.Image = TestImage;
            StartMenuTextBox.Text = "Memories surge through your veins";

            //Create all buttons for stat upgrades
            healthButton = null;

            healthButton = new Button();
            ButtonCreator(ref healthButton, "healbutton", 300, 230, 70, 70, "HP", healthButtonFunc);
        }
           

        //EXTRA BUTTON FUNCTIONS
        public void healthButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetHealth(mainPlayer.GetHealth() + 1);
        }

        public void speedButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetSpeed(mainPlayer.GetSpeed() + 1);
        }

        public void ArmorButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetArmor(mainPlayer.GetArmor() + 1);
        }

        public void DamageButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetDamage(mainPlayer.GetDamage() + 1);
        }

        public void ButtonCreator(ref Button button, string name, int x, int y, int sizeX, int sizeY, string text, EventHandler theFunction)
        {
            button.Location = new Point(x, y);
            button.Name = name;
            button.Size = new Size(sizeX, sizeY);
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.BackColor = Color.Aqua;
            button.Click += theFunction;
            Controls.Add(button);
            button.Show();
            button.BringToFront();
        }
    }
}
