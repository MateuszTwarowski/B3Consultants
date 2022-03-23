using B3Consultants.Entities;
using Microsoft.AspNetCore.Components;

namespace B3ConsultantsUI.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly HttpClient _httpClient;

        public AvailabilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Availability>> GetAvailabilities()
        {
            var availabilities = await _httpClient.GetJsonAsync<IEnumerable<Availability>>("availabilities");
            return availabilities;
        }
    }
}