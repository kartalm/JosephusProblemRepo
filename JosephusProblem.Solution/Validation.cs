using JosephusProblem.Core.Base;
using JosephusProblem.CrossCuttingConcernCollection.ExceptionHandling;
using JosephusProblem.CrossCuttingConcernCollection.Helper;
using JosephusProblem.Solution.Base;
using System;
using System.Linq;

namespace JosephusProblem.Solution
{
    public class Validation : IValidation
    {
        public ServiceResponse Check(string value)
        {
            var response = new ServiceResponse();
            int number;
            var exception = new AppException();

            if (value.IsNullOrEmpty())
            {
                exception.LogException("Value is empty or null.");
                response.Message = "You have to enter a number!";
                response.Exception = exception;
            }
            else if (!value.All(char.IsNumber))
            {
                exception.LogException("Value is not a number. Value : " + value);
                response.Message = "Please enter a number!";
                response.Exception = exception;
            }
            else if (!int.TryParse(value, out number))
            {
                exception.LogException("Unable to convert to number. Value : " + value);
                response.Message = "Unable to convert to number. Please enter a number!";
                response.Exception = exception;
            }
            else if (Convert.ToInt32(value) > 1000 || Convert.ToInt32(value) <= 0)
            {
                exception.LogException("Value is not between 0 and 1000. Value : " + value);
                response.Message = "Please enter a number between 0 and 1000!";
                response.Exception = exception;
            }
            
            return response;

        }
 
    }
}
