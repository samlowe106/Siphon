using System;

namespace Siphon
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE.
	/// sdfghjpl;'
	/// sdfghjkl;;lkjhgfdszxb
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();


        }
    }
#endif
}
