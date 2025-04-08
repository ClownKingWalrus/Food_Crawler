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
        Label? healthLabel;
        Label? armorLabel;
        Label? speedLabel;
        Label? damageLabel;
        Label? looseStatPoints;
        PictureBox? enemeyPictureBox;
        PictureBox? enemeyWeaponPictureBox;
        PictureBox? playerPictureBox;

        public String ResourcesPath = @"..\..\..\Resources";
        public Image mainImage;

        Player mainPlayer;
        public int TowerLevel = 1;
        public Form1()
        {
            //AllocConsole(); //console for testing
            InitializeComponent();
            String paintDoorsPath = ResourcesPath + "/paintdoors.png";
            mainImage = Image.FromFile(paintDoorsPath);
            mainPlayer = new Player();
            //functions = new List<Action<int>>()
            //{
            //    Room1,
            //    Room2
            //};

            this.StartScreenPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.StartScreenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.StartScreenPictureBox.Image = mainImage;
        }

        private void StartMenuButton_Click(object sender, EventArgs e)
        {
            GenericFight();
        }

        public TextBox GetNarratorTextBox()
        {
            return this.StartMenuTextBox;
        }
    }
}
