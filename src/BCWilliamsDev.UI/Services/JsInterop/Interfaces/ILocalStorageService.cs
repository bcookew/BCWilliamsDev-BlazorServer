namespace BCWilliamsDev.UI.Services.JsInterop.Interfaces
{
    public interface ILocalStorageService
    {
        Task<string> GetLocalStorageAsync(string key);
        Task SetLocalStorageAsync<T>(string key, T value);
    }
}
