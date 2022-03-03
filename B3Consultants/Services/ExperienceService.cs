using B3Consultants.DB;
using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using B3Consultants.Exceptions;

namespace B3Consultants.Services
{
    public class ExperienceService : IExperienceService
    {
        private ConsultantDBContext _dBContext;
        private IMapper _mapper;
        private ILogger _logger;

        public ExperienceService(ConsultantDBContext dBContext, IMapper mapper, ILogger<ExperienceService> logger)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<Experience> GetExperiences()
        {
            var experiences = _dBContext.Experiences.ToList();
            return experiences;
        }
        public void AddExperience(AddExperienceDTO ExperienceDTO)
        {
            var experience = _mapper.Map<Experience>(ExperienceDTO);
            _dBContext.Experiences.Add(experience);
            _dBContext.SaveChanges();
        }
        public void ModifyExperience(AddExperienceDTO ExperienceDTO, int id)
        {
            var experience = _dBContext.Experiences.FirstOrDefault(x => x.Id == id);
            if (experience == null)
            {
                throw new NotFoundException("Experience not found");
            }
            var experienceModified = _mapper.Map<Experience>(ExperienceDTO);
            experience.ExperienceLevel = experienceModified.ExperienceLevel;

            _dBContext.Experiences.Update(experience);
            _dBContext.SaveChanges();
        }
        public void DeleteExperience(int id)
        {

            var experience = _dBContext.Experiences.FirstOrDefault(x => x.Id == id);

            if (experience == null)
            {
                throw new NotFoundException("Experience not found");
            }

            _dBContext.Experiences.Remove(experience);
            _dBContext.SaveChanges();
        }
    }
}
