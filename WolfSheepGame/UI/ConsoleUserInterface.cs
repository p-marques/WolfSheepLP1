using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1.UI
{
    /// <summary>
    /// Class responsible for managing the user interface.
    /// </summary>
    public class ConsoleUserInterface
    {
        /// <summary>
        /// The game's board.
        /// </summary>
        private Board board;

        /// <summary>
        /// Creates a new instance of <see cref="ConsoleUserInterface"/>.
        /// </summary>
        public ConsoleUserInterface()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

        }

        /// <summary>
        /// Performes any setup necessary before outputing anything to the console.
        /// </summary>
        /// <param name="inBoard">The game's board.</param>
        public void SetupUI(Board inBoard)
        {
            this.board = inBoard;
        }

        /// <summary>
        /// Clears the console and displays the entire UI.
        /// </summary>
        public void RefreshUI()
        {
            SetConsoleColorToDefault();

            Console.Clear();

            DisplayTitle();

            DisplayBoard();

            SetConsoleColorToDefault();
        }

        /// <summary>
        /// Displays the game's title.
        /// </summary>
        private void DisplayTitle()
        {
            SetConsoleColor(ConsoleSettings.colorTitleBg, ConsoleSettings.colorTitleFg);

            SetCursorPosition(ConsoleSettings.posTitleLeft, ConsoleSettings.posTitleTop);

            Console.WriteLine("╔══════════════════════╗");

            SetCursorPosition(ConsoleSettings.posTitleLeft, null);

            Console.WriteLine("║    Wolf and Sheep    ║");

            SetCursorPosition(ConsoleSettings.posTitleLeft, null);

            Console.WriteLine("╚══════════════════════╝");
        }

        /// <summary>
        /// Display the entire game's board.
        /// </summary>
        private void DisplayBoard()
        {
            SetCursorPosition(ConsoleSettings.posBoardLeft, ConsoleSettings.posBoardTop);

            // Go through the rows and display them
            for (int i = 0; i < board.Rows.Length; i++)
            {
                DisplayBoardRow(board.Rows[i]);
            }
        }

        /// <summary>
        /// Display a board row.
        /// </summary>
        /// <param name="row">The row to be displayed.</param>
        private void DisplayBoardRow(BoardRow row)
        {
            // Go through the squares and display them
            for (int i = 0; i < row.Squares.Length; i++)
            {
                DisplayBoardSquare(row.Squares[i]);
            }
        }

        /// <summary>
        /// Display a board square.
        /// </summary>
        /// <param name="square">The square to be displayed.</param>
        private void DisplayBoardSquare(BoardSquare square)
        {
            ConsoleColor squareBgColor;

            squareBgColor = square.IsPlayable ? 
                ConsoleSettings.colorBoardSquarePlayableBg : ConsoleSettings.colorBoardSquareBg;

            SetConsoleColor(squareBgColor, ConsoleSettings.colorBoardSquareFg);

            SetCursorPosition(ConsoleSettings.posBoardLeft + square.Pos.Column * ConsoleSettings.sizeBoardSquare, 
                ConsoleSettings.posBoardTop + square.Pos.Row);

            // Go through the square's "tiles"
            for (int i = 0; i < ConsoleSettings.sizeBoardSquare; i++)
            {
                if (i == ConsoleSettings.posPieceIndex && square.Piece != null)
                {
                    Console.Write(square.Piece.Unicode);
                    continue;
                }

                Console.Write(" ");
            }
        }

        /// <summary>
        /// Sets the cursor position.
        /// </summary>
        /// <param name="posLeft">Cursor left position. Pass in null to ignore.</param>
        /// <param name="posTop">Cursor top position. Pass in null to ignore.</param>
        private void SetCursorPosition(int? posLeft, int? posTop)
        {
            if (posLeft.HasValue)
            {
                Console.CursorLeft = posLeft.Value;
            }

            if (posTop.HasValue)
            {
                Console.CursorTop = posTop.Value;
            }        
        }

        /// <summary>
        /// Sets the console's colors to their default values.
        /// </summary>
        private void SetConsoleColorToDefault()
        {
            SetConsoleColor(ConsoleSettings.colorConsoleBg, ConsoleSettings.colorConsoleFg);
        }

        /// <summary>
        /// Set the colors for the background and foreground of the console.
        /// </summary>
        /// <param name="backgroundColor">Desired background color.</param>
        /// <param name="foregroundColor">Desired foreground color.</param>
        private void SetConsoleColor(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
    }
}
