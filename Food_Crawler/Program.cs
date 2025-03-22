namespace Food_Crawler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            //this is where our actual application runs
            //initalize objects we need
            //temp players
            Player player = new Player();
            Player player2 = new Player();
            Random randNumGen = new Random();
            Arena.NormalFight(ref player, ref player2, randNumGen);
        }
    }
}