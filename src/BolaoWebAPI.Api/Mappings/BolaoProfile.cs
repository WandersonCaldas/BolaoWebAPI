using AutoMapper;
using BolaoWebAPI.Api.Requests;
using BolaoWebAPI.Api.Responses;
using BolaoWebAPI.Domain.Entities;

namespace BolaoWebAPI.Api.Mappings
{
    public class BolaoProfile : Profile
    {
        public BolaoProfile()
        {
            CreateMap<BolaoCreateRequest, Bolao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<Bolao, BolaoResponse>();

            CreateMap<BolaoUpdateRequest, Bolao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());
        }
    }
}
