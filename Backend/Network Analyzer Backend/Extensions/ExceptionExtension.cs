using Microsoft.Extensions.Logging;
using Network_Analyzer_Backend.Models.Exceptions;
using System;
using System.Net;

namespace Network_Analyzer_Backend.Extensions
{
    /// <summary>
    /// Extension for exception
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Method for logging other exceptions
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public static void TreatmentException(this ILogger logger, Exception exception, out int code, out string message)
        {
            if (exception.GetType() == typeof(BadRequestException))
            {
                code = (int)HttpStatusCode.BadRequest;
                message = exception.Message;
            }
            else    // Logging other exceptions
            {
                code = (int)HttpStatusCode.InternalServerError;
                message = "Internal Server Error";
                logger.LogError(exception, exception.Message);
            }
        }
    }
}
