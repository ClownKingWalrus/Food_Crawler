namespace Food_Crawler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //initalize objects we need
            //temp players
            //Player enemey = new Player(14, 2, 3, 6);
            //enemey.SetName("enemey");
            //Random randNumGen = new Random();
            //Arena.NormalFight(ref player, ref enemey, randNumGen);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //System.Console.WriteLine("As you enter the dungeon you reflect on your life");
            //System.Console.WriteLine("You have 20 points to spend, spend them how you like");
            Application.Run(new Form1());

        }
    }
}