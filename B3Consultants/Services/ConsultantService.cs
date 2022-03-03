using B3Consultants.DB;
using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using B3Consultants.Exceptions;

namespace B3Consultants.Services
{
    public class ConsultantService : IConsultantService
    {
        private ConsultantDBContext _dBContext;
        private IMapper _mapper;
        private ILogger _logger;
        public ConsultantService (ConsultantDBContext dBContext, IMapper mapper, ILogger<ConsultantService> logger)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<ConsultantDTO> GetConsultants()
        {
            var consultants = _dBContext
                .Consultants
                .Include(r => r.Role)
                .Include(r => r.Experience)
                .Include(r => r.Availability)
                .ToList();

            var consultantsDTOs = _mapper.Map<List<ConsultantDTO>>(consultants);
            return consultantsDTOs;
        }

        public void AddConsultant(AddConsultantDTO consultantDTO)
        {
            var consultant = _mapper.Map<Consultant>(consultantDTO);
            _dBContext.Consultants.Add(consultant);
            _dBContext.SaveChanges();
        }

        public void ModifyConsultant(AddConsultantDTO consultantDTO, int id)
        {
            var consultant = _dBContext.Consultants.FirstOrDefault(x => x.Id == id);
            if (consultant == null)
            {
                throw new NotFoundException("Consultant not found");
            }
            var consultantModified = _mapper.Map<Consultant>(consultantDTO);

            consultant.FirstName = consultantModified.FirstName;
            consultant.LastName = consultantModified.LastName;
            consultant.RoleId = consultantModified.RoleId;
            consultant.ExperienceId = consultantModified.ExperienceId;
            consultant.HourlyRatePlnNet = consultantModified.HourlyRatePlnNet;
            consultant.Location = consultantModified.Location;
            consultant.AvailabilityId = consultantModified.AvailabilityId;
            consultant.Description = consultantModified.Description;
            consultant.ProfileSource = consultantModified.ProfileSource;

            _dBContext.Consultants.Update(consultant);
            _dBContext.SaveChanges();
        }
        public void DeleteConsultant(int id)
        {
            var consultant = _dBContext.Consultants.FirstOrDefault(x => x.Id == id);

            if (consultant == null)
            {
                throw new NotFoundException("Consultant not found");
            }

            _dBContext.Consultants.Remove(consultant);
            _dBContext.SaveChanges();
        }
    }
}
