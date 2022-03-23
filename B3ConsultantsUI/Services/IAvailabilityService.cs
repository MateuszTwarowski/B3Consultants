using B3Consultants.Entities;

namespace B3ConsultantsUI.Services
{
    public interface IAvailabilityService
    {
        Task<IEnumerable<Availability>> GetAvailabilities();
    }
}
