using B3Consultants.Entities;
using B3Consultants.Models;

namespace B3Consultants.Services
{
    public interface IConsultantService
    {
        PagedResult<ConsultantDTO> GetConsultants(ConsultantQuery? query);
        void AddConsultant(AddConsultantDTO consultantDTO);
        void ModifyConsultant(AddConsultantDTO consultantDTO, int id);
        void DeleteConsultant(int id);
    }
}

