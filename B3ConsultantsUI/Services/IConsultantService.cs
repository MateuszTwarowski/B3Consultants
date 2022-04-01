﻿using B3Consultants.Models;

namespace B3ConsultantsUI.Services
{
    public interface IConsultantService
    {
        Task<PagedResultModel<ConsultantDTO>> GetConsultants();
        Task<ConsultantDTO> GetConsultantById(int id);
        Task<PagedResultModel<ConsultantDTO>> AddConsultant(AddConsultantDTO consultant);
        Task<PagedResultModel<ConsultantDTO>> RemoveConsultant(int id);
        Task<PagedResultModel<ConsultantDTO>> ModifyConsultant(int id, AddConsultantDTO consultant);
    }
}
