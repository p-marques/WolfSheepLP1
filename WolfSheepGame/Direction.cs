using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    /// <summary>
    /// Enum that defines all available input directions.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// No direction.
        /// </summary>
        None,

        /// <summary>
        /// Go left.
        /// </summary>
        Left,

        /// <summary>
        /// Go right.
        /// </summary>
        Right,

        /// <summary>
        /// Go top and right.
        /// </summary>
        TopRight,

        /// <summary>
        /// Go top and left.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Go bottom and right.
        /// </summary>
        BottomRight,

        /// <summary>
        /// Go bottom and left.
        /// </summary>
        BottomLeft
    }
}
