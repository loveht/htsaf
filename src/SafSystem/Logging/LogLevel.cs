using System;

namespace Ataoge.Logging
{
    /// <summary>
    /// The 7 possible logging levels
    /// </summary>
    /// <author>Gilles Bayon</author>
    [Flags]
    public enum LogLevel
    {
        /// <summary>
        /// All logging levels
        /// </summary>
        All = 0,
        /// <summary>
        /// A trace logging level
        /// </summary>
        Trace = 1,
        /// <summary>
        /// A debug logging level
        /// </summary>
        Debug = 2,
        /// <summary>
        /// A info logging level
        /// </summary>
        Info = 4,
        /// <summary>
        /// A warn logging level
        /// </summary>
        Warn = 8,
        /// <summary>
        /// An error logging level
        /// </summary>
        Error = 16,
        /// <summary>
        /// A fatal logging level
        /// </summary>
        Fatal = 32,
        /// <summary>
        /// Do not log anything.
        /// </summary>
        Off = 64,
    }
}
