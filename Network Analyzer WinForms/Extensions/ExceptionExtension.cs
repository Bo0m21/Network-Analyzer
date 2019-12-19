using Network_Analyzer_WinForms.Services;
using System;

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
                    return exception.InnerException.Message.ToString();
                }
            }
            else if (exception.GetType() == typeof(ApiException))
            {
                return exception.Message.ToString();
            }

            return "";
        }
    }
}
