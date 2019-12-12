using JosephusProblem.CrossCuttingConcernCollection.ExceptionHandling;
using System;

namespace JosephusProblem.Core.Base
{
    public class ServiceResponse
    {
        public bool IsSucceed
        {
            get
            {
                return Exception == null;
            }
        }

        public AppException Exception { get; set; }

        public string Message { get; set; }

    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
