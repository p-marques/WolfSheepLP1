using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1.UI
{
    /// <summary>
    /// The state of the player input.
    /// </summary>
    public enum PlayerInputState
    {
        /// <summary>
        /// Player can move left and right.
        /// </summary>
        LeftAndRight,

        /// <summary>
        /// Player can move to:
        /// <list type="bullet">
        /// <item>Top left.</item>
        /// <item>Top right.</item>
        /// <item>Bottom left.</item>
        /// <item>Bottom right.</item>
        /// </list>
        /// </summary>
        WolfPlayer,

        /// <summary>
        /// Player can move to:
        /// <list type="bullet">
        /// <item>Top left.</item>
        /// <item>Top right.</item>
        /// </list>
        /// </summary>
        SheepPlayer
    }
}
