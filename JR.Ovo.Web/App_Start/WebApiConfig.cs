using System.Web.Http;
using JR.Ovo.Services;
using Unity;
using Unity.Lifetime;

namespace JR.Ovo.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );

            var container = new UnityContainer();
            container.RegisterType<IApiService, ApiService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}