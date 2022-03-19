using B3Consultants.Models;

namespace B3ConsultantsUI.Services
{
    public interface IConsultantService
    {
        Task<PagedResultModel<ConsultantDTO>> GetConsultants();
        Task<PagedResultModel<ConsultantDTO>> AddConsultant(AddConsultantDTO consultant);
    }
}
