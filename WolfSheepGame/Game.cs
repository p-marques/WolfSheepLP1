using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    /// <summary>
    /// Class responsible for managing the entire game's flow.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The game's options.
        /// </summary>
        private readonly Options gameOptions;

        /// <summary>
        /// The player controlling the wolf.
        /// </summary>
        public WolfPlayer PlayerWolf { get; }

        /// <summary>
        /// The player controlling the sheep.
        /// </summary>
        public SheepPlayer PlayerSheep { get; }

        /// <summary>
        /// The game's board.
        /// </summary>
        public Board Board { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Game"/>.
        /// </summary>
        /// <param name="options">Game options.</param>
        public Game(Options options)
        {
            gameOptions = options;

            PlayerWolf = new WolfPlayer();

            // No rounding or parsing necessary.
            // Validation done by Options garantees the BoardSize is an even number,
            // making gameOptions.BoardSize / 2 always result in a uint.
            PlayerSheep = new SheepPlayer(gameOptions.BoardSize / 2);

            Board = new Board(gameOptions.BoardSize);
        }

        public void Play()
        {
            Program.UIManager.SetupUI(Board);

            Program.UIManager.RefreshUI();
        }
    }
}
