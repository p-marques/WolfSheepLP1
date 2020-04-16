using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    public class BoardRow
    {
        public BoardSquare[] Squares { get; private set; }

        //creates and array of squares
        public BoardRow(int rowIndex, uint size)
        {
            this.Squares = new BoardSquare[size];

            for (int i = 0; i < size; i++)
            {
                this.Squares[i] = new BoardSquare(i, rowIndex);
            }
        }
    }
}