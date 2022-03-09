using B3Consultants.DB;
using B3Consultants.Entities;
using B3Consultants.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using B3Consultants.Exceptions;

namespace B3Consultants.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private ConsultantDBContext _dBContext;
        private IMapper _mapper;
        private ILogger _logger;
        public AvailabilityService(ConsultantDBContext dBContext, IMapper mapper, ILogger<AvailabilityService> logger)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<Availability> GetAvailabilities()
        {
            var availabilities = _dBContext.Availabilities.ToList();
            return availabilities;
        }

        public void AddAvailability(AddAvailabilityDTO AvailabilityDTO)
        {
            var availability = _mapper.Map<Availability>(AvailabilityDTO);
            _dBContext.Availabilities.Add(availability);
            _dBContext.SaveChanges();
        }
        public void ModifyAvailability(AddAvailabilityDTO AvailabilityDTO, int id)
        {
            var availability = _dBContext.Availabilities.FirstOrDefault(x => x.Id == id);
            if (availability == null)
            {
                throw new NotFoundException("Availability not found");
            }
            var availabilityModified = _mapper.Map<Availability>(AvailabilityDTO);
            availability.WhenAvailable = availabilityModified.WhenAvailable;

            _dBContext.Availabilities.Update(availability);
            _dBContext.SaveChanges();
        }
        public void DeleteAvailability(int id)
        {

            var availability = _dBContext.Availabilities.FirstOrDefault(x => x.Id == id);

            if (availability == null)
            {
                throw new NotFoundException("Availability not found");
            }

            _dBContext.Availabilities.Remove(availability);
            _dBContext.SaveChanges();
        }
    }
}
