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
            SetConsoleColor(ConsoleSettings.ColorTitleBg, ConsoleSettings.ColorTitleFg);

            SetCursorPosition(ConsoleSettings.PosTitleLeft, ConsoleSettings.PosTitleTop);

            Console.WriteLine("╔══════════════════════╗");

            SetCursorPosition(ConsoleSettings.PosTitleLeft, null);

            Console.WriteLine("║    Wolf and Sheep    ║");

            SetCursorPosition(ConsoleSettings.PosTitleLeft, null);

            Console.WriteLine("╚══════════════════════╝");
        }

        /// <summary>
        /// Display the entire game's board.
        /// </summary>
        private void DisplayBoard()
        {
            SetCursorPosition(ConsoleSettings.PosBoardLeft, ConsoleSettings.PosBoardTop);

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
        /// /// <param name="highlight">Highlight the square? Defaults to false.</param>
        private void DisplayBoardSquare(BoardSquare square, bool highlight = false)
        {
            ConsoleColor squareBgColor;

            squareBgColor = square.IsPlayable ? 
                ConsoleSettings.ColorBoardSquarePlayableBg : ConsoleSettings.ColorBoardSquareBg;

            if (highlight)
                squareBgColor = ConsoleSettings.ColorBoardSquareHighlightedBg;

            SetConsoleColor(squareBgColor, ConsoleSettings.ColorBoardSquareFg);

            SetCursorPosition(ConsoleSettings.PosBoardLeft + square.Pos.Column * ConsoleSettings.SizeBoardSquare, 
                ConsoleSettings.PosBoardTop + square.Pos.Row);

            // Go through the square's "tiles"
            for (int i = 0; i < ConsoleSettings.SizeBoardSquare; i++)
            {
                if (i == ConsoleSettings.PosPieceIndex && square.Piece != null)
                {
                    Console.Write(square.Piece.Unicode);
                    continue;
                }

                Console.Write(" ");
            }
        }

        /// <summary>
        /// Highlights a single square on the board.
        /// </summary>
        /// <param name="square">The square to be highlighted.</param>
        private void HighlightBoardSquare(BoardSquare square)
        {
            RefreshUI();

            DisplayBoardSquare(square, true);
        }

        /// <summary>
        /// Prompt player to make a move.
        /// </summary>
        /// <param name="player">The player to be prompted.</param>
        public bool PromptPlayerToMovePiece(Player player)
        {
            ConsoleKey userInput;
            Direction directionInput;
            bool keepPlaying = true;
            Piece pieceToMove = null;
            BoardSquare destinationSquare = null;

            if (player is WolfPlayer wolfPlayer)
            {
                pieceToMove = wolfPlayer.Piece;

                if (wolfPlayer.RoundCounter == 0)
                {
                    destinationSquare = PromptWolfPlayerToSetup(wolfPlayer);

                    // If player presses ESCAPE during square selection it returns null,
                    // signaling desire to close the game.
                    if (destinationSquare == null)
                    {
                        return false;
                    }

                    board.MovePiece(pieceToMove, destinationSquare);

                    RefreshUI();

                    destinationSquare = null;
                }
            }
            else if (player is SheepPlayer sheepPlayer)
            {
                pieceToMove = PromptSheepPlayerToSelectPiece(sheepPlayer);

                // If player presses ESCAPE during piece selection it returns null,
                // signaling desire to close the game.
                if (pieceToMove == null)
                {
                    return false;
                }
            }

            // Breaking from this loop in controlled through player input.
            while (true)
            {
                userInput = GetPlayerInputKey();

                // If player hits the escape key
                if (userInput == ConsoleKey.Escape)
                {
                    if (destinationSquare != null)
                    {
                        RefreshUI();

                        destinationSquare = null;
                        
                        continue;
                    }

                    // ...set keep playing to false and get out of the loop.
                    keepPlaying = false;
                    break;
                }

                directionInput = GetDirection(userInput);

                // If the player presses enter...
                if (userInput == ConsoleKey.Enter)
                {
                    // ...and has a square selected...
                    if (destinationSquare != null)
                    {
                        // ...ask the board to make the move. If it's a success...
                        if (board.MovePiece(pieceToMove, destinationSquare))
                        {
                            // ...update the player's round counter ...
                            player.UpdateRoundCounter();

                            // ...and refresh the UI.
                            RefreshUI();

                            break;
                        }
                        // If it failed...
                        else
                        {
                            // TODO: ...tell the player why he can't make the move.
                        }
                    }
                }

                // If the move is allowed...
                if (player.GetIsMoveAllowed(directionInput))
                {
                    // ...ask the board for the destination square...
                    destinationSquare = board.GetBoardSquareByDirection(pieceToMove, directionInput);

                    // ...if the theoretical square exists...
                    if (destinationSquare != null)
                    {
                        // ...highlight it.
                        HighlightBoardSquare(destinationSquare);
                    }
                }
            }

            return keepPlaying;
        }

        /// <summary>
        /// Prompt Wolf player to select starting square.
        /// </summary>
        /// <param name="player">The player to be prompted.</param>
        /// <returns>The selected square. Returns null if player pressed the escape key.</returns>
        private BoardSquare PromptWolfPlayerToSetup(WolfPlayer player)
        {
            ConsoleKey userInput;
            Direction directionInput;
            BoardSquare square;
            BoardSquare[] allowedSquares = board.Rows[0].GetPlayableSquares();

            int currentSquareIndex = 0;

            while (true)
            {
                square = allowedSquares[currentSquareIndex];

                HighlightBoardSquare(square);

                userInput = GetPlayerInputKey();

                // If player presses enter...
                if (userInput == ConsoleKey.Enter)
                {
                    // ...refresh the UI...
                    RefreshUI();

                    // ...and leave loop.
                    break;
                }
                // If the player presses escape...
                else if (userInput == ConsoleKey.Escape)
                {
                    // ...set return object to null...
                    square = null;

                    // ...set colors to default...
                    SetConsoleColorToDefault();

                    // ...and break.
                    break;
                }

                directionInput = GetDirection(userInput);

                // Left and right to move through the pieces
                if (directionInput == Direction.Left || directionInput == Direction.Right)
                {
                    switch (directionInput)
                    {
                        case Direction.Left:
                            currentSquareIndex--;
                            break;
                        case Direction.Right:
                            currentSquareIndex++;
                            break;
                    }

                    // If the index would be outside of the array.
                    if (currentSquareIndex < 0)
                    {
                        currentSquareIndex = allowedSquares.Length - 1;
                    }
                    else if (currentSquareIndex >= allowedSquares.Length)
                    {
                        currentSquareIndex = 0;
                    }
                }
            }

            return square;
        }

        /// <summary>
        /// Prompt Sheep player to select piece to move.
        /// </summary>
        /// <param name="player">The player to be prompted.</param>
        /// <returns>The selected piece to be moved. Returns null if player pressed the escape key.</returns>
        private Piece PromptSheepPlayerToSelectPiece(SheepPlayer player)
        {
            ConsoleKey userInput;
            Direction directionInput;
            Piece piece;
            int currentPieceIndex = 0;

            // Only leaves loop on player instruction
            while (true)
            {
                piece = player.Pieces[currentPieceIndex];

                HighlightBoardSquare(piece.BoardSquare);

                userInput = GetPlayerInputKey();

                // If player presses enter...
                if (userInput == ConsoleKey.Enter)
                {
                    // ...refresh the UI...
                    RefreshUI();

                    // ...and leave loop.
                    break;
                }
                // If the player presses escape...
                else if (userInput == ConsoleKey.Escape)
                {
                    // ...set return object to null...
                    piece = null;

                    // ...set colors to default...
                    SetConsoleColorToDefault();

                    // ...and break.
                    break;
                }

                directionInput = GetDirection(userInput);

                // Left and right to move through the pieces
                if (directionInput == Direction.Left || directionInput == Direction.Right)
                {
                    switch (directionInput)
                    {
                        case Direction.Left:
                            currentPieceIndex--;
                            break;
                        case Direction.Right:
                            currentPieceIndex++;
                            break;
                    }

                    // If the index would be outside of the array.
                    if (currentPieceIndex < 0)
                    {
                        currentPieceIndex = player.Pieces.Length - 1;
                    }
                    else if (currentPieceIndex >= player.Pieces.Length)
                    {
                        currentPieceIndex = 0;
                    }
                }
            }

            return piece;
        }

        /// <summary>
        /// Get input from the player.
        /// </summary>
        /// <returns>The <see cref="ConsoleKey"/> pressed.</returns>
        private ConsoleKey GetPlayerInputKey()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            return keyInfo.Key;
        }

        /// <summary>
        /// Get the desired direction from the key pressed.
        /// </summary>
        /// <param name="key">The key pressed.</param>
        /// <returns>The direction.</returns>
        public Direction GetDirection(ConsoleKey key)
        {
            Direction result = Direction.None;

            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad4:
                    result = Direction.Left;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad6:
                    result = Direction.Right;
                    break;
                case ConsoleKey.E:
                case ConsoleKey.NumPad9:
                    result = Direction.TopRight;
                    break;
                case ConsoleKey.Q:
                case ConsoleKey.NumPad7:
                    result = Direction.TopLeft;
                    break;
                case ConsoleKey.Z:
                case ConsoleKey.NumPad1:
                    result = Direction.BottomLeft;
                    break;
                case ConsoleKey.C:
                case ConsoleKey.NumPad3:
                    result = Direction.BottomRight;
                    break;
            }

            return result;
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
            SetConsoleColor(ConsoleSettings.ColorConsoleBg, ConsoleSettings.ColorConsoleFg);
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
