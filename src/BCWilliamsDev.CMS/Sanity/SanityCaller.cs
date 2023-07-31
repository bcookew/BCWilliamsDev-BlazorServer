using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BCWilliamsDev.CMS.Sanity
{
    public class SanityCaller
    {
        private string _projectId;
        private string _dataset;
        private string _apiUrl;
        private string _composedApiAddress;
        private readonly HttpClient _httpClient;
        private readonly ILogger<SanityCaller> _logger;

        public SanityCaller(ILogger<SanityCaller> logger)
        {
            _logger = logger;
            GetEnvironmentVariables();
            if(
                _projectId is null ||
                _dataset is null ||
                _apiUrl is null
            ) throw new Exception();
            _composedApiAddress = ComposeApiAddress();
            _httpClient = new() { BaseAddress = GetUriFromString() };
        }

        public async Task GetSanityDocumentsByTypeAsync(string type)
        {
            string query = $"*[_type == \"{type}\"]";
            string apiQueryAddress = ComposeUriWithQueryString(query);
            var res = await _httpClient.GetStringAsync(apiQueryAddress);
            JsonDocument jDoc = JsonDocument.Parse(res);

            _logger.LogInformation(JsonSerializer.Serialize(jDoc, new JsonSerializerOptions { WriteIndented = true }));
        }

        private string ComposeApiAddress()
        {
            return $"https://{_projectId}.{_apiUrl}{_dataset}";
        }

        private Uri GetUriFromString() => new Uri(_composedApiAddress);

        private string ComposeUriWithQueryString(string query) => $"{_composedApiAddress}?query={query}";

        private void GetEnvironmentVariables()
        {
            try
            {
                _projectId = Environment.GetEnvironmentVariable("SANITY_PROJECT_ID");
                _apiUrl = Environment.GetEnvironmentVariable("SANITY_API_URL");
                _dataset = Environment.GetEnvironmentVariable("SANITY_PROJECT_DATASET");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
