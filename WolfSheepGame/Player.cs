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
        public int RoundCounter { get; private set; }

        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// An array with all the allowed move directions.
        /// </summary>
        public Direction[] AllowedMoveDirections { get; protected set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        protected Player(string name)
        {
            RoundCounter = 0;
            Name = name;
        }

        /// <summary>
        /// Check if the player is allowed to move in the desired direction.
        /// </summary>
        /// <param name="direction">Desired direction to move.</param>
        /// <returns>A boolean value representing if the player is allowed to make such move.</returns>
        public bool GetIsMoveAllowed(Direction direction)
        {
            return Array.Exists(AllowedMoveDirections, x => x == direction);
        }

        /// <summary>
        /// Adds 1 to the player's round counter.
        /// </summary>
        public void UpdateRoundCounter()
        {
            RoundCounter++;
        }
    }
}
