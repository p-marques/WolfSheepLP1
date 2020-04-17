using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1.UI
{
    /// <summary>
    /// Struct containing all of the default settings for the console UI.
    /// Console colors -> color[something]
    /// Cursor positions -> pos[something]
    /// Width/Height (size) -> size[something]
    /// </summary>
    public struct ConsoleSettings
    {
        /// <summary>
        /// The default background color for the console.
        /// </summary>
        public const ConsoleColor colorConsoleBg = ConsoleColor.Black;

        /// <summary>
        /// The default foreground color for the console.
        /// </summary>
        public const ConsoleColor colorConsoleFg = ConsoleColor.White;

        /// <summary>
        /// The default background color for the title.
        /// </summary>
        public const ConsoleColor colorTitleBg = ConsoleColor.White;

        /// <summary>
        /// The default foreground color for the title.
        /// </summary>
        public const ConsoleColor colorTitleFg = ConsoleColor.Black;

        /// <summary>
        /// The default background color for a board square.
        /// </summary>
        public const ConsoleColor colorBoardSquareBg = ConsoleColor.Gray;

        /// <summary>
        /// The default background color for a playable board square.
        /// </summary>
        public const ConsoleColor colorBoardSquarePlayableBg = ConsoleColor.Cyan;

        /// <summary>
        /// The default foreground color for a board square.
        /// </summary>
        public const ConsoleColor colorBoardSquareFg = ConsoleColor.White;

        /// <summary>
        /// The default left cursor position of the title.
        /// </summary>
        public const int posTitleLeft = 1;

        /// <summary>
        /// The default top cursor position of the title.
        /// </summary>
        public const int posTitleTop = 1;

        /// <summary>
        /// The default left cursor position of the board.
        /// </summary>
        public const int posBoardLeft = 1;

        /// <summary>
        /// The default top cursor position of the board.
        /// </summary>
        public const int posBoardTop = 5;

        /// <summary>
        /// The default size of a square of the board.
        /// </summary>
        public const int sizeBoardSquare = 3;

        /// <summary>
        /// The default index position of the piece inside a board square.
        /// </summary>
        public const int posPieceIndex = 1;
    }
}
