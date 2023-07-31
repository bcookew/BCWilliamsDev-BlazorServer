using BCWilliamsDev.CMS.Interfaces;
using BCWilliamsDev.CMS.Sanity;
using Microsoft.Extensions.DependencyInjection;

namespace BCWilliamsDev.Abstraction
{
    public static class CmsServiceCollection
    {
        public static IServiceCollection AddCmsServices(this IServiceCollection services)
        {
            services.AddTransient<ICmsCaller, SanityClient>();

            return services;
        }
    }
}