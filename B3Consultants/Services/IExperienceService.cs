using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;

namespace B3Consultants.Services
{
    public interface IExperienceService
    {
        IEnumerable<Experience> GetExperiences();
        void AddExperience(AddExperienceDTO ExperienceDTO);
        void ModifyExperience(AddExperienceDTO ExperienceDTO, int id);
        void DeleteExperience(int id);
    }
}
