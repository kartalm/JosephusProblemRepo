using JosephusProblem.CrossCuttingConcernCollection.Base;
using JosephusProblem.CrossCuttingConcernCollection.Helper;
using JosephusProblem.DependencyResolution;
using System;
using System.Globalization;

namespace JosephusProblem.CrossCuttingConcernCollection.ExceptionHandling
{
    [Serializable]
    public class AppException : Exception, IApplicationException
    { 
        private readonly ILog _logger;

        public AppException()
        {
            _logger = Injector.Resolve<ILog>();
        }

        public void LogException(string message)
        {
            _logger.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + " Error message : " + message, LogType.Error);
        }

        public void LogException(string message, Exception inner)
        {
            _logger.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + " Error message : " + message + " InnerException : " + inner.InnerException + " StackTrace : " + inner.StackTrace + " Message : " + inner.Message + " Data : " + inner.Data + " HResult : " + inner.HResult + " Source : " + inner.Source, LogType.Error);
        }

    }
}
