using Autofac;
using System;

namespace JosephusProblem.DependencyResolution
{
    public static class Injector
    {
        public static IContainer Container;

        public static IContainer Configure(Func<IContainer> func)
        {
            Container = func();
            return func();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
