using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI{
    public class MappingConfig : Profile{
        public MappingConfig(){
            CreateMap<Villa,VillaDTO>();
            CreateMap<VillaDTO,Villa>();
            CreateMap<Villa,VillaCreateDTO>().ReverseMap();
            CreateMap<Villa,VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumber,VillaNumberDTO>().ReverseMap();
            // CreateMap<VillaDTO,Villa>();
            CreateMap<VillaNumber,VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}