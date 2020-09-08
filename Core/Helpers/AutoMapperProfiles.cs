using AutoMapper;
using Core.Models;

namespace Core.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Permiso, PermisoRequest>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.EmployeeLastName, opt => opt.MapFrom(src => src.EmployeeLastName))
                .ForMember(dest => dest.TipoPermisoId, opt => opt.MapFrom(src => src.TipoPermisoId));
          
        }

    }
}
