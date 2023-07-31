using BCWilliamsDev.Application.Models;
using Sanity.Linq.CommonTypes;

namespace BCWilliamsDev.CMS.Sanity
{
    public class ProjectCard : SanityDocument
    {
        public ProjectCard() : base() { }

        public required string Name { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required SanitySlug Slug { get; init; }
        public required SanityImage Image { get; init; }
        public required string[] TechStack { get; init; }
        public required string? GitHub { get; init; }
        public required string? Project { get; init; }
        public string ImageUrl { get; set; } = string.Empty;

        public ProjectCardModel ConvertToProjectCardViewModel()
        {
            return new ProjectCardModel(Name, Title, Description, TechStack, ImageUrl, GitHub, Project);
        }
    }
}
