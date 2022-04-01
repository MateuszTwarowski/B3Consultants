using B3Consultants.DB;
using B3Consultants.Entities;
using B3Consultants.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using B3Consultants.Exceptions;
using System.Linq.Expressions;

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

        public PagedResult<ConsultantDTO> GetConsultants(ConsultantQuery? query)
        {
            var baseConsultants = _dBContext
            .Consultants
            .Include(r => r.Role)
            .Include(r => r.Experience)
            .Include(r => r.Availability)
            .Where(r => r.FirstName.ToLower().Contains(query.SearchPhrase.ToLower())
            || r.LastName.ToLower().Contains(query.SearchPhrase.ToLower())
            || r.Role.RoleTitle.ToLower().Contains(query.SearchPhrase.ToLower())
            || r.Location.ToLower().Contains(query.SearchPhrase.ToLower())
            || r.Description.ToLower().Contains(query.SearchPhrase.ToLower())
            || r.Experience.ExperienceLevel.ToLower().Contains(query.SearchPhrase.ToLower())
            );

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Consultant, object>>>
                {
                    { nameof(Consultant.Role), r => r.Role },
                    { nameof(Consultant.Experience),  r => r.Experience},
                    { nameof(Consultant.Availability), r => r.Availability},
                    { nameof(Consultant.HourlyRatePlnNet), r => r.HourlyRatePlnNet},
                    { nameof(Consultant.Location), r => r.Location},
                };

                var selectedColumn = columnsSelector[query.SortBy];

                baseConsultants = query.SortDirection == SortDirections.ASC
                    ? baseConsultants.OrderBy(selectedColumn)
                    : baseConsultants.OrderByDescending(selectedColumn);

            }

            var pagedConsultants = baseConsultants
            .Skip(query.PageSize*(query.PageNumber - 1))
            .Take(query.PageSize)
            .ToList();

            var totalConsultantsNumber = baseConsultants.Count();

            var consultantsDTOs = _mapper.Map<List<ConsultantDTO>>(pagedConsultants);

            var result = new PagedResult<ConsultantDTO>(consultantsDTOs, totalConsultantsNumber, query.PageSize, query.PageNumber);

            return result;
        }

        public ConsultantDTO GetConsultantsById(int id)
        {
            var consultant = _dBContext
            .Consultants
            .Include(r => r.Role)
            .Include(r => r.Experience)
            .Include(r => r.Availability)
            .FirstOrDefault(consultant => consultant.Id == id);

            var consultantDTO = _mapper.Map<ConsultantDTO>(consultant);

            return consultantDTO;
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
