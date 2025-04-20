using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Food_Crawler
{
    public partial class Form1 : Form
    {
        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
        Button? healthButton;
        Button? armorButton;
        Button? speedButton;
        Button? damageButton;
        Button? BuyHealthPotButton;
        Button? BuyKnifeButton;
        Button? CheckMoneyButton;
        Button? BuyBananaButton;
        Button? BuyHelmetButton;

        //3 main rooms
        Button shopButton;
        Button upgradeButton;
        Button caveButton;

        public Button? NextButton;
        Label? healthLabel;
        Label? armorLabel;
        Label? speedLabel;
        Label? damageLabel;
        Label? looseStatPoints;
        PictureBox? enemeyPictureBox;
        PictureBox? enemeyWeaponPictureBox;
        PictureBox? playerPictureBox;
        public bool gameOver = false;

        public String ResourcesPath = @"..\..\..\Resources";
        public String? upgradeRoomPath;
        public String? notupgradeRoomPath;
        public String? BADROOMPath;
        public Image mainImage;

        Player mainPlayer;
        public int TowerLevel = 1;
        public Form1()
        {   //startmenubutton is the NextButton

            //AllocConsole(); //console for testing
            InitializeComponent();
            String paintDoorsPath = ResourcesPath + "/paintdoors.png";
            mainImage = Image.FromFile(paintDoorsPath);
            mainPlayer = new Player();

            this.StartScreenPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.StartScreenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.StartScreenPictureBox.Image = mainImage;
            //create Next button
            NextButton = new();
            NextButton.Width = StartMenuButton.Width;
            NextButton.Height = StartMenuButton.Height;
            NextButton.Location = StartMenuButton.Location;
            this.Controls.Add(NextButton);
        }

        private void StartMenuButton_Click(object sender, EventArgs e)
        {
            Random tempRandom = new();
            int tempnum = 10;
            upgradeRoomPath = ResourcesPath + "/tempRoomUpgrade.png";
            notupgradeRoomPath = ResourcesPath + "/tempRoomNoUpgrade.png";
            BADROOMPath = ResourcesPath + "/tempRoomBAD.png";
            //disable as we will use another button here since this controls our main functions
            StartMenuButton.Enabled = false;
            StartMenuButton.Hide();
            Room1();
            //Room2();
            int playerHpBeforeFight = mainPlayer.GetHealth();
            //GenericFight();
            while (!gameOver)
            {
                this.GetNarratorTextBox().Text = "You can decide decide to rest here for a chance to possibly miss oppurnities";
                NextButtonClicked(NextButton);
                while (NextButton.Enabled == true)
                {
                    Application.DoEvents();
                }
                this.GetNarratorTextBox().Text = "or you can march ahead for a higher chance for oppurtunties";
                Button tempChoiceRest = new();
                Button tempChoiceMarch = new();
                ButtonCreator(ref tempChoiceRest, "tempChoiceRest", tempChoiceRest.Width, GetNarratorTextBox().Location.Y - 100, 100, 100, "Rest", DisableButton);
                ButtonCreator(ref tempChoiceMarch, "tempChoiceMarch", tempChoiceMarch.Width + 500, GetNarratorTextBox().Location.Y - 100, 100, 100, "March", DisableButton);
                while (tempChoiceMarch.Enabled && tempChoiceRest.Enabled)
                {
                    Application.DoEvents();
                }
                if (tempChoiceMarch.Enabled) //if they choose to rest
                {
                    int beforehp = mainPlayer.GetHealth();
                    mainPlayer.SetHealth(mainPlayer.GetHealth() + (playerHpBeforeFight / 3));
                    if (mainPlayer.GetHealth() > playerHpBeforeFight)
                    {
                        mainPlayer.SetHealth(playerHpBeforeFight);
                    }
                    this.GetNarratorTextBox().Text = $"Youve chosen to heal for {mainPlayer.GetHealth() - beforehp}";
                    NextButtonClicked(NextButton);
                    while (NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                }
                else //if they choose to march
                {
                    tempnum = tempnum + 2;
                    this.GetNarratorTextBox().Text = $"increasing odds by 20%";
                    NextButtonClicked(NextButton);
                    while (NextButton.Enabled == true)
                    {
                        Application.DoEvents();
                    }
                }
                this.Controls.Remove(tempChoiceMarch);
                this.Controls.Remove(tempChoiceRest);
                tempChoiceMarch.Dispose();
                tempChoiceRest.Dispose();

                //create the 3 buttons for the options
                shopButton = new();
                upgradeButton = new();
                caveButton = new();
                ButtonCreator(ref shopButton, "shopButton", 600, GetNarratorTextBox().Location.Y - 400, 100, 100, "1", ShopButton);
                ButtonCreator(ref upgradeButton, "upgradeButton", 1800, GetNarratorTextBox().Location.Y - 400, 100, 100, "2", UpgradeRoomButton);
                ButtonCreator(ref caveButton, "caveButton", 1200, GetNarratorTextBox().Location.Y -400, 100, 100, "3", DisableButton);
                shopButton.Hide();
                shopButton.Enabled = false;
                upgradeButton.Hide();
                upgradeButton.Enabled = false;
                caveButton.Hide();
                caveButton.Enabled = false;

                tempnum = tempnum + tempRandom.Next(10);
                //once player completes a fight roll for room
                if (tempnum > 7)//upgrade shop and fight option room
                {
                    mainImage = Image.FromFile(upgradeRoomPath);
                    StartScreenPictureBox.Image = mainImage;
                    this.GetNarratorTextBox().Text = "as you enter an opening you see 3 possible options";
                    //set up all buttons
                    shopButton.Show();
                    shopButton.Enabled = true;
                    upgradeButton.Show();
                    upgradeButton.Enabled = true;
                    caveButton.Show();
                    caveButton.Enabled = true;
                    while (caveButton.Enabled)
                    {
                        Application.DoEvents();
                    }
                    Controls.Remove(shopButton);
                    shopButton.Dispose();
                    Controls.Remove(upgradeButton);
                    upgradeButton.Dispose();
                    Controls.Remove(caveButton);
                    caveButton.Dispose();
                    GenericFight();
                } else if (tempnum > 5) {//shop and fight option
                    mainImage = Image.FromFile(notupgradeRoomPath);
                    StartScreenPictureBox.Image = mainImage;
                    this.GetNarratorTextBox().Text = "as you enter an opening you see a shop and a broken in part of the wall to the right";
                    shopButton.Show();
                    shopButton.Enabled = true;
                    caveButton.Show();
                    caveButton.Enabled = true;
                    while (caveButton.Enabled)
                    {
                        Application.DoEvents();
                    }
                    Controls.Remove(shopButton);
                    shopButton.Dispose();
                    Controls.Remove(upgradeButton);
                    upgradeButton.Dispose();
                    Controls.Remove(caveButton);
                    caveButton.Dispose();
                    GenericFight();
                } else {//only fight option
                    mainImage = Image.FromFile(BADROOMPath);
                    StartScreenPictureBox.Image = mainImage;
                    this.GetNarratorTextBox().Text = "seems you will need to grit your teeth for the trials ahead";
                    caveButton.Show();
                    caveButton.Enabled = true;
                    while (caveButton.Enabled)
                    {
                        Application.DoEvents();
                    }
                    Controls.Remove(shopButton);
                    shopButton.Dispose();
                    Controls.Remove(upgradeButton);
                    upgradeButton.Dispose();
                    Controls.Remove(caveButton);
                    caveButton.Dispose();
                    GenericFight();
                }
            }
        }

        public TextBox GetNarratorTextBox()
        {
            return this.StartMenuTextBox;
        }
    }
}
