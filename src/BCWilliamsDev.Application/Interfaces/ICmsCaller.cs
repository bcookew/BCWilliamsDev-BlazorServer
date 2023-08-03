using BCWilliamsDev.Application.Models;

namespace BCWilliamsDev.Application.Interfaces
{
    public interface ICmsCaller
    {
        public Task<ProjectCardModel[]> GetProjectCardsAsync();

    }
}
