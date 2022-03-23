using B3Consultants.Entities;
using Microsoft.AspNetCore.Components;

namespace B3ConsultantsUI.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;
        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _httpClient.GetJsonAsync<IEnumerable<Role>>("roles");
            return roles;
        }
    }
}
