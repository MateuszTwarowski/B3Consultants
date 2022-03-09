using AutoMapper;
using B3Consultants.Entities;
using B3Consultants.Models;

namespace B3Consultants
{
    public class ProfilesAutoMapper : Profile
    {
        public ProfilesAutoMapper()
        {
            CreateMap<Consultant, ConsultantDTO>()
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role.RoleTitle))
                .ForMember(x => x.Experience, y => y.MapFrom(z => z.Experience.ExperienceLevel))
                .ForMember(x => x.Availability, y => y.MapFrom(z => z.Availability.WhenAvailable));
            CreateMap<AddConsultantDTO, Consultant>();

            CreateMap<AddRoleDTO, Role>();

            CreateMap<AddExperienceDTO, Experience>();

            CreateMap<AddAvailabilityDTO, Availability>();

            CreateMap<User, UserDTO>()
                .ForMember(x => x.UserRole, y => y.MapFrom(z => z.UserRole.UserRoleTitle));
            CreateMap<RegisterUserDTO, User>();
        }
    }
}
