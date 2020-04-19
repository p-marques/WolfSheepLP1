using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1.UI
{
    /// <summary>
    /// Struct containing all of the default settings for the console UI.
    /// Console colors -> Color[something]
    /// Cursor positions -> Pos[something]
    /// Width/Height (size) -> Size[something]
    /// </summary>
    public struct ConsoleSettings
    {
        /// <summary>
        /// The default background color for the console.
        /// </summary>
        public const ConsoleColor ColorConsoleBg = ConsoleColor.Black;

        /// <summary>
        /// The default foreground color for the console.
        /// </summary>
        public const ConsoleColor ColorConsoleFg = ConsoleColor.White;

        /// <summary>
        /// The default background color for the title.
        /// </summary>
        public const ConsoleColor ColorTitleBg = ConsoleColor.White;

        /// <summary>
        /// The default foreground color for the title.
        /// </summary>
        public const ConsoleColor ColorTitleFg = ConsoleColor.Black;

        /// <summary>
        /// The default background color for a board square.
        /// </summary>
        public const ConsoleColor ColorBoardSquareBg = ConsoleColor.Gray;

        /// <summary>
        /// The default background color for a playable board square.
        /// </summary>
        public const ConsoleColor ColorBoardSquarePlayableBg = ConsoleColor.Cyan;

        /// <summary>
        /// The default background color for a highlighted board square.
        /// </summary>
        public const ConsoleColor ColorBoardSquareHighlightedBg = ConsoleColor.Red;

        /// <summary>
        /// The default foreground color for a board square.
        /// </summary>
        public const ConsoleColor ColorBoardSquareFg = ConsoleColor.Black;

        /// <summary>
        /// The default foreground color for the selected piece.
        /// </summary>
        public const ConsoleColor ColorSelectedPieceFg = ConsoleColor.White;

        /// <summary>
        /// The default background color for the log messages.
        /// </summary>
        public const ConsoleColor ColorLogMessageBg = ConsoleColor.Black;

        /// <summary>
        /// The default foreground color for the log messages.
        /// </summary>
        public const ConsoleColor ColorLogMessageFg = ConsoleColor.Yellow;

        /// <summary>
        /// The default background color for the call to action.
        /// </summary>
        public const ConsoleColor ColorCallToActionBg = ConsoleColor.Red;

        /// <summary>
        /// The default foreground for the call to action.
        /// </summary>
        public const ConsoleColor ColorCallToActionFg = ConsoleColor.White;

        /// <summary>
        /// The default left cursor position of the title.
        /// </summary>
        public const int PosTitleLeft = 1;

        /// <summary>
        /// The default top cursor position of the title.
        /// </summary>
        public const int PosTitleTop = 1;

        /// <summary>
        /// The default left cursor position of the board.
        /// </summary>
        public const int PosBoardLeft = 1;

        /// <summary>
        /// The default top cursor position of the board.
        /// </summary>
        public const int PosBoardTop = 5;

        /// <summary>
        /// The default index position of the piece inside a board square.
        /// </summary>
        public const int PosPieceIndex = 1;

        /// <summary>
        /// The default size of a square of the board.
        /// </summary>
        public const int SizeBoardSquare = 3;

        /// <summary>
        /// The maximum amount of vissible log messages.
        /// </summary>
        public const int SizeMaxLogMessages = 5;
    }
}
