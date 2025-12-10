using AutoMapper;
using BierShop9.Domain.EntitiesDB;
using BierShop9.ViewModels;
using BierShop9.Domain.EntitiesDB;

namespace BeerShop2.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Beer, BeersVM>()
                
                .ForMember(dest => dest.BreweryName,
                    opt => opt.MapFrom(src => src.BrouwernrNavigation.Naam))

                .ForMember(dest => dest.VarietyName,
                    opt => opt.MapFrom(src => src.SoortnrNavigation.Soortnaam));
        }
    }
}