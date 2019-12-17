using System;

namespace Network_Analyzer_Backend.Models.Exceptions
{
    /// <summary>
    /// Model for Bad Request exception
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
