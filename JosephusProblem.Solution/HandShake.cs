using JosephusProblem.CrossCuttingConcernCollection.Base;
using JosephusProblem.CrossCuttingConcernCollection.Helper;
using JosephusProblem.DependencyResolution;
using JosephusProblem.Solution.Base;
using System;

namespace JosephusProblem.Solution
{
    public class HandShake : IJosephusProblem
    {
        private readonly IMonitorable _monitor;
        private readonly ILog _logger;

        public HandShake()
        {
            _logger = Injector.Resolve<ILog>();
            _monitor = Injector.Resolve<IMonitorable>();
        }

        /// <summary>
        /// Handshake number can be found via factorial
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetResult(params string[] arguments)
        {
            var validationResult = new Validation();
            var response = validationResult.Check(arguments[0]);
            var handShakeNumber = 1;

            if (response.IsSucceed)
            {
                var n = Convert.ToInt32(arguments[0]);

                if (!(n == 1 || n == 0))
                {
                    handShakeNumber = (2 * n * (2 * n - 1)) / 2;  
                }
                _monitor.Display("Result is " + handShakeNumber);
            }
            else
            {
                _monitor.Display(response.Message);
                _logger.Log("Validation result is " + (response.IsSucceed ? "successful" : "unsuccessful") + ", " + response.Message, LogType.Error);
            }

            _logger.Log("Result is " + handShakeNumber, LogType.Info);

            return handShakeNumber;

        }
    }
}
