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
            
            //set all buttons null so we not doing funky gamer stuff
            healthButton = null;
            armorButton = null;
            damageButton = null;
            speedButton = null;

            //create all buttons
            healthButton = new Button();
            armorButton = new Button();
            damageButton = new Button();
            speedButton = new Button();

            //set up their parameters
            ButtonCreator(ref healthButton, "healbutton", 300, 230, 70, 70, "HP", healthButtonFunc);
            ButtonCreator(ref armorButton, "armorButton", 900, 230, 70, 70, "AMR", ArmorButtonFunc);
            ButtonCreator(ref damageButton, "damageButton", 270, 600, 70, 70, "DMG", DamageButtonFunc);
            ButtonCreator(ref speedButton, "speedButton", 1600, 230, 70, 70, "SPD", speedButtonFunc);

            //set img seperatly might automate later?
            string paintUpgrade = ResourcesPath + "/paintUpgrade.png";
            Image upgradeImage = Image.FromFile(paintUpgrade);
            upgradeImage = ImageResizer(upgradeImage, healthButton.Width, healthButton.Height);

            //set all buttons to the upgrade image
            healthButton.Image = upgradeImage;
            armorButton.Image = upgradeImage;
            damageButton.Image = upgradeImage;
            speedButton.Image = upgradeImage;
        }
           

        //EXTRA BUTTON FUNCTIONS
        public void healthButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetHealth(mainPlayer.GetHealth() + 1);
            mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
        }

        public void speedButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetSpeed(mainPlayer.GetSpeed() + 1);
            mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
        }

        public void ArmorButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetArmor(mainPlayer.GetArmor() + 1);
            mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
        }

        public void DamageButtonFunc(Object sender, EventArgs e)
        {
            mainPlayer.SetDamage(mainPlayer.GetDamage() + 1);
            mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
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

        //Image Util
        public Image ImageResizer(Image image, int x, int y)
        {//resizes image for my pleasure
            Image upgradeImageResized = (Image)(new Bitmap(image, new Size(x, y)));
            return upgradeImageResized;
        }
    }
}
