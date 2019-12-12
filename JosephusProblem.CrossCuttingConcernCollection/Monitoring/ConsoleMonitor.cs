using JosephusProblem.CrossCuttingConcernCollection.Base;
using JosephusProblem.CrossCuttingConcernCollection.Helper;
using System;

namespace JosephusProblem.CrossCuttingConcernCollection.Monitoring
{
    public class ConsoleMonitor : IMonitorable
    {
        public void Display(string data)
        {
            if (data.IsNotNullOrEmpty())
            {
                Console.WriteLine(data);
            }
        }
    }

}
