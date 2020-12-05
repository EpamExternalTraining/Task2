using System;

namespace DataLib.Exceptions
{

    /// <summary>
    /// Class which represents different name exception
    /// </summary>
    public class DifferentNameException : Exception
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public DifferentNameException() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public DifferentNameException(string message) : base(message) { }

        #endregion

    }

}
