using System;
using System.Collections.Generic;
using System.Text;


namespace WolfSheepGameLP1
{
    public abstract class Piece
    {
        public BoardSquare BoardSquare { get; set; }

        public abstract char Unicode { get; }
    }
}
