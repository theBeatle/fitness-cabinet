using FitnessApp.Models.ViewModels;
using AutoMapper;
using FitnessApp.Models.DB;

namespace FitnessApp.Models.Mapping
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.Login, map => map.MapFrom(vm => vm.Login));
        }
    }
}