using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    public struct Axis
    {
        public int Column { get; }
        public int Row { get; }

        public Axis(int column, int row)
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
