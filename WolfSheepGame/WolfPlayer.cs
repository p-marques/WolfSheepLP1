using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    /// <summary>
    /// Class representing the Wolf Player. Inherits from <see cref="Player"/>.
    /// </summary>
    public class WolfPlayer : Player
    {
        /// <summary>
        /// The piece belonging to the Wolf Player.
        /// </summary>
        public WolfPiece Piece { get; private set; }

        /// <summary>
        /// Create a new instance of <see cref="WolfPlayer"/>.
        /// Calls base constructor.
        /// </summary>
        public WolfPlayer() : base()
        {
            Piece = new WolfPiece();
        }
    }
}
