using B3Consultants.Models;
using Microsoft.AspNetCore.Components;

namespace B3ConsultantsUI.Services
{
    public class ConsultantService : IConsultantService
    {
        private readonly HttpClient _httpClient;
        public ConsultantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PagedResultModel<ConsultantDTO>> GetConsultants(int page, int pageSize)
        {
            var result = await _httpClient.GetJsonAsync<PagedResultModel<ConsultantDTO>>($"/consultants?PageSize={pageSize}&PageNumber={page}");
            return result;
        }

        public async Task<ConsultantDTO> GetConsultantById(int id)
        {
            var result = await _httpClient.GetJsonAsync<ConsultantDTO>($"/consultants/byId/{id}");
            return result;
        }

        public async Task<PagedResultModel<ConsultantDTO>> AddConsultant(AddConsultantDTO consultant)
        {
            await _httpClient.PostJsonAsync("/consultants/addConsultant", consultant);
            var consultants = await _httpClient.GetJsonAsync<PagedResultModel<ConsultantDTO>>("consultants?PageSize=15&PageNumber=1");
            return consultants;
        }

        public async Task<PagedResultModel<ConsultantDTO>> RemoveConsultant(int id)
        {
            await _httpClient.DeleteAsync($"/consultants/removeConsultant{id}");
            var consultants = await _httpClient.GetJsonAsync<PagedResultModel<ConsultantDTO>>("consultants?PageSize=15&PageNumber=1");
            return consultants;
        }

        public async Task<PagedResultModel<ConsultantDTO>> ModifyConsultant(int id, AddConsultantDTO consultant)
		{
            await _httpClient.PutJsonAsync($"/consultants/modfiyConsultant{id}", consultant);
            var consultants = await _httpClient.GetJsonAsync<PagedResultModel<ConsultantDTO>>("consultants?PageSize=15&PageNumber=1");
            return consultants;
        }

    } 
}
