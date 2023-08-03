using BCWilliamsDev.Application.Interfaces;
using BCWilliamsDev.Application.Models;
using Microsoft.Extensions.Logging;
using Sanity.Linq;


namespace BCWilliamsDev.CMS.Sanity
{
    public class SanityClient : ICmsCaller
    {
        private readonly SanityOptions options = new SanityOptions
        {
            ProjectId = "sktha2v2",
            Dataset = "production",
            Token = string.Empty,
            UseCdn = false,
            ApiVersion = "v1"
        };

        private readonly SanityDataContext _sanity;
        private readonly ILogger<SanityClient> _logger;
        private readonly SanityAssetUrlGenerator _assetUrlGenerator;
        public SanityClient(ILogger<SanityClient> logger)
        {
            _sanity = new SanityDataContext(options);
            _logger = logger;
            _assetUrlGenerator = new SanityAssetUrlGenerator(options);
        }

        public async Task<ProjectCardModel[]> GetProjectCardsAsync()
        {
            List<ProjectCardModel> results = new List<ProjectCardModel>();
            var projectsContext = _sanity.DocumentSet<ProjectCard>();
            var projects = await projectsContext.ToArrayAsync();
            foreach (var project in projects)
            {
                project.ImageUrl = _assetUrlGenerator.ComposeImageAssetUrl(project.Image.Asset.Ref);
                _logger.LogInformation(
                    $"\n" +
                    $"Name: {project.Name}\n" +
                    $"Description {project.Description}\n" +
                    $"Image: {project.Image.Asset.Ref}\n" +
                    $"Image Url: {project.ImageUrl}\n" +
                    $"Tech Stack: {project.TechStack.Length}\n"
                    );
                results.Add(project.ConvertToProjectCardViewModel());
            }
            return results.ToArray();
        }
    }
}
