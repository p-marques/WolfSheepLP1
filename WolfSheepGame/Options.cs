using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
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
        /// The name of the player controlling the wolf.
        /// </summary>
        public string WolfPlayerName { get; private set; }

        /// <summary>
        /// The name of the player controlling the sheep.
        /// </summary>
        public string SheepPlayerName { get; private set; }

        /// <summary>
        /// The result of the parsing.
        /// </summary>
        public OptionsParserResult ParserResult { get; set; }

        /// <summary>
        /// A message that describes what went wrong while handling arguments.
        /// </summary>
        public string ErrorMsg { get; private set; }

        /// <summary>
        /// The help messages for the available arguments.
        /// </summary>
        public static string[] HelpMessages { get; set; }

        /// <summary>
        /// A list of arguments that <see cref="Options"/> is prepared to handle.
        /// </summary>
        private static readonly IList<string> validOptions;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Options()
        {
            validOptions = new List<string>() { "-s", "-pw", "-ps" };

            HelpMessages = new string[3];
            HelpMessages[0] = "\t -s:  The size of the board. Must be between 8 and 16 and an even number. Default = 8.";
            HelpMessages[1] = "\t-pw:  The name of the player controlling the wolf. Must have length between 2 and 12. Default = Wolf Player.";
            HelpMessages[2] = "\t-ps:  The name of the player controlling the sheep. Must have length between 2 and 12. Default = Sheep Player.";
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

            // Dictionary with default values for the options
            IDictionary<string, string> optionsValues = new Dictionary<string, string>();

            // Default values
            optionsValues["-s"] = "8";
            optionsValues["-pw"] = "Wolf Player";
            optionsValues["-ps"] = "Sheep Player";

            // For clarity since default value is 0 (Ok)
            op.ParserResult = OptionsParserResult.Ok;

            // Options provided by the player
            List<string> parsedOptions = new List<string>();

            // Cycle going throw arguments, ignoring values
            for (int i = 0; i < args.Length; i += 2)
            {
                // Has the player asked for help? 
                // DEBUG: To avoid "dotnet run -h" issue, use "dotnet run -- -h"
                if (args[i] == "-h")
                {
                    op.ParserResult = OptionsParserResult.Help;
                    break;
                }

                // Is argument valid?
                if (validOptions.Contains(args[i]))
                {
                    // As this option already been validated before?
                    if (parsedOptions.Contains(args[i]))
                    {
                        op.SetErroState($"Error! Repeated argument: {args[i]}");
                        break;
                    }
                    else
                    {
                        // -s value bust be a unsigned integer
                        if (args[i] == "-s" && !uint.TryParse(args[i + 1], out uint value))
                        {
                            op.SetErroState($"Error! Value for argument \"{args[i]}\" must be a positive number");
                            break;
                        }

                        parsedOptions.Add(args[i]);

                        optionsValues[args[i]] = args[i + 1];
                    }
                }
                else
                {
                    op.SetErroState($"Error! Unknown argument: {args[i]}");
                    break;
                }
            }

            // If no errors were found parsing
            if (op.ParserResult == OptionsParserResult.Ok)
            {
                // ...assign the values...
                op.BoardSize = uint.Parse(optionsValues[validOptions[0]]);
                op.WolfPlayerName = optionsValues[validOptions[1]];
                op.SheepPlayerName = optionsValues[validOptions[2]];

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
            // BoardSize must be between 8 and 16 and an even number
            if (BoardSize < 8 || BoardSize > 16 || BoardSize % 2 != 0)
            {
                SetErroState("Error! Value for argument \"-s\" must be between 8 and 16 and an even number.");
                return;
            }

            // Player names must have length between 2 and 12
            if (WolfPlayerName.Length < 2 || WolfPlayerName.Length > 12)
            {
                SetErroState("Error! String for argument \"-pw\" must have a length between 2 and 12.");
                return;
            }

            // Player names must have length between 2 and 12
            if (SheepPlayerName.Length < 2 || SheepPlayerName.Length > 12)
            {
                SetErroState("Error! String for argument \"-ps\" must have a length between 2 and 12.");
                return;
            }
        }

        /// <summary>
        /// Internal method to set error state while adding a message.
        /// </summary>
        /// <param name="msg">Message that describes what went wrong.</param>
        private void SetErroState(string msg)
        {
            ParserResult = OptionsParserResult.Error;
            ErrorMsg = msg;
        }
    }
}
