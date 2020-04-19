using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    public struct Coord
    {
        public int Column { get; }
        public int Row { get; }

        /// <summary>
        /// Creates and coordinate x-column and y-row.
        /// </summary>
        public Coord(int column, int row)
        {
            Column = column;//x
            Row = row;//y
        }

        public override string ToString()
        {
            return $"{(char)('A' + Column)}{Row + 1}";
        }
    }
}
