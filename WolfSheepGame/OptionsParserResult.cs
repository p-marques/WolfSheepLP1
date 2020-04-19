using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
    /// <summary>
    /// The result of the options parsing.
    /// </summary>
    public enum OptionsParserResult
    {
        /// <summary>
        /// Everything OK.
        /// </summary>
        Ok,
        /// <summary>
        /// Something wrong happened.
        /// </summary>
        Error,
        /// <summary>
        /// Player passed the -h argument.
        /// </summary>
        Help
    }
}
