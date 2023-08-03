using BCWilliamsDev.UI.Services.JsInterop;
using BCWilliamsDev.UI.Services.JsInterop.Interfaces;
using BCWilliamsDev.UI.Services.UI;
using BCWilliamsDev.UI.Services.UI.Interfaces;
using MudBlazor.Services;

namespace BCWilliamsDev.UI.Services.ServiceCollections
{
    public static class UIServiceCollection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<IContactFormService, ContactFormService>();

            services.AddMudServices();

            return services;
        }
    }
}