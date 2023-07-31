using BCWilliamsDev.Application.Models;
using BCWilliamsDev.CMS.Sanity;

namespace BCWilliamsDev.CMS.Interfaces
{
    public interface ICmsCaller
    {
        public Task<ProjectCardModel[]> GetProjectCardsAsync();

    }
}
