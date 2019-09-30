using AutoMapper;
using soorat.api.Data.Dtos.Bazar;
using soorat.api.Data.Dtos.User;
using soorat.api.Models;

namespace soorat.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //Users
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(u => u.DateOfBirth.CalculateAge());
                });
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForRegisterDto, User>();
            //Bazar
            // CreateMap<Bazar, MadreseToReturn>()
            //     .ForMember(dest => dest.Moasese, opt => opt.MapFrom(src => src.Moasese.Name))
            //     .ForMember(dest => dest.Jensiyat, opt => opt.MapFrom(src => src.Jensiyat))         
            //     .ForMember(dest => dest.Maghta, opt => opt.MapFrom(src => src.Maghta));            
            CreateMap<BazarToAdd, Bazar>();
        }
        
    }
}