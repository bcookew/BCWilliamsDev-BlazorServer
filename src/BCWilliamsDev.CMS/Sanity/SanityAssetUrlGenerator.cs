using Sanity.Linq;
using static System.Net.WebRequestMethods;

namespace BCWilliamsDev.CMS.Sanity
{
    public class SanityAssetUrlGenerator
    {
        private const string _imageAssetBaseUrl = "https://cdn.sanity.io/images/";
        private readonly SanityOptions _options;
        public SanityAssetUrlGenerator(SanityOptions options) 
        {
            _options = options;
        }

        public string ComposeImageAssetUrl(string imageName)
        {
            imageName = imageName.Remove(0,6);
            var indexOfHyphenToReplace = imageName.LastIndexOf("-");
            imageName = imageName.Insert(indexOfHyphenToReplace, ".");
            imageName = imageName.Remove(indexOfHyphenToReplace + 1, 1);
            return $"{_imageAssetBaseUrl}{_options.ProjectId}/{_options.Dataset}/{imageName}";
        }
    }
}
