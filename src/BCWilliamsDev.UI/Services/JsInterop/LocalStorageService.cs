using BCWilliamsDev.UI.Services.JsInterop.Interfaces;
using Microsoft.JSInterop;

namespace BCWilliamsDev.UI.Services.JsInterop
{
    public class LocalStorageService : ILocalStorageService, IAsyncDisposable
    {
        private Lazy<IJSObjectReference> _module = new();
        private readonly IJSRuntime _js;
        private readonly ILogger<LocalStorageService> _logger;

        public LocalStorageService(IJSRuntime js, ILogger<LocalStorageService> logger)
        {
            _js = js;
            _logger = logger;
        }

        public async Task SetLocalStorageAsync<T>(string key, T value)
        {
            await GetModuleAsync();
            try
            {
                _logger.LogInformation($"Setting Local Storage: {key}: {value}");
                bool success = await _module.Value.InvokeAsync<bool>("set", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        public async Task<string> GetLocalStorageAsync(string key)
        {
            await GetModuleAsync();
            try
            {
                _logger.LogInformation($"Getting Local Storage: {key}");
                var result = await _module.Value.InvokeAsync<string>("get", key);
                result ??= string.Empty;
                _logger.LogInformation($"Result: {result}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return string.Empty;
            }
        }



        private async Task GetModuleAsync()
        {
            if (!_module.IsValueCreated)
            {
                _module = new(
                    await _js.InvokeAsync<IJSObjectReference>("import", "./js/LocalStorage.js")
                );
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_module.IsValueCreated) await _module.Value.DisposeAsync();
        }
    }
}
