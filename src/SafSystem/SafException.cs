using System;

namespace Ataoge
{
    public class SafException: Exception
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <c>ApworksException</c> class.
        /// </summary>
        public SafException() : base() { }
        /// <summary>
        /// Initializes a new instance of the <c>ApworksException</c> class with the specified
        /// error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SafException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <c>ApworksException</c> class with the specified
        /// error message and the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The inner exception that is the cause of this exception.</param>
        public SafException(string message, Exception innerException) : base(message, innerException) { }
        /// <summary>
        /// Initializes a new instance of the <c>ApworksException</c> class with the specified
        /// string formatter and the arguments that are used for formatting the message which
        /// describes the error.
        /// </summary>
        /// <param name="format">The string formatter which is used for formatting the error message.</param>
        /// <param name="args">The arguments that are used by the formatter to build the error message.</param>
        public SafException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}