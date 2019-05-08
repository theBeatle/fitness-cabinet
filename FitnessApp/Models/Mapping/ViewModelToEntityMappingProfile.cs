using FitnessApp.Models.ViewModels;
using AutoMapper;
using FitnessApp.Models.DB;

namespace FitnessApp.Models.Mapping
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, Person>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.UserName));
        }
    }
}