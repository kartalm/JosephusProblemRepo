using JosephusProblem.Core.Base;
using JosephusProblem.CrossCuttingConcernCollection.Base;
using JosephusProblem.CrossCuttingConcernCollection.Helper;
using JosephusProblem.DependencyResolution;
using JosephusProblem.Solution.Base;
using System;
using System.Diagnostics;
using System.Numerics;

namespace JosephusProblem.Solution
{
    public class HandShake : IJosephusProblem
    {
        private readonly IMonitorable _monitor;
        private readonly ILog _logger;
        private readonly IValidation _validation;

        public HandShake()
        {
            _logger = Injector.Resolve<ILog>();
            _monitor = Injector.Resolve<IMonitorable>();
            _validation = Injector.Resolve<IValidation>();
        }

        /// <summary>
        /// Formula 2n!/((n+1)!*n!)
        /// </summary>
        /// <param n=input></param>
        /// <returns></returns>
        public ServiceResponse<BigInteger> GetResult(params string[] arguments)
        {
            var watch = new Stopwatch(); 
            watch.Start();
              
            var response = new ServiceResponse<BigInteger>();
            var validationResult = _validation.Check(arguments[0]);
            BigInteger handShakeNumber = 1;

            if (validationResult.IsSucceed)
            {
                int input = Convert.ToInt32(arguments[0]);

                try
                {
                    handShakeNumber = GetHandshakeNumber(input);
                    _monitor.Display("Result is " + handShakeNumber);
                    _logger.Log("Result is " + handShakeNumber, LogType.Info);
                    response.Data = handShakeNumber;
                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                    response.Message = "Exception occured. Details : " + ex;
                    _logger.Log(response.Message, LogType.Error);
                    _monitor.Display(response.Message);
                }
            }
            else
            {
                var message = "Validation result is unsuccessful. " + validationResult.Message;
                _monitor.Display(message);
                _logger.Log(message, LogType.Error);
            }

            watch.Stop();
            _monitor.Display("Calculation of handshakes totally took " + watch.Elapsed.TotalSeconds.ToString() + " seconds.");

            return response;

        }

        private BigInteger GetHandshakeNumber(int input)
        { 
            if (input == 1 || input == 0)
            {
                return 1;
            } 

            BigInteger division = GetFactorial(new BigInteger(2 * input));
            BigInteger dividedBy1 = GetFactorial(new BigInteger(1 + input));
            BigInteger dividedBy2 = GetFactorial(new BigInteger(input));
            
            BigInteger handshakeCount = division / (dividedBy1 * dividedBy2);//Catalan Equation Formula 

            return handshakeCount;

        }

        private BigInteger GetFactorial(BigInteger number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);

        }

    }
}
