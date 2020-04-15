using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGame
{
    /// <summary>
    /// Struct to handle arguments inputed by the user through the command line.
    /// </summary>
    public struct Options
    {
        /// <summary>
        /// A single positive number representing the size of the game board.
        /// </summary>
        /// <value>Number of squares from left to right or top to bottom.</value>
        public uint BoardSize { get; private set; }

        /// <summary>
        /// A flag that indicates if something went wrong while handling arguments.
        /// </summary>
        public bool Error { get; private set; }

        /// <summary>
        /// A message that describes what went wrong while handling arguments.
        /// </summary>
        public string ErrorMsg { get; private set; }

        /// <summary>
        /// A list of arguments that <see cref="Options"/> is prepared to handle.
        /// </summary>
        private static readonly IList<string> validOptions;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Options()
        {
            validOptions = new List<string>() { "-s" };
        }


        /// <summary>
        /// Parses arguments, creates a <see cref="Options"/> object from
        /// the parsed data and returns the object.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>A <see cref="Options"/> object containing the game options.</returns>
        public static Options ParseOptionsFromArgs(string[] args)
        {
            Options op = new Options();

            // Dictionary with all options already parsed
            IDictionary<string, uint> parsedOptions = new Dictionary<string, uint>();

            // If no argument and value pair given...
            if (args.Length < 2)
            {
                /// ...set BoardSize to default value and return object
                op.BoardSize = 8;
                return op;
            }

            // Cycle going throw arguments, ignoring values
            for (int i = 0; i < args.Length; i += 2)
            {
                // Is argument valid?
                if (validOptions.Contains(args[i]))
                {
                    // As this option already been validated before?
                    if (parsedOptions.ContainsKey(args[i]))
                    {
                        op.SetErroState($"Error! Repeated argument: {args[i]}");
                        break;
                    }
                    else
                    {
                        // Is value a valid uint?
                        if (uint.TryParse(args[i + 1], out uint value))
                        {
                            parsedOptions[args[i]] = value;
                        }
                        else
                        {
                            op.SetErroState($"Error! Value for argument \"{args[i]}\" must be a positive number");
                            break;
                        }
                    }
                }
                else
                {
                    op.SetErroState($"Error! Unknown argument: {args[i]}");
                    break;
                }
            }

            // If no errors were found parsing...
            if (!op.Error)
            {
                // ...assign the values...
                op.BoardSize = parsedOptions[validOptions[0]];

                // ...and check if they're valid.
                op.ValidateOptionsValues();
            }

            return op;
        }

        /// <summary>
        /// Validates values given by the user.
        /// If not valid calls <see cref="SetErroState(string)"/>.
        /// </summary>
        private void ValidateOptionsValues()
        {
            // BoardSize must be between 8 and 16 and an even number.
            if (BoardSize < 8 || BoardSize > 16 || BoardSize % 2 != 0)
            {
                SetErroState("Error! Value for argument \"-s\" must be between 8 and 16 and an even number.");
            }
        }

        /// <summary>
        /// Internal method to set error state while adding a message.
        /// </summary>
        /// <param name="msg">Message that describes what went wrong.</param>
        private void SetErroState(string msg)
        {
            Error = true;
            ErrorMsg = msg;
        }
    }
}
