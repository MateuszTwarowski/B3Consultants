using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;

namespace B3Consultants.Services
{
    public interface IAvailabilityService
    {
        IEnumerable<Availability> GetAvailabilities();
        void AddAvailability(AddAvailabilityDTO AvailabilityDTO);
        void ModifyAvailability(AddAvailabilityDTO AvailabilityDTO, int id);
        void DeleteAvailability(int id);
    }
}
