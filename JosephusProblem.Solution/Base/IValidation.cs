using JosephusProblem.Core.Base;

namespace JosephusProblem.Solution.Base
{
    public interface IValidation
    {
        ServiceResponse Check(string value);

    }
}
