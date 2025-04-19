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
            LabelCreator(ref healthLabel, "healthLabelForm", 30, 0, 10, 70, $"HP: {mainPlayer.GetHealth()}");
            LabelCreator(ref armorLabel, "armorLabelForm", healthLabel.Location.X + healthLabel.Size.Width + 30, 0, 10, 70, $"AMR: {mainPlayer.GetArmor()}");
            LabelCreator(ref damageLabel, "damageLabelForm", armorLabel.Location.X + armorLabel.Size.Width + 30, 0, 10, 70, $"DMG: {mainPlayer.GetDamage()}");
            LabelCreator(ref speedLabel, "speedLabelForm", damageLabel.Location.X + damageLabel.Size.Width + 30, 0, 10, 70, $"SPD: {mainPlayer.GetSpeed()}");
            LabelCreator(ref looseStatPoints, "looseStatPointsForm", speedLabel.Location.X + speedLabel.Size.Width + 30, 0, 10, 70, $"LSP: {mainPlayer.GetLooseStatPoints()}");
            Application.DoEvents();
            while (mainPlayer.GetLooseStatPoints() > 0)
            {
                Application.DoEvents();
            }

            // Show stat allocation buttons
            increaseHealthButton.Visible = true;
            increaseSpeedButton.Visible = true;
        }

        //Fighting Rooms
        public void GenericFight() //this will currently allow 1 if multi fights are wanted make another function called GenericMuliFights
        {//since we need to pass in the enemey and player we will decide how to generate a enemey here
         //this is temporary
            
            Random tempRandGen = new();
            Enemey tempEnemey = Enemey.GenerateEnemey(TowerLevel);

            //gui change
            String ArenaGui = Path.Combine(ResourcesPath, "arena.png");
            mainImage = Image.FromFile(ArenaGui);
            StartScreenPictureBox.Image = mainImage;
            StartMenuTextBox.Text = "you encounter an enemey";
            String EnemeyImagePath = Path.Combine(ResourcesPath, "Goblin.png");
            Image EnemeyImage = Image.FromFile(EnemeyImagePath);
            enemeyPictureBox = null;
            enemeyPictureBox = new();
            PictureBoxCreator(ref enemeyPictureBox, 500, 500, this.StartScreenPictureBox.Width - 1000, this.Height - 1000, EnemeyImage);

            //full weapon path already 
            String EnemeyWeaponPath = tempEnemey.GetWeapon().weaponpng;
            Image EnemeyWeaponImage = Image.FromFile(EnemeyWeaponPath);
            enemeyWeaponPictureBox = null;
            enemeyWeaponPictureBox = new();
            PictureBoxCreator(ref enemeyWeaponPictureBox, 200, 200, enemeyPictureBox.Location.X, enemeyPictureBox.Location.Y + enemeyPictureBox.Height / 2, EnemeyWeaponImage);

            //we can launch the fight like so
            isInFight = true;
            Arena.LaunchFight(ref mainPlayer, ref tempEnemey, tempRandGen, this);
            isInFight = false;

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

        public void DisableButton(Object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Enabled = false;
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
            Application.DoEvents();
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

        public void Shop()//Lucas
        {
            String Background = ResourcesPath + "/Shop.png";
            mainImage = Image.FromFile(Background);
            StartScreenPictureBox.Image = mainImage;
            StartMenuTextBox.ReadOnly = true;
            StartMenuTextBox.Text = "What do you want to buy weary traveler?";

            CheckMoneyButton = null;
            CheckMoneyButton = new Button();
            string MoneyFile = ResourcesPath + "/Money.png";
            Image MoneyImage = Image.FromFile(MoneyFile);
            MoneyImage = ImageResizer(MoneyImage, CheckMoneyButton.Width * 3, CheckMoneyButton.Height * 9);
            CheckMoneyButton.Image = MoneyImage;
            ButtonCreator(ref CheckMoneyButton, "MoneyForm", 50, 30, 200, 200, "", CheckMoneyFunc);

            BuyHealthPotButton = null;
            BuyHealthPotButton = new Button();
            string HPotFile = ResourcesPath + "/HealthPotion.png";
            Image HPotImage = Image.FromFile(HPotFile);
            HPotImage = ImageResizer(HPotImage, BuyHealthPotButton.Width, BuyHealthPotButton.Height * 3);
            BuyHealthPotButton.Image = HPotImage;
            ButtonCreator(ref BuyHealthPotButton, "HealthPotForm", 550, 30, 80, 80, "", BuyHealthPotFunc);

            BuyKnifeButton = null;
            BuyKnifeButton = new Button();
            string KnifeFile = ResourcesPath + "/Knife.png";
            Image KnifeImage = Image.FromFile(KnifeFile);
            KnifeImage = ImageResizer(KnifeImage, BuyKnifeButton.Width, BuyKnifeButton.Height * 3);
            BuyKnifeButton.Image = KnifeImage;
            ButtonCreator(ref BuyKnifeButton, "KnifeForm", 650, 30, 80, 80, "", BuyKnifeFunc);

            BuyBananaButton = null;
            BuyBananaButton = new Button();
            string BananaFile = ResourcesPath + "/Banana.png";
            Image BananaImage = Image.FromFile(BananaFile);
            BananaImage = ImageResizer(BananaImage, BuyBananaButton.Width, BuyBananaButton.Height * 3);
            BuyBananaButton.Image = BananaImage;
            ButtonCreator(ref BuyBananaButton, "BananaForm", 750, 30, 80, 80, "", BuyBananaFunc);

            BuyHelmetButton = null;
            BuyHelmetButton = new Button();
            string HelmetFile = ResourcesPath + "/Helmet.png";
            Image HelmetImage = Image.FromFile(HelmetFile);
            HelmetImage = ImageResizer(HelmetImage, BuyHelmetButton.Width, BuyHelmetButton.Height * 3);
            BuyHelmetButton.Image = HelmetImage;
            ButtonCreator(ref BuyHelmetButton, "HelmetForm", 850, 30, 80, 80, "", BuyHelmetFunc);
        }

        public void CheckMoneyFunc(Object sender, EventArgs e)//Lucas
        {
            String CashSound = ResourcesPath + "/MoneySound.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(CashSound);
            player.Play();
            string money = mainPlayer.GetMoney().ToString();
            MessageBox.Show($"You Have ${money}");
        }

        public void BuyHealthPotFunc(Object sender, EventArgs e)//Lucas
        {
            int money = mainPlayer.GetMoney();
            if (money >= 8)
            {
                String BuySound = ResourcesPath + "/ItemGot.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(BuySound);
                player.Play();
                mainPlayer.IncreaseHealthPotion();
                mainPlayer.PrintAllPotions();
                mainPlayer.SetMoney(money - 8);
            }
            else
            {
                MessageBox.Show("You don't have enough money for that. Remaining balance is $" + money.ToString());
            }
        }

        public void BuyKnifeFunc(Object sender, EventArgs e)//Lucas
        {
            int money = mainPlayer.GetMoney();
            if (money >= 3)
            {
                String BuySound = ResourcesPath + "/ItemGot.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(BuySound);
                player.Play();
                mainPlayer.SetDamage(mainPlayer.GetDamage() + 1);
                mainPlayer.SetMoney(money - 3);
                MessageBox.Show("You bought a knife and gained 1 damage.\nYour damage is now: " + mainPlayer.GetDamage().ToString());
            }
            else
            {
                MessageBox.Show("You don't have enough money for that. Remaining balance is $" + money.ToString());
            }
        }

        public void BuyBananaFunc(Object sender, EventArgs e)//Lucas
        {
            int money = mainPlayer.GetMoney();
            if (money >= 4)
            {
                String BuySound = ResourcesPath + "/ItemGot.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(BuySound);
                player.Play();
                mainPlayer.SetSpeed(mainPlayer.GetSpeed() + 1);
                mainPlayer.SetMoney(money - 4);
                MessageBox.Show("You bought a banana and gained 1 speed.\nYour speed is now: " + mainPlayer.GetSpeed().ToString());
            }
            else
            {
                MessageBox.Show("You don't have enough money for that. Remaining balance is $" + money.ToString());
            }
        }

        public void BuyHelmetFunc(Object sender, EventArgs e)//Lucas
        {
            int money = mainPlayer.GetMoney();
            if (money >= 3)
            {
                String BuySound = ResourcesPath + "/ItemGot.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(BuySound);
                player.Play();
                mainPlayer.SetArmor(mainPlayer.GetArmor() + 1);
                mainPlayer.SetMoney(money - 3);
                MessageBox.Show("You bought a helmet and gained 1 armor point.\nYour armor is now: " + mainPlayer.GetArmor().ToString());
            }
            else
            {
                MessageBox.Show("You don't have enough money for that. Remaining balance is $" + money.ToString());
            }
        }
    }
}










