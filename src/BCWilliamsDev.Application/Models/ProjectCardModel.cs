namespace BCWilliamsDev.Application.Models
{
    public class ProjectCardModel
    {
        public ProjectCardModel(string name, string title, string description, string[] techStack, string imageUrl, string? gitHubUrl, string? websiteUrl)
        {
            Name = name;
            Title = title; 
            Description = description;
            TechStack = techStack;
            ImageUrl = imageUrl;
            GitHubUrl = gitHubUrl;
            WebsiteUrl = websiteUrl;
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] TechStack { get; set; }
        public string ImageUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? WebsiteUrl { get; set; }
    }
}
