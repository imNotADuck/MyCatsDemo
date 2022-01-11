using System;
using Unity;

namespace MyCatsDemo.Configuration
{
    public static class IoCContainer
    {
        private static UnityContainer _container = new UnityContainer().EnableDiagnostic();

        public static T Resolve<T>()
            where T : class
        {
            return Resolve<T>(null);

        }

        public static T Resolve<T>(params object[] parameters)
            where T : class
        {
            var instance = _container?.Resolve<T>((Unity.Resolution.ResolverOverride[])parameters);

            return instance;
        }

        public static void RegisterType<T, TF>()
            where TF : class, T
        {
            _container.RegisterType<T, TF>();
        }

        public static void RegisterSingleton<T, TF>()
            where TF : class, T
        {
            _container.RegisterSingleton<T, TF>();
        }
    }
}
