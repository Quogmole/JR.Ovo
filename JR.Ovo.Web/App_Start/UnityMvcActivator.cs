using System.Linq;
using System.Web.Mvc;
using JR.Ovo.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Unity.AspNet.Mvc;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(UnityMvcActivator), nameof(UnityMvcActivator.Start))]
[assembly: ApplicationShutdownMethod(typeof(UnityMvcActivator), nameof(UnityMvcActivator.Shutdown))]

namespace JR.Ovo.Web
{
    /// <summary>
    ///     Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        ///     Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        ///     Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}