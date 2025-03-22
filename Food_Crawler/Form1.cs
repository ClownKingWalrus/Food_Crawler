using System.Runtime.InteropServices;

namespace Food_Crawler
{
    public partial class Form1 : Form
    {
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
        public Form1()
        {
            AllocConsole();
            InitializeComponent();

            //this is where our actual application runs
            //initalize objects we need
            //temp players
            Player player = new Player(15, 2, 5, 6);
            Player enemey = new Player(14, 2, 3, 6);
            enemey.SetName("enemey");
            Random randNumGen = new Random();
            Arena.NormalFight(ref player, ref enemey, randNumGen);
            return;
        }
    }
}
