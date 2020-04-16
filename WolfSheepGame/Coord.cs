using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    public struct Coord
    {
        public int Column { get; }
        public int Row { get; }

        public Coord(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}";
        }
    }
}
