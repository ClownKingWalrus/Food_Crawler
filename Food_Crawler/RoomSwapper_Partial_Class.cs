using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
            StartMenuTextBox.ReadOnly = true;
            StartMenuTextBox.Text = "Well your not as dashing as you remeber";
            NextButtonClicked(NextButton);
            while (NextButton.Enabled == true && !isClosing)
            {
                Application.DoEvents();
            }
            
        }
        public void Room2()
        {
            //Stats Room for inital point investment
            String ReflectionPath = ResourcesPath + "/StatusScreen.png";
            mainImage = Image.FromFile(ReflectionPath);
            StartScreenPictureBox.Image = mainImage;
            StartMenuTextBox.Text = "Memories surge through your veins";
            if (healthButton != null)
            {
                healthButton.Hide();
                healthButton.Dispose();
                armorButton.Hide();
                armorButton.Dispose();
                damageButton.Hide();
                damageButton.Dispose();
                speedButton.Hide();
                speedButton.Dispose();
            }
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
            ButtonCreator(ref healthButton, "healbuttonForm", StartScreenPictureBox.Width/7, StartScreenPictureBox.Height/5, 70, 70, "HP", healthButtonFunc);
            ButtonCreator(ref armorButton, "armorButtonForm", StartScreenPictureBox.Width / 3 + StartScreenPictureBox.Width / 9 + 20, StartScreenPictureBox.Height / 4, 70, 70, "AMR", ArmorButtonFunc);
            ButtonCreator(ref damageButton, "damageButtonForm", StartScreenPictureBox.Width / 8, StartScreenPictureBox.Height / 2 + StartScreenPictureBox.Height / 12, 70, 70, "DMG", DamageButtonFunc);
            ButtonCreator(ref speedButton, "speedButtonForm", StartScreenPictureBox.Width - StartScreenPictureBox.Width/4 + 30, StartScreenPictureBox.Height / 5, 70, 70, "SPD", speedButtonFunc);

            //set img seperatly might automate later?
            string paintUpgrade = ResourcesPath + "/paintUpgrade.png";
            Image upgradeImage = Image.FromFile(paintUpgrade);
            upgradeImage = ImageResizer(upgradeImage, healthButton.Width, healthButton.Height);

            //set all buttons to the upgrade image
            healthButton.Image = upgradeImage;
            armorButton.Image = upgradeImage;
            damageButton.Image = upgradeImage;
            speedButton.Image = upgradeImage;
            //if labels are still there
            if (healthLabel != null)
            {
                PlayerStatsHider();
                healthLabel.Dispose();
                armorLabel.Dispose();
                damageLabel.Dispose();
                speedLabel.Dispose();
                looseStatPoints.Dispose();
                counterLabel.Dispose();
                potionCountLabel.Dispose();
            }
            //set up all labels
            healthLabel = null;
            armorLabel = null;
            damageLabel = null;
            speedLabel = null;
            looseStatPoints = null;
            counterLabel = null;
            potionCountLabel = null;

            healthLabel = new Label();
            armorLabel = new Label();
            damageLabel = new Label();
            speedLabel = new Label();
            looseStatPoints = new Label();
            counterLabel = new Label();
            potionCountLabel = new Label();


            //set params for the labels UPDATE SO IT AUTO AJUST THE LABELS
            LabelCreator(ref healthLabel, "healthLabelForm", 30, 0, 100, 70, $"HP: {mainPlayer.GetHealth()}");
            LabelCreator(ref armorLabel, "armorLabelForm", healthLabel.Location.X + healthLabel.Size.Width + 30, 0, 100, 70, $"AMR: {mainPlayer.GetArmor()}");
            LabelCreator(ref damageLabel, "damageLabelForm", armorLabel.Location.X + armorLabel.Size.Width + 30, 0, 100, 70, $"DMG: {mainPlayer.GetDamage()}");
            LabelCreator(ref speedLabel, "speedLabelForm", damageLabel.Location.X + damageLabel.Size.Width + 30, 0, 100, 70, $"SPD: {mainPlayer.GetSpeed()}");
            LabelCreator(ref looseStatPoints, "looseStatPointsForm", speedLabel.Location.X + speedLabel.Size.Width + 30, 0, 100, 70, $"LSP: {mainPlayer.GetLooseStatPoints()}");
            LabelCreator(ref counterLabel, "counterLabel", looseStatPoints.Location.X + looseStatPoints.Size.Width + 30, 0, 100, 70, $"Counter: {staycounter}");
            LabelCreator(ref potionCountLabel, "potionCountLabel", counterLabel.Location.X + counterLabel.Size.Width + 30, 0, 100, 70, $"Potions: {mainPlayer.GetPotionCount()}");
            Application.DoEvents();
            while (mainPlayer.GetLooseStatPoints() > 0 && !isClosing)
            {
                Application.DoEvents();
            }
            this.Controls.Remove(healthButton);
            this.Controls.Remove(speedButton);
            this.Controls.Remove(armorButton);
            this.Controls.Remove(damageButton);
            healthButton.Dispose();
            speedButton.Dispose();
            armorButton.Dispose();
            damageButton.Dispose();



            NextButtonClicked(NextButton);
            while (NextButton.Enabled == true && !isClosing)
            {
                Application.DoEvents();
            }

        }

        public void Shop() //Lucas
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
            Application.DoEvents();

            Button leaveButton = new();
            ButtonCreator(ref leaveButton, "leaveButton", StartScreenPictureBox.Width/2, StartScreenPictureBox.Height - 160, 200, 80, "Leave", DisableButton);

            while (leaveButton.Enabled == true && !isClosing)
            {
                Application.DoEvents();
            }
            Controls.Remove(leaveButton);
            Controls.Remove(BuyBananaButton);
            Controls.Remove(BuyHealthPotButton);
            Controls.Remove(BuyHelmetButton);
            Controls.Remove(BuyKnifeButton);
            Controls.Remove(CheckMoneyButton);
            BuyKnifeButton.Dispose();
            BuyHealthPotButton.Dispose();
            BuyHelmetButton.Dispose();
            BuyKnifeButton.Dispose();
            CheckMoneyButton.Dispose();
            leaveButton.Dispose();
        }

        //Fighting Rooms
        public void GenericFight() //this will currently allow 1 if multi fights are wanted make another function called GenericMuliFights
        {//since we need to pass in the enemey and player we will decide how to generate a enemey here
            //this is temporary
            Random tempRandGen = new();

            if (staycounter == 999)
            {
                FinalBoss = Enemey.GenerateEnemey(TowerLevel * TowerLevel);
                FinalBoss.SetName("Mimic");
                Arena.LaunchFight(ref mainPlayer, ref FinalBoss, tempRandGen, this);
            }

            if (staycounter == 10 || staycounter == 12 || staycounter == 15  || staycounter == 18)
            {
                Room2();
            }

            if (staycounter == 30 || staycounter == 35 || staycounter == 40)
            {
                Room2();
            }

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
            PictureBoxCreator(ref enemeyPictureBox, 500, 500, this.StartScreenPictureBox.Width / 2 + this.StartScreenPictureBox.Width / 16, this.Height / 4, EnemeyImage);;

            //full weapon path already
            String EnemeyWeaponPath = tempEnemey.GetWeapon().weaponpng;
            Image EnemeyWeaponImage = Image.FromFile(EnemeyWeaponPath);
            enemeyWeaponPictureBox = null;
            enemeyWeaponPictureBox = new();
            PictureBoxCreator(ref enemeyWeaponPictureBox, 200, 200, enemeyPictureBox.Location.X, enemeyPictureBox.Location.Y + enemeyPictureBox.Height/2, EnemeyWeaponImage);
            EnemeyStatsLabelUpdater(ref tempEnemey);
            //we can launch the fight like so
            if (staycounter < 10)
            {
                Arena.LaunchFight(ref mainPlayer, ref tempEnemey, tempRandGen, this);
            } 
            else if (staycounter < 30)
            {
                if (ancientGobbo == null)
                {
                    ancientGobbo = Enemey.GenerateEnemey(TowerLevel + (staycounter / 2));
                }
                enemeyWeaponPictureBox.Hide();
                EnemeyImagePath = ResourcesPath + @"\ancientGobo_Crawl.png";
                EnemeyImage = Image.FromFile(EnemeyImagePath);
                PictureBoxCreator(ref enemeyPictureBox, 500, 500, this.StartScreenPictureBox.Width / 2 + this.StartScreenPictureBox.Width / 16, this.Height / 4, EnemeyImage);
                ancientGobbo.SetName("Ancient Gobbo");
                Arena.LaunchFight(ref mainPlayer, ref ancientGobbo, tempRandGen, this);
                int lspGained = tempRandGen.Next(TowerLevel, TowerLevel * 5);
                GetNarratorTextBox().Text = $"Since you killed Ancient Gobbo extra LSP is granted {lspGained} for a total of {lspGained + mainPlayer.GetLooseStatPoints()}";
                NextButtonClicked(NextButton);
                while (NextButton.Enabled == true && !isClosing)
                {
                    Application.DoEvents();
                }
                mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() + lspGained);
            } else
            {
                if (Dungeon_Soul == null)
                {
                    Dungeon_Soul = Enemey.GenerateEnemey(TowerLevel + (staycounter * 2));
                }
                enemeyWeaponPictureBox.Hide();
                EnemeyImagePath = ResourcesPath + @"\Dungeon_Soul.png";
                EnemeyImage = Image.FromFile(EnemeyImagePath);
                PictureBoxCreator(ref enemeyPictureBox, 500, 500, this.StartScreenPictureBox.Width / 2 + this.StartScreenPictureBox.Width / 16, this.Height / 4, EnemeyImage);
                Dungeon_Soul.SetName("Dungeon Soul");
                Arena.LaunchFight(ref mainPlayer, ref Dungeon_Soul, tempRandGen, this);
                int lspGained = tempRandGen.Next(TowerLevel + 5 * 2, TowerLevel + 6 * 5);
                GetNarratorTextBox().Text = $"Since you killed DungeonSoul extra LSP is granted {lspGained} for a total of {lspGained + mainPlayer.GetLooseStatPoints()}";
                NextButtonClicked(NextButton);
                while (NextButton.Enabled == true && !isClosing)
                {
                    Application.DoEvents();
                }
            }
            EnemeyStatsCleaner();
            this.Controls.Remove(enemeyWeaponPictureBox);
            enemeyWeaponPictureBox.Dispose();
            this.Controls.Remove(enemeyPictureBox);
            enemeyPictureBox.Dispose();
            PlayerStatsLabelUpdater();
            GetNarratorTextBox().Text = "you march on";
        }

        public void CheckMoneyFunc(Object sender, EventArgs e) //Lucas
        {
            String CashSound = ResourcesPath + "/MoneySound.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(CashSound);
            player.Play();

            string money = mainPlayer.GetMoney().ToString();
            MessageBox.Show($"You Have ${money}");
        }

        public void BuyHealthPotFunc(Object sender, EventArgs e) //Lucas
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

        public void BuyKnifeFunc(Object sender, EventArgs e) //Lucas
        {
            int money = mainPlayer.GetMoney();
            if (money >= 3)
            {
                String BuySound = ResourcesPath + "/ItemGot.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(BuySound);
                player.Play();

                mainPlayer.SetDamage(mainPlayer.GetDamage() + 1);
                mainPlayer.SetMoney(money - 3);
                MessageBox.Show("You bought a knife and gained 1 damage.\nYour damage is now: " + mainPlayer.GetDamage().ToString());//use the narrator text box plox
            }
            else
            {
                MessageBox.Show("You don't have enough money for that. Remaining balance is $" + money.ToString());
            }
        }

        public void BuyBananaFunc(Object sender, EventArgs e) //Lucas
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

        public void BuyHelmetFunc(Object sender, EventArgs e) //Lucas
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

        public void ShopButton(Object sender, EventArgs e)
        {
            PlayerStatsHider();
            bool upgradedoor = false;
            if (upgradeButton.Enabled == true)
            {
                upgradedoor = true;
                upgradeButton.Hide();
                upgradeButton.Enabled = false;
            }
            shopButton.Hide();
            shopButton.Enabled = false;
            caveButton.Hide();
            caveButton.Enabled = false;
            Shop();
            shopButton.Show();
            shopButton.Enabled = true;
            caveButton.Show();
            caveButton.Enabled = true;
            PlayerStatsShow();
            if (upgradedoor)
            {
                upgradeButton.Show();
                upgradeButton.Enabled = true;
                mainImage = Image.FromFile(upgradeRoomPath);
                StartScreenPictureBox.Image = mainImage;
                return;
            }
            mainImage = Image.FromFile(notupgradeRoomPath);
            StartScreenPictureBox.Image = mainImage;
        }

        public void UpgradeRoomButton(Object sender, EventArgs e)
        {
            shopButton.Hide();
            shopButton.Enabled = false;
            upgradeButton.Hide();
            upgradeButton.Enabled = false;
            caveButton.Hide();
            caveButton.Enabled = false;
            Room2();
            shopButton.Show();
            shopButton.Enabled = true;
            upgradeButton.Show();
            upgradeButton.Enabled = true;
            caveButton.Show();
            caveButton.Enabled = true;
            mainImage = Image.FromFile(upgradeRoomPath);
            StartScreenPictureBox.Image = mainImage;
        }

        //EXTRA BUTTON FUNCTIONS
        public void healthButtonFunc(Object sender, EventArgs e)
        {
            if (mainPlayer.GetLooseStatPoints() > 0)
            {
                mainPlayer.SetHealth(mainPlayer.GetHealth() + 1);
                mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
                //play sound as you upgrade
                String upgradeSound = ResourcesPath + "/upgradeSound.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(upgradeSound);
                player.Play();
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
                //play sound as you upgrade
                String upgradeSound = ResourcesPath + "/upgradeSound.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(upgradeSound);
                player.Play();
                //update labels
                PlayerStatsLabelUpdater();
            }
        }

        public void ArmorButtonFunc(Object sender, EventArgs e)
        {
            if (mainPlayer.GetLooseStatPoints() > 1)
            {
                mainPlayer.SetArmor(mainPlayer.GetArmor() + 1);
                mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 2);
                //play sound as you upgrade
                String upgradeSound = ResourcesPath + "/upgradeSound.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(upgradeSound);
                player.Play();
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
                //play sound as you upgrade
                String upgradeSound = ResourcesPath + "/upgradeSound.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(upgradeSound);
                player.Play();
                //update labels
                PlayerStatsLabelUpdater();
            }
        }

        public void NextButtonClicked(Button button)
        {
            button.BringToFront();
            button.Text = "NEXT";
            button.Show();
            button.Enabled = true;

            EventHandler tempEvent = null;
            tempEvent = (s, e) => //lamda function is the same as making a function called void somthing(Object sender, EventArgs, arg){stuff;}
            {
                button.Click -= tempEvent;
                button.Enabled = false;
                button.Hide();
            };
            //subscribe to the event lol
            button.Click += tempEvent;
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
            if (healthLabel == null || armorLabel == null || damageLabel == null || speedLabel == null || looseStatPoints == null || counterLabel == null || potionCountLabel == null)
            {
                healthLabel = null;
                armorLabel = null;
                damageLabel = null;
                speedLabel = null;
                looseStatPoints = null;
                counterLabel = null;
                potionCountLabel = null;

                healthLabel = new Label();
                armorLabel = new Label();
                damageLabel = new Label();
                speedLabel = new Label();
                looseStatPoints = new Label();
                counterLabel = new Label();
                potionCountLabel = new Label();
            }
            //this is probably overkill but im not trying to figure out why label.Location.X = some number does not work thats not very fortnite
            LabelCreator(ref healthLabel, "healthLabelForm", 30, 0, 100, 70, $"HP: {mainPlayer.GetHealth()}");
            LabelCreator(ref armorLabel, "armorLabelForm", healthLabel.Location.X + healthLabel.Size.Width + 30, 0, 100, 70, $"AMR: {mainPlayer.GetArmor()}");
            LabelCreator(ref damageLabel, "damageLabelForm", armorLabel.Location.X + armorLabel.Size.Width + 30, 0, 100, 70, $"DMG: {mainPlayer.GetDamage()}");
            LabelCreator(ref speedLabel, "speedLabelForm", damageLabel.Location.X + damageLabel.Size.Width + 30, 0, 100, 70, $"SPD: {mainPlayer.GetSpeed()}");
            LabelCreator(ref looseStatPoints, "looseStatPointsForm", speedLabel.Location.X + speedLabel.Size.Width + 30, 0, 100, 70, $"LSP: {mainPlayer.GetLooseStatPoints()}");
            LabelCreator(ref counterLabel, "counterLabel", looseStatPoints.Location.X + looseStatPoints.Size.Width + 30, 0, 100, 70, $"Counter: {staycounter}");
            LabelCreator(ref potionCountLabel, "potionCountLabel", counterLabel.Location.X + counterLabel.Size.Width + 30, 0, 100, 70, $"Potions: {mainPlayer.GetPotionCount()}");
            musicButton.Location = new Point(potionCountLabel.Location.X + potionCountLabel.Width + 30, 0);
            Application.DoEvents();
        }

        public void EnemeyStatsLabelUpdater(ref Enemey enemey)
        {
            if (enemeyhealthLabel == null || enemeyarmorLabel == null || enemeydamageLabel == null || enemeyspeedLabel == null)
            {
                enemeyhealthLabel = null;
                enemeyarmorLabel = null;
                enemeydamageLabel = null;
                enemeyspeedLabel = null;

                enemeyhealthLabel = new Label();
                enemeyarmorLabel = new Label();
                enemeydamageLabel = new Label();
                enemeyspeedLabel = new Label();

            }
            //this is probably overkill but im not trying to figure out why label.Location.X = some number does not work thats not very fortnite
            LabelCreator(ref enemeyhealthLabel, "enemeyhealthLabelForm", this.StartScreenPictureBox.Width / 3 + this.StartScreenPictureBox.Width / 6, this.Height / 6, 50, 50, $"HP: {enemey.GetHealth()}", Color.Red);
            LabelCreator(ref enemeyarmorLabel, "enemeyarmorLabelForm", enemeyhealthLabel.Location.X + enemeyhealthLabel.Size.Width + 30, enemeyhealthLabel.Location.Y, 50, 50, $"AMR: {enemey.GetArmor()}", Color.Red);
            LabelCreator(ref enemeydamageLabel, "enemeydamageLabelForm", enemeyarmorLabel.Location.X + enemeyarmorLabel.Size.Width + 30, enemeyhealthLabel.Location.Y, 50, 50, $"DMG: {enemey.GetDamage()}", Color.Red);
            LabelCreator(ref enemeyspeedLabel, "enemeyspeedLabelForm", enemeydamageLabel.Location.X + enemeydamageLabel.Size.Width + 30, enemeyhealthLabel.Location.Y, 50, 50, $"SPD: {enemey.GetSpeed()}", Color.Red);
            Application.DoEvents();
        }

        public void EnemeyStatsCleaner()
        {
            enemeyhealthLabel.Hide();
            enemeyarmorLabel.Hide();
            enemeydamageLabel.Hide();
            enemeyspeedLabel.Hide();
            Controls.Remove(enemeyhealthLabel);
            Controls.Remove(enemeyarmorLabel);
            Controls.Remove(enemeydamageLabel);
            Controls.Remove(enemeyspeedLabel);
            enemeyhealthLabel.Dispose();
            enemeyarmorLabel.Dispose();
            enemeydamageLabel.Dispose();
            enemeyspeedLabel.Dispose();
            enemeyhealthLabel = null;
            enemeyarmorLabel = null;
            enemeydamageLabel = null;
            enemeyspeedLabel = null;
            Application.DoEvents();
        }

        public void PlayerStatsHider()
        {
            healthLabel.Hide();
            armorLabel.Hide();
            damageLabel.Hide();
            speedLabel.Hide();
            looseStatPoints.Hide();
            counterLabel.Hide();
            potionCountLabel.Hide();
            Application.DoEvents();
        }

        public void PlayerStatsShow()
        {
            healthLabel.Show();
            armorLabel.Show();
            damageLabel.Show();
            speedLabel.Show();
            looseStatPoints.Show();
            counterLabel.Hide();
            potionCountLabel.Hide();
            Application.DoEvents();
        }

        public void MusicButton(Object sender, EventArgs e)
        {
            string newMusic = casualMusicPath;
            if (staycounter == 999)
            {
                if (musicCounter % 2 == 0)
                {
                    newMusic = ResourcesPath + "/Beserk_My_Brother.mp3";
                    MusicHelperNewSong(newMusic, musicOutput.Volume);
                    musicCounter++;
                } else
                {
                    MusicHelperNewSong(finalBossMusicPath, musicOutput.Volume);
                    musicCounter++;
                }
                    return;
            }
            if (musicCounter == 4 && TowerLevel < 3)
            {
                musicCounter++;
            }
            if (musicCounter == 5 && TowerLevel < 5)
            {
                musicCounter++;
            }
            if (staycounter < 10 && musicCounter == 6)
            {
                musicCounter++;
            }
            if (staycounter < 30 && musicCounter == 7)
            {
                musicCounter++;
            }

            if (musicCounter > 8)
            {
                musicCounter = 0;
            }
            switch (musicCounter)
            {
                case 0:
                    newMusic = casualMusicPath;
                    break;
                case 1: 
                    newMusic = ResourcesPath + "/Faded.mp3";
                    break;
                case 2:
                    newMusic = ResourcesPath + "/Hyper_Full_Throttle.mp3";
                    break;
                case 3:
                    newMusic = ResourcesPath + "/SNBRN_Raindrops.mp3";
                    break;
                case 4:
                        newMusic = ResourcesPath + "/Warak_Reanimate.mp3";
                    break;
                case 5:
                        newMusic = ResourcesPath + "/GalaxyCollapse.mp3";
                    break;
                case 6:
                       newMusic = ancientGobboMusicPath;
                    break;
                case 7:
                    newMusic = dungeonSoulMusicPath;
                    break;
                case 8:
                    newMusic = ResourcesPath + "/Guts_Pressure.mp3";
                    break;
            }
            MusicHelperNewSong(newMusic, musicOutput.Volume);
            musicCounter++;
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

        public void LabelCreator(ref Label label, string name, int x, int y, int sizeX, int sizeY, string text, Color color)
        {
            label.Location = new Point(x, y);
            label.Name = name;
            label.Size = new Size(sizeX, sizeY);
            label.AutoSize = true;
            label.Text = text;
            label.BorderStyle = BorderStyle.Fixed3D;
            label.BackColor = color;
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
