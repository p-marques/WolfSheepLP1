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
        /// Creates a new instance of <see cref="Game"/>.
        /// </summary>
        /// <param name="options">Game options.</param>
        public Game(Options options)
        {
            gameOptions = options;

            PlayerWolf = new WolfPlayer();

            PlayerSheep = new SheepPlayer();
        }
    }
}
