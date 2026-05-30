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

            CreateMap<BolaoUpdateRequest, Bolao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());

            CreateMap<Bolao, BolaoResponse>();

            CreateMap<ParticipanteCreateRequest, Participante>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ParticipanteUpdateRequest, Participante>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());

            CreateMap<Participante, ParticipanteResponse>();

            CreateMap<BolaoParticipante, BolaoParticipanteResponse>();

            CreateMap<JogoCreateRequest, Jogo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Jogo, JogoResponse>();
            
            CreateMap<ModalidadeCreateRequest, Modalidade>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ModalidadeUpdateRequest, Modalidade>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());

            CreateMap<Modalidade, ModalidadeResponse>();
            
            CreateMap<ResultadoCreateRequest, Resultado>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataResultado, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Resultado, ResultadoResponse>();
        }
    }
}
