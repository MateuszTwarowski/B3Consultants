using B3Consultants.Entities;

namespace B3ConsultantsUI.Services
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> GetExperiences();
    }
}
