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
        public static void TreatmentException(this ILogger logger, Exception exception, out int code, out string message)
        {
            if (exception.GetType() == typeof(BadRequestException))
            {
                code = (int)HttpStatusCode.BadRequest;
                message = exception.Message;
            }
           



            switch (exception)
            {
                case BadRequestException _:
                    code = (int)HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                default:
                    code = 500;
                    message = "HI!";
                    break;
            }
        }
    }
}
