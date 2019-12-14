using Autofac;
using JosephusProblem.CrossCuttingConcernCollection.Base;
using JosephusProblem.CrossCuttingConcernCollection.ExceptionHandling;
using JosephusProblem.CrossCuttingConcernCollection.Logging;
using JosephusProblem.CrossCuttingConcernCollection.Monitoring;
using JosephusProblem.DependencyResolution;
using JosephusProblem.Solution;
using JosephusProblem.Solution.Base;
using System;
using System.Threading;

namespace JosephusProblem
{
    internal class Program
    {
        private static IMonitorable _monitor;
        private static IJosephusProblem _handShake; 
         
        static void Main(string[] args)
        {
            #region Run Only One Instance 

            bool isAppInstanceShut;

            var mutex = new Mutex(true, "CustomerTracking", out isAppInstanceShut);

            if (!isAppInstanceShut)
            {
                return;
            }

            #endregion

            #region IoC registration

            Injector.Configure(() =>
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<ApplicationLogger>().As<ILog>();
                builder.RegisterType<ConsoleMonitor>().As<IMonitorable>();
                builder.RegisterType<AppException>().As<IApplicationException>();
                builder.RegisterType<Validation>().As<IValidation>();
                builder.RegisterType<HandShake>().As<IJosephusProblem>();

                return builder.Build();
            });

            #endregion

            _monitor = Injector.Resolve<IMonitorable>();
            _handShake = Injector.Resolve<IJosephusProblem>();

            _monitor.Display("--Welcome to Josephus Problem Solution Program--");
            _monitor.Display(DateTime.Now.ToLongDateString());
            _monitor.Display("Problem : Even number of people are standing along on a circle which can be represented as '2n' people.");
            _monitor.Display("----------The number of ways is needed in which every person simultaneously shakes hands with one other person such that no arms crossed");
            _monitor.Display("----------The number of ways can be represented as 'k' and 'n' can be [0,1000]");
            _monitor.Display("----------Additionally, if 'k' is also can be represented as J(n) then J(0)=J(1)=1");
            _monitor.Display("Please enter n value and pay attention that it means 2n people exists on the circle : ");

            while (true)
            {
                var input = Console.ReadLine();
                var result = _handShake.GetResult(input);
                _monitor.Display("Please enter n value and pay attention that it means 2n people exists on the circle : ");
            }
        }  
    }
}
