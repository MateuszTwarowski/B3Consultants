using B3Consultants.Models;
using Microsoft.AspNetCore.Components;

namespace B3ConsultantsUI.Services
{
    public class ConsultantService : IConsultantService
    {
        private readonly HttpClient _httpClient;
        public ConsultantService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PagedResultModel<ConsultantDTO>> GetConsultants()
        {
            var result = await _httpClient.GetJsonAsync<PagedResultModel<ConsultantDTO>>("/consultants?PageSize=15&PageNumber=1");
            return result;
        }

        public async Task<PagedResultModel<ConsultantDTO>> AddConsultant(AddConsultantDTO consultant)
        {
            await _httpClient.PostJsonAsync("/consultants/addConsultant", consultant);
            var consultants = await _httpClient.GetJsonAsync<PagedResultModel<ConsultantDTO>>("consultants?PageSize=15&PageNumber=1");
            return consultants;
        }
    }
}
