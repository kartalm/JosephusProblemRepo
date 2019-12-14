using JosephusProblem.Core.Base;
using System.Numerics;

namespace JosephusProblem.Solution.Base
{
    public interface IJosephusProblem
    {
        ServiceResponse<BigInteger> GetResult(params string[] arguments);

    }
}
