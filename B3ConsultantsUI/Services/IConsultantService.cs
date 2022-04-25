using B3Consultants.Models;

namespace B3ConsultantsUI.Services
{
    public interface IConsultantService
    {
        Task<PagedResultModel<ConsultantDTO>> GetConsultants(int page, int pageSize);
        Task<ConsultantDTO> GetConsultantById(int id);
        Task<PagedResultModel<ConsultantDTO>> SearchConsultant(int page, int pageSize, string searchPhrase);
        Task<PagedResultModel<ConsultantDTO>> AddConsultant(AddConsultantDTO consultant);
        Task<PagedResultModel<ConsultantDTO>> RemoveConsultant(int id);
        Task<PagedResultModel<ConsultantDTO>> ModifyConsultant(int id, AddConsultantDTO consultant);
    }
}
