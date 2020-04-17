using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    /// <summary>
    /// Class representing the Sheep Player. Inherits from <see cref="Player"/>.
    /// </summary>
    public class SheepPlayer : Player
    {
        /// <summary>
        /// The pieces belonging to the Sheep Player.
        /// </summary>
        public SheepPiece[] Pieces { get; private set; }

        /// <summary>
        /// Create a new instance of <see cref="SheepPlayer"/>.
        /// Calls base constructor.
        /// </summary>
        /// <param name="pieceCount">The number of <see cref="SheepPiece"/> to add.</param>
        public SheepPlayer(uint pieceCount) : base()
        {
            Pieces = new SheepPiece[pieceCount];

            for (int i = 0; i < pieceCount; i++)
            {
                Pieces[i] = new SheepPiece();
            }
        }
    }
}
