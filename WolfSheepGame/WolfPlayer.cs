﻿using System;
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
        /// <param name="name">The name of the player.</param>
        public WolfPlayer(string name) : base(name)
        {
            Piece = new WolfPiece();

            AllowedMoveDirections = new Direction[] { Direction.TopLeft, Direction.TopRight, Direction.BottomLeft, Direction.BottomRight };
        }
    }
}
