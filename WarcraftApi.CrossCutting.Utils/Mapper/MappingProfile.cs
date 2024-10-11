using AutoMapper;
using WarcraftApi.DistributedServices.Models;
using WarcraftApi.DomainServices.Models;
using WarcraftApi.Infraestructure.Models;

namespace WarcraftApi.CrossCutting.Utils.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CharacterDto, CharacterBe>().ReverseMap();
        CreateMap<CharacterBe, CharacterDm>().ReverseMap();
        
        CreateMap<WeaponDto, WeaponBe>().ReverseMap();
        CreateMap<WeaponBe, WeaponDm>().ReverseMap();
        
        CreateMap<CharacterDm, CharacterBe>()
            .ForMember(dest => dest.Weapons, opt => opt.MapFrom(src => src.CharacterWeapons.Select(cw => cw.Weapon)));
        
    }
}