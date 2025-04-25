using System.Media;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using NAudio.Wave;

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
        Button? musicButton;
        bool isClosing = false;

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
        Label? counterLabel;
        Label? potionCountLabel;
        public int staycounter;

        Label enemeyhealthLabel;
        Label? enemeyarmorLabel;
        Label? enemeyspeedLabel;
        Label? enemeydamageLabel;
        PictureBox? enemeyPictureBox;
        PictureBox? enemeyWeaponPictureBox;
        PictureBox? playerPictureBox;
        public bool gameOver = false;

        //music moment
        SoundPlayer mainMusic;
        WaveOutEvent musicOutput;
        AudioFileReader musicReader;
        
        String casualMusicPath;
        String ancientGobboMusicPath;
        String dungeonSoulMusicPath;
        String finalBossMusicPath;
        String treasureRoomMusicPath;

        public String ResourcesPath;
        public String? upgradeRoomPath;
        public String? notupgradeRoomPath;
        public String? BADROOMPath;
        public String? ChoiceDownFloor;
        public Image mainImage;

        Player mainPlayer;
        Enemey ancientGobbo;
        Enemey Dungeon_Soul;
        Enemey FinalBoss;
        public int TowerLevel = 1;
        public int musicCounter = 0;
        public Form1()
        {   //startmenubutton is the NextButton

            //AllocConsole(); //console for testing
            InitializeComponent();
            this.FormClosing += CloseProperly;

#if DEBUG
            ResourcesPath = @"..\..\..\Resources";
#else
            ResourcesPath = Application.StartupPath;
            ResourcesPath = ResourcesPath + @"\Resources";
#endif

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
            //music stuff
            casualMusicPath = ResourcesPath + "/Dungeon_Crawl.mp3";
            ancientGobboMusicPath = ResourcesPath + "/WAR_Divide.mp3";
            dungeonSoulMusicPath = ResourcesPath + "/WE_FIGHT.mp3";
            treasureRoomMusicPath = ResourcesPath + "/Spindash.mp3";
            finalBossMusicPath = ResourcesPath + "/Bow_Down.mp3";
            mainMusic = new();
        }

        protected void CloseProperly(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
            mainPlayer.SetIsClosingTrue();
            if (musicOutput == null || musicReader == null)
            {
                musicReader = new(casualMusicPath);
                musicOutput = new();
            }
            musicOutput.Dispose();
            musicReader.Dispose();
            Application.Exit();
            //Environment.Exit(0);
        }

        private void StartMenuButton_Click(object sender, EventArgs e)
        {
            int counter = 0;
            staycounter = 0;
            Random tempRandom = new();
            int tempnum = 0;
            upgradeRoomPath = ResourcesPath + "/tempRoomUpgrade.png";
            notupgradeRoomPath = ResourcesPath + "/tempRoomNoUpgrade.png";
            BADROOMPath = ResourcesPath + "/tempRoomBAD.png";
            ChoiceDownFloor = ResourcesPath + "/ChoiceToGoDown.png";
            //disable as we will use another button here since this controls our main functions
            StartMenuButton.Enabled = false;
            StartMenuButton.Hide();
            //initate music
            MusicHelperNewSong(casualMusicPath);
            Room1();
            Room2();
            //create music button
            if (musicButton != null)
            {
                musicButton.Hide();
                musicButton.Dispose();
            }
            musicButton = new();
            ButtonCreator(ref musicButton, "music Button", StartScreenPictureBox.Width - 500, 0, 300, 70, "Next Song", MusicButton);
            musicButton.BackColor = Color.DarkKhaki;
            musicButton.FlatStyle = FlatStyle.Standard;
            musicButton.Font = new Font("Poor Richard", 26);

            //staycounter = 10;
            //counter = 3;
            //TowerLevel = 10;

            int playerHpBeforeFight = mainPlayer.GetHealth();
            while (!gameOver && !isClosing)
            {
                MusicFakeLooper();
                if (TowerLevel >= 10)
                {
                    MusicHelperNewSong(treasureRoomMusicPath);
                    //add a button that waits for ten seconds if they touch they get hurt if not they keep full hp

                    mainImage = Image.FromFile(ResourcesPath + "/mimic_hide.png");
                    StartScreenPictureBox.Image = mainImage;
                    this.GetNarratorTextBox().Text = "Click for loot";
                    NextButtonClicked(NextButton);
                    while (NextButton.Enabled == true && !isClosing)
                    {
                        Application.DoEvents();
                    }

                    MusicHelperNewSong(finalBossMusicPath);
                    mainImage = Image.FromFile(ResourcesPath + "/mimic.png");
                    StartScreenPictureBox.Image = mainImage;
                    staycounter = 999;
                    GenericFight();

                    //and the actual ending here
                }
                if (counter > 2)
                {
                    this.GetNarratorTextBox().Text = "or you can march ahead for a higher chance for oppurtunties";
                    Button tempChoiceStay = new();
                    Button tempChoiceGoDown = new();
                    ButtonCreator(ref tempChoiceStay, "tempChoiceStay", tempChoiceStay.Width, GetNarratorTextBox().Location.Y - 100, 100, 100, "Stay", DisableButton);
                    ButtonCreator(ref tempChoiceGoDown, "tempChoiceGoDown", tempChoiceGoDown.Width + 500, GetNarratorTextBox().Location.Y - 100, 100, 100, "Go Down", DisableButton);
                    while (tempChoiceGoDown.Enabled && tempChoiceStay.Enabled && !isClosing)
                    {
                        Application.DoEvents();
                    }
                    if (tempChoiceGoDown.Enabled) //if they choose to stay
                    {
                        staycounter++;
                        tempChoiceGoDown.Hide();
                        tempChoiceStay.Hide();
                        this.GetNarratorTextBox().Text = "You decide to stay on this level however it seems more baron then before";
                        NextButtonClicked(NextButton);
                        while (NextButton.Enabled == true && !isClosing)
                        {
                            Application.DoEvents();
                        }
                        tempnum = tempnum - counter;
                        if (staycounter >= 30)
                        {
                            MusicHelperNewSong(dungeonSoulMusicPath);
                            Dungeon_Soul = Enemey.GenerateEnemey(TowerLevel * TowerLevel + (staycounter * 2));
                        } 
                        else if (staycounter >= 10)
                        {
                            MusicHelperNewSong(ancientGobboMusicPath);
                            ancientGobbo = Enemey.GenerateEnemey(TowerLevel + (staycounter / 2));
                        }
                    }
                    else //if they go down a level
                    {
                        staycounter = 0;
                        tempChoiceGoDown.Hide();
                        tempChoiceStay.Hide();
                        this.GetNarratorTextBox().Text = "The dungeon air seems to be more stagnet than before";
                        NextButtonClicked(NextButton);
                        while (NextButton.Enabled == true && !isClosing)
                        {
                            Application.DoEvents();
                        }
                        TowerLevel++;
                        counter = 0;
                        this.GetNarratorTextBox().Text = "this area seems to be a staging area? increasing odds by 50%";
                        NextButtonClicked(NextButton);
                        while (NextButton.Enabled == true && !isClosing)
                        {
                            Application.DoEvents();
                        }
                        tempnum = tempnum + 5;
                    }
                    this.Controls.Remove(tempChoiceStay);
                    this.Controls.Remove(tempChoiceGoDown);
                    tempChoiceGoDown.Dispose();
                    tempChoiceGoDown.Dispose();
                    
                }
                this.GetNarratorTextBox().Text = "You can decide decide to rest here for a chance to possibly miss oppurnities";
                NextButtonClicked(NextButton);
                while (NextButton.Enabled == true && !isClosing)
                {
                    Application.DoEvents();
                }
                this.GetNarratorTextBox().Text = "or you can march ahead for a higher chance for oppurtunties";
                Button tempChoiceRest = new();
                Button tempChoiceMarch = new();
                ButtonCreator(ref tempChoiceRest, "tempChoiceRest", tempChoiceRest.Width, GetNarratorTextBox().Location.Y - 100, 100, 100, "Rest", DisableButton);
                ButtonCreator(ref tempChoiceMarch, "tempChoiceMarch", tempChoiceMarch.Width + 500, GetNarratorTextBox().Location.Y - 100, 100, 100, "March", DisableButton);
                while (tempChoiceMarch.Enabled && tempChoiceRest.Enabled && !isClosing)
                {
                    Application.DoEvents();
                }
                if (tempChoiceMarch.Enabled) //if they choose to rest
                {
                    int beforehp = mainPlayer.GetHealth();
                    mainPlayer.SetHealth(playerHpBeforeFight);
                    this.GetNarratorTextBox().Text = $"You eat some moldy bread or somthing";
                    PlayerStatsLabelUpdater();
                    NextButtonClicked(NextButton);
                    while (NextButton.Enabled == true && !isClosing)
                    {
                        Application.DoEvents();
                    }
                }
                else //if they choose to march
                {
                    tempnum = tempnum + 2;
                    this.GetNarratorTextBox().Text = $"increasing odds by 20%";
                    NextButtonClicked(NextButton);
                    while (NextButton.Enabled == true && !isClosing)
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
                ButtonCreator(ref shopButton, "shopButton", StartScreenPictureBox.Width/4 + StartScreenPictureBox.Width / 14, StartScreenPictureBox.Height / 2, 100, 100, "1", ShopButton);
                ButtonCreator(ref upgradeButton, "upgradeButton", StartScreenPictureBox.Width - StartScreenPictureBox.Width / 7, StartScreenPictureBox.Height / 2, 100, 100, "2", UpgradeRoomButton);
                ButtonCreator(ref caveButton, "caveButton", StartScreenPictureBox.Width / 2 + StartScreenPictureBox.Width / 11, StartScreenPictureBox.Height / 2, 100, 100, "3", DisableButton);
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
                    while (caveButton.Enabled && !isClosing)
                    {
                        MusicFakeLooper();
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
                    while (caveButton.Enabled && !isClosing)
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
                    while (caveButton.Enabled && !isClosing)
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
                counter++;
                tempnum = 0;
            }
        }

        public TextBox GetNarratorTextBox()
        {
            return this.StartMenuTextBox;
        }

        public void MusicHelperNewSong(String musicPath)
        {
            if (musicOutput == null || musicReader == null)
            {
                musicReader = new(musicPath);
                musicOutput = new();
            }
            musicOutput.Dispose();
            musicReader.Dispose();
            musicReader = new(musicPath);
            musicOutput = new();
            musicOutput.Volume = (float)0.1;
            musicOutput.Init(musicReader);
            musicOutput.Play();
        }

        public void MusicFakeLooper()
        {
            if (musicOutput.PlaybackState == PlaybackState.Stopped)
            {
                musicReader.Position = 0;
                musicOutput.Play();
            }
        }
        public bool GetIsClosing()
        {
            return isClosing;
        }
    }
}
