using B3Consultants.Entities;
using Microsoft.AspNetCore.Components;

namespace B3ConsultantsUI.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly HttpClient _httpClient;

        public ExperienceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Experience>> GetExperiences()
        {
            var experiences = await _httpClient.GetJsonAsync<IEnumerable<Experience>>("experiences");
            return experiences;
        }
    }
}