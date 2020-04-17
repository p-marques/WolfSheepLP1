using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    /// <summary>
    /// Abstract class representing a Player.
    /// </summary>
    public abstract class Player
    {
        /// <summary>
        /// A self-maintained counter of moves performed.
        /// </summary>
        public int RoundCounter { get; protected set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        protected Player()
        {
            RoundCounter = 0;
        }
    }
}
