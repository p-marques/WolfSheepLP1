using System;
using System.Text;
using WolfSheepGameLP1.UI;

namespace WolfSheepGameLP1
{
    class Program
    {
        /// <summary>
        /// The UI Manager. Responsible for keeping the UI updated.
        /// </summary>
        public static ConsoleUserInterface UIManager { get; private set; }

        /// <summary>
        /// Program stating point.
        /// </summary>
        /// <param name="args">Optional arguments. Allowed arguments: -s.</param>
        static void Main(string[] args)
        {
            // Create instance of the user interface manager
            UIManager = new ConsoleUserInterface();

            // Handle arguments
            Options op = Options.ParseOptionsFromArgs(args);

            // Something went wrong parsing arguments?
            if (op.Error)
            {
                Console.WriteLine(op.ErrorMsg);
            }
            else
            {
                // Creates game instance
                Game game = new Game(op);

                // Start playing
                game.Play();
            }
        }
    }
}
