using Network_Analyzer_WinForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Analyzer_WinForms.Extensions
{
    /// <summary>
    ///     Extension for exception
    /// </summary>
    public static class ExceptionExtension
    {
        public static string TreatmentException(this Exception exception)
        {
            if (exception.GetType() == typeof(AggregateException) && exception.InnerException != null)
            {
                if (exception.InnerException.GetType() == typeof(ApiException))
                {
                    var sadasd = exception.InnerException.ToString();
                }
            }
            else    // Logging other exceptions
            {
            }

            return "";
        }
    }
}
