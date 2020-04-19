using System;
using System.Collections.Generic;
using System.Text;


namespace WolfSheepGameLP1
{
    public abstract class Piece
    {
        public BoardSquare BoardSquare { get; private set; }

        //letter for the piece
        public abstract char Unicode { get; }

        /// <summary>
        /// Sets the reference to the current location of this piece.
        /// </summary>
        /// <param name="square">The current square this piece is at.</param>
        public void SetBoardSquareReference(BoardSquare square)
        {
            BoardSquare = square;
        }
    }
}
