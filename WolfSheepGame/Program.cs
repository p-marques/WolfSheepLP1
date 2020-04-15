using System;
using System.Text;

namespace WolfSheepGame
{
    class Program
    {
        /// <summary>
        /// Program stating point.
        /// </summary>
        /// <param name="args">Optional arguments. Allowed arguments: -s.</param>
        static void Main(string[] args)
        {
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

                // TODO Play()
            }
        }
    }
}
