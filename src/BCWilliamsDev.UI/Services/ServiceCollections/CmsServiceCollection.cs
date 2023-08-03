using BCWilliamsDev.Application.Interfaces;
using BCWilliamsDev.CMS.Sanity;

namespace BCWilliamsDev.UI.Services.ServiceCollections
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