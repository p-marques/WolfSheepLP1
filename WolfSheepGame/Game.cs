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

            PlayerWolf = new WolfPlayer(gameOptions.WolfPlayerName);

            // No rounding or parsing necessary.
            // Validation done by Options garantees the BoardSize is an even number,
            // making gameOptions.BoardSize / 2 always result in a uint.
            PlayerSheep = new SheepPlayer(gameOptions.BoardSize / 2, gameOptions.SheepPlayerName);

            Board = new Board(gameOptions.BoardSize);
            Board.SetupGamePieces(PlayerSheep);
        }

        public void Play()
        {
            bool playing;

            Program.UIManager.SetupUI(Board);

            Program.UIManager.RefreshUI();

            playing = true;

            // Main game loop
            while (playing)
            {
                if (PlayerWolf.RoundCounter > 0 && !Board.GetPlayerHasPossibleMoves(PlayerWolf))
                {
                    Program.UIManager.DisplayGameOverScreen(PlayerSheep);

                    break;
                }

                // Wolf player plays
                playing = Program.UIManager.PromptPlayerToMovePiece(PlayerWolf);

                // If Wolf player didn't ask to quit the game
                if (playing)
                {
                    if (Board.GetHasWolfPlayerWon(PlayerWolf) || !Board.GetPlayerHasPossibleMoves(PlayerSheep))
                    {
                        Program.UIManager.DisplayGameOverScreen(PlayerWolf);
                        break;
                    }

                    // Sheep player plays
                    playing = Program.UIManager.PromptPlayerToMovePiece(PlayerSheep);
                }
            }
        }
    }
}
