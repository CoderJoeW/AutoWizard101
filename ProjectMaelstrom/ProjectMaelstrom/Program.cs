namespace ProjectMaelstrom
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

            if (!Directory.Exists("screenshots"))
            {
                Directory.CreateDirectory("screenshots");
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new HalfangFarmingBot());
            //Application.Run(new Main());
            //Application.Run(new testing());
        }
    }
}