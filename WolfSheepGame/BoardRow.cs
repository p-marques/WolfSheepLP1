using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    public class BoardRow
    {
        public BoardSquare[] Squares { get; private set; }

        public BoardRow(int rowIndex, uint size)
        {
            this.Squares = new BoardSquare[size];

            for (int i = 0; i < size; i++)
            {
                this.Squares[i] = new BoardSquare(i, rowIndex);
            }
        }

        /// <summary>
        /// Get all of the playable squares in this row.
        /// </summary>
        /// <returns>Array with all playable squares in this row.</returns>
        public BoardSquare[] GetPlayableSquares()
        {
            return Array.FindAll(Squares, x => x.IsPlayable);
        }
    }
}