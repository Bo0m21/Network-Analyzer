using System;
using Network_Analyzer_WinForms.Services;

namespace Network_Analyzer_WinForms.Extensions
{
    /// <summary>
    ///     Extension for exception
    /// </summary>
    public static class ExceptionExtension
    {
        public static string GetExceptionMessage(this Exception exception)
        {
            if (exception.GetType() == typeof(AggregateException))
            {
                if (exception.InnerException != null && exception.InnerException.GetType() == typeof(ApiException))
                {
                    return exception.InnerException.Message;
                }
            }
            else if (exception.GetType() == typeof(ApiException))
            {
                return exception.Message;
            }

            return "";
        }
    }
}