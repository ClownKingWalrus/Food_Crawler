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
            mainImage = Image.FromFile(ReflectionPath);
            StartScreenPictureBox.Image = mainImage;
            StartMenuTextBox.Text = "Well your not as dashing as you remeber";

        }
        public void Room2()
        {
            //Stats Room for inital point investment
            String ReflectionPath = ResourcesPath + "/StatusScreen.png";
            mainImage = Image.FromFile(ReflectionPath);
            StartScreenPictureBox.Image = mainImage;
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
            ButtonCreator(ref healthButton, "healbuttonForm", 300, 230, 70, 70, "HP", healthButtonFunc);
            ButtonCreator(ref armorButton, "armorButtonForm", 900, 230, 70, 70, "AMR", ArmorButtonFunc);
            ButtonCreator(ref damageButton, "damageButtonForm", 270, 600, 70, 70, "DMG", DamageButtonFunc);
            ButtonCreator(ref speedButton, "speedButtonForm", 1600, 230, 70, 70, "SPD", speedButtonFunc);

            //set img seperatly might automate later?
            string paintUpgrade = ResourcesPath + "/paintUpgrade.png";
            Image upgradeImage = Image.FromFile(paintUpgrade);
            upgradeImage = ImageResizer(upgradeImage, healthButton.Width, healthButton.Height);

            //set all buttons to the upgrade image
            healthButton.Image = upgradeImage;
            armorButton.Image = upgradeImage;
            damageButton.Image = upgradeImage;
            speedButton.Image = upgradeImage;

            //set up all labels
            healthLabel = null;
            armorLabel = null;
            damageLabel = null;
            speedLabel = null;
            looseStatPoints = null;

            healthLabel = new Label();
            armorLabel = new Label();
            damageLabel = new Label();
            speedLabel = new Label();
            looseStatPoints = new Label();

            //set params for the labels UPDATE SO IT AUTO AJUST THE LABELS
            LabelCreator(ref healthLabel, "healthLabelForm", 30, 0, 100, 70, $"HP: {mainPlayer.GetHealth()}");
            LabelCreator(ref armorLabel, "armorLabelForm", healthLabel.Location.X + healthLabel.Size.Width + 30, 0, 100, 70, $"AMR: {mainPlayer.GetArmor()}");
            LabelCreator(ref damageLabel, "damageLabelForm", armorLabel.Location.X + armorLabel.Size.Width + 30, 0, 100, 70, $"DMG: {mainPlayer.GetDamage()}");
            LabelCreator(ref speedLabel, "speedLabelForm", damageLabel.Location.X + damageLabel.Size.Width + 30, 0, 100, 70, $"SPD: {mainPlayer.GetSpeed()}");
            LabelCreator(ref looseStatPoints, "looseStatPointsForm", speedLabel.Location.X + speedLabel.Size.Width + 30, 0, 100, 70, $"LSP: {mainPlayer.GetLooseStatPoints()}");
            Application.DoEvents();
            while (mainPlayer.GetLooseStatPoints() > 0)
            {
                Application.DoEvents();
            }
        }

        //Fighting Rooms
        public void GenericFight() //this will currently allow 1 if multi fights are wanted make another function called GenericMuliFights
        {//since we need to pass in the enemey and player we will decide how to generate a enemey here
            //this is temporary
            Random tempRandGen = new();
            Enemey tempEnemey = Enemey.GenerateEnemey(TowerLevel);


            //gui change
            String ArenaGui = ResourcesPath + @"\arena.png";
            mainImage = Image.FromFile(ArenaGui);
            StartScreenPictureBox.Image = mainImage;
            StartMenuTextBox.Text = "you encounter an enemey";
            String EnemeyImagePath = ResourcesPath + @"\Goblin.png";
            Image EnemeyImage = Image.FromFile(EnemeyImagePath);
            enemeyPictureBox = null;
            enemeyPictureBox = new();
            PictureBoxCreator(ref enemeyPictureBox, 500, 500, this.StartScreenPictureBox.Width- 1000, this.Height - 1000, EnemeyImage);;

            //full weapon path already
            String EnemeyWeaponPath = tempEnemey.GetWeapon().weaponpng;
            Image EnemeyWeaponImage = Image.FromFile(EnemeyWeaponPath);
            enemeyWeaponPictureBox = null;
            enemeyWeaponPictureBox = new();
            PictureBoxCreator(ref enemeyWeaponPictureBox, 200, 200, enemeyPictureBox.Location.X, enemeyPictureBox.Location.Y + enemeyPictureBox.Height/2, EnemeyWeaponImage);

            //we can launch the fight like so
            Arena.LaunchFight(ref mainPlayer, ref tempEnemey, tempRandGen, this);
        }
           

        //EXTRA BUTTON FUNCTIONS
        public void healthButtonFunc(Object sender, EventArgs e)
        {
            if (mainPlayer.GetLooseStatPoints() > 0)
            {
                mainPlayer.SetHealth(mainPlayer.GetHealth() + 1);
                mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
                //visually update
                PlayerStatsLabelUpdater();
            }
        }

        public void speedButtonFunc(Object sender, EventArgs e)
        {
            if (mainPlayer.GetLooseStatPoints() > 0)
            {
                mainPlayer.SetSpeed(mainPlayer.GetSpeed() + 1);
                mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
                //update labels
                PlayerStatsLabelUpdater();
            }
        }

        public void ArmorButtonFunc(Object sender, EventArgs e)
        {
            if (mainPlayer.GetLooseStatPoints() > 0)
            {
                mainPlayer.SetArmor(mainPlayer.GetArmor() + 1);
                mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
                //update labels
                PlayerStatsLabelUpdater();
            }
        }

        public void DamageButtonFunc(Object sender, EventArgs e)
        {
            if (mainPlayer.GetLooseStatPoints() > 0)
            {
                mainPlayer.SetDamage(mainPlayer.GetDamage() + 1);
                mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
                //update labels
                PlayerStatsLabelUpdater();
            }
        }

        public void PlayerStatsLabelUpdater()
        {
            if (healthLabel == null || armorLabel == null || damageLabel == null || speedLabel == null || looseStatPoints == null)
            {
                healthLabel = null;
                armorLabel = null;
                damageLabel = null;
                speedLabel = null;
                looseStatPoints = null;

                healthLabel = new Label();
                armorLabel = new Label();
                damageLabel = new Label();
                speedLabel = new Label();
                looseStatPoints = new Label();

            }
            //this is probably overkill but im not trying to figure out why label.Location.X = some number does not work thats not very fortnite
            LabelCreator(ref healthLabel, "healthLabelForm", 30, 0, 100, 70, $"HP: {mainPlayer.GetHealth()}");
            LabelCreator(ref armorLabel, "armorLabelForm", healthLabel.Location.X + healthLabel.Size.Width + 30, 0, 100, 70, $"AMR: {mainPlayer.GetArmor()}");
            LabelCreator(ref damageLabel, "damageLabelForm", armorLabel.Location.X + armorLabel.Size.Width + 30, 0, 100, 70, $"DMG: {mainPlayer.GetDamage()}");
            LabelCreator(ref speedLabel, "speedLabelForm", damageLabel.Location.X + damageLabel.Size.Width + 30, 0, 100, 70, $"SPD: {mainPlayer.GetSpeed()}");
            LabelCreator(ref looseStatPoints, "looseStatPointsForm", speedLabel.Location.X + speedLabel.Size.Width + 30, 0, 100, 70, $"LSP: {mainPlayer.GetLooseStatPoints()}");
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
            //set up to the Forms
            Controls.Add(button);
            button.Show();
            button.BringToFront();
        }

        public void LabelCreator(ref Label label, string name, int x, int y, int sizeX, int sizeY, string text)
        {
            label.Location = new Point(x, y);
            label.Name = name;
            label.Size = new Size(sizeX, sizeY);
            label.AutoSize = true;
            label.Text = text;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.BackColor = Color.Khaki;
            label.Font = new Font("Poor Richard", 26);
            //label.Click += theFunction; //we might be able to do somthin wth this later
            //set up to the forms
            Controls.Add(label);
            label.Show();
            label.BringToFront();
        }

        public void PictureBoxCreator(ref PictureBox pictureBox, int sizex, int sizey, int locationx, int locationy, Image image)
        {
            pictureBox.Location = new Point(locationx, locationy);
            pictureBox.Width = sizex;
            pictureBox.Height = sizey;
            image = ImageResizer(image, sizex, sizey);
            pictureBox.Image = image;
            Controls.Add(pictureBox);
            pictureBox.Show();
            pictureBox.BringToFront();
        }

        //Image Util
        public Image ImageResizer(Image image, int x, int y)
        {//resizes image for my pleasure
            Image upgradeImageResized = (Image)(new Bitmap(image, new Size(x, y)));
            return upgradeImageResized;
        }
    }
}
