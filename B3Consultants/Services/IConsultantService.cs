using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs;

namespace B3Consultants.Services
{
    public interface IConsultantService
    {
        IEnumerable<ConsultantDTO> GetConsultants();
        void AddConsultant(AddConsultantDTO consultantDTO);
        void ModifyConsultant(AddConsultantDTO consultantDTO, int id);
        void DeleteConsultant(int id);
    }
}

