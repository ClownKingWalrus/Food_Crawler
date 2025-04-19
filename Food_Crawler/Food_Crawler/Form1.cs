using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;

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
        Label? healthLabel;
        Label? armorLabel;
        Label? speedLabel;
        Label? damageLabel;
        Label? looseStatPoints;
        PictureBox? enemeyPictureBox;
        PictureBox? enemeyWeaponPictureBox;
        PictureBox? playerPictureBox;
        // Added these new button declarations
        Button? BuyHealthPotButton;
        Button? BuyKnifeButton;
        Button? CheckMoneyButton;
        Button? BuyBananaButton;
        Button? BuyHelmetButton;

        public bool isInFight = false; 
        public bool gameOver = false;
        public string ResourcesPath = @"..\..\..\Resources";
        public Image mainImage;
        Player mainPlayer;
        public int TowerLevel = 1;

        public Form1()
        {
            InitializeComponent();
            string paintDoorsPath = ResourcesPath + "/paintdoors.png";
            mainImage = Image.FromFile(paintDoorsPath);
            mainPlayer = new Player();
            mainPlayer.SetHealth(1000);
            mainPlayer.SetSpeed(1000);
            mainPlayer.SetDamage(100);
            mainPlayer.SetMoney(20);  // Added these lines to initialize money and lootbag
            mainPlayer.SetNewLootBag();  
            this.StartScreenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.StartScreenPictureBox.Image = mainImage;

            // Hid the scene selection and stat buttons at start
            room1Button.Visible = false;
            room2Button.Visible = false;
            fightRoomButton.Visible = false;

     
            increaseHealthButton.Visible = false;
            increaseSpeedButton.Visible = false;
        }

        private void StartMenuButton_Click(object sender, EventArgs e)
        {
            StartMenuTextBox.Text = "Where would you like to go?";
            room1Button.Visible = true;
            room2Button.Visible = true;
            fightRoomButton.Visible = true;
        }

        public TextBox GetNarratorTextBox()
        {
            return this.StartMenuTextBox;
        }

        private void InventoryButton_Click(object sender, EventArgs e)
        {
            var inventoryForm = new InventoryForm(mainPlayer.GetLootBag());
            inventoryForm.ShowDialog();
        }
        //Tony
        private void AllocateStat(string stat)//letting player allocate stats
        {
            if (mainPlayer.GetLooseStatPoints() <= 0)
            {
                MessageBox.Show("No stat points left!");
                return;
            }

            switch (stat)
            {
                case "health":
                    mainPlayer.SetHealth(mainPlayer.GetHealth() + 10);
                    break;
                case "speed":
                    mainPlayer.SetSpeed(mainPlayer.GetSpeed() + 5);
                    break;
            }

            mainPlayer.SetLooseStatPoints(mainPlayer.GetLooseStatPoints() - 1);
        }
        //Tony
        private void SelectRoom(string roomName)
        {
            ClearDynamicControls(); 
            HideCustomSceneButtons();
            isInFight = false; // stop any ongoing fights

            
            if (enemeyPictureBox != null)
            {
                enemeyPictureBox.Visible = false;
                enemeyPictureBox.Dispose();
                enemeyPictureBox = null;
            }
            if (enemeyWeaponPictureBox != null)
            {
                enemeyWeaponPictureBox.Visible = false;
                enemeyWeaponPictureBox.Dispose();
                enemeyWeaponPictureBox = null;
            }


            if (roomName != "Room2")
            {
                ClearDynamicControls(); // hides stat allocation UI
            }


            switch (roomName)
            {
                case "Room1":
                    Room1();
                    break;
                case "Room2":
                    Room2();
                    break;
                case "FightRoom":
                    GenericFight();
                    returnToMenuButton.Visible = true;
                    break;
                case "Shop":
                    Shop();
                    returnToMenuButton.Visible = true;
                    break;
            }
            if (isInFight)
            {
                isInFight = false;
                StartMenuTextBox.Text = "You ran away from the fight...";
            }
        }
        //Tony
        private void ReturnToMenuButton_Click(object sender, EventArgs e)
        {
            ClearDynamicControls();
            HideCustomSceneButtons();
            isInFight = false; // resetting the game stat

           
            if (enemeyPictureBox != null)
            {
                enemeyPictureBox.Visible = false;
                enemeyPictureBox.Dispose();
                enemeyPictureBox = null;
            }
            if (enemeyWeaponPictureBox != null)
            {
                enemeyWeaponPictureBox.Visible = false;
                enemeyWeaponPictureBox.Dispose();
                enemeyWeaponPictureBox = null;
            }

            string paintDoorsPath = ResourcesPath + "/paintdoors.png";
            mainImage = Image.FromFile(paintDoorsPath);
            StartScreenPictureBox.Image = mainImage;
            StartMenuTextBox.Text = "You find yourself at the doors of this dungeon. You take a moment to reflect on your past";

            room1Button.Visible = true;
            room2Button.Visible = true;
            fightRoomButton.Visible = true;
            inventoryButton.Visible = true; 
            shopButton.Visible = true;       

            if (enemeyPictureBox != null) enemeyPictureBox.Visible = false;
            if (enemeyWeaponPictureBox != null) enemeyWeaponPictureBox.Visible = false;
        }
        //Tony
        private void HideCustomSceneButtons()
        {
            if (increaseHealthButton != null) increaseHealthButton.Visible = false;
            if (increaseSpeedButton != null) increaseSpeedButton.Visible = false;
            if (room1Button != null) room1Button.Visible = false;
            if (room2Button != null) room2Button.Visible = false;
            if (fightRoomButton != null) fightRoomButton.Visible = false;
            if (returnToMenuButton != null) returnToMenuButton.Visible = false;
            // thought inventory should always be visible here so did not include
        }
        //Tony
        private void ClearDynamicControls()
        {
            // Clearing stat-related controls
            if (healthButton != null) { healthButton.Dispose(); healthButton = null; }
            if (armorButton != null) { armorButton.Dispose(); armorButton = null; }
            if (damageButton != null) { damageButton.Dispose(); damageButton = null; }
            if (speedButton != null) { speedButton.Dispose(); speedButton = null; }
            
            if (healthLabel != null) { healthLabel.Dispose(); healthLabel = null; }
            if (armorLabel != null) { armorLabel.Dispose(); armorLabel = null; }
            if (damageLabel != null) { damageLabel.Dispose(); damageLabel = null; }
            if (speedLabel != null) { speedLabel.Dispose(); speedLabel = null; }
            if (looseStatPoints != null) { looseStatPoints.Dispose(); looseStatPoints = null; }

            // Clear shop-related controls
            if (CheckMoneyButton != null) { CheckMoneyButton.Dispose(); CheckMoneyButton = null; }
            if (BuyHealthPotButton != null) { BuyHealthPotButton.Dispose(); BuyHealthPotButton = null; }
            if (BuyKnifeButton != null) { BuyKnifeButton.Dispose(); BuyKnifeButton = null; }
            if (BuyBananaButton != null) { BuyBananaButton.Dispose(); BuyBananaButton = null; }
            if (BuyHelmetButton != null) { BuyHelmetButton.Dispose(); BuyHelmetButton = null; }

            
            this.Refresh();
        }
    }
}
