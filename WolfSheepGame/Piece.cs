using System;
using System.Collections.Generic;
using System.Text;


namespace WolfSheepGameLP1
{
    public abstract class Piece
    {
        //square of the piece
        public BoardSquare BoardSquare { get; set; }

        //letter for the piece
        public abstract char Unicode { get; }
    }
}
