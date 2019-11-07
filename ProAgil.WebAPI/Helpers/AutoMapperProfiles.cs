using System.Linq;
using AutoMapper;
using WebSalao.Domain;
using WebSalao.Domain.Cadasto;
using WebSalao.Domain.Identity;
using WebSalao.WebAPI.Dtos;
using WebSalao.WebAPI.Dtos.CadastroDto;

namespace WebSalao.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.Palestrantes, opt =>
                {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
                })
                .ReverseMap();

            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest => dest.Eventos, opt =>
                {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
                })
                .ReverseMap();

            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();

            //tarbelas de castro
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.Contas, opt =>
                {
                    opt.MapFrom(src => src.ContasClientes.Select(x => x.Contas).ToList());
                })
                .ReverseMap();

            CreateMap<Contas, ContasDto>()
                .ForMember(dest => dest.Clientes, opt =>
                {
                    opt.MapFrom(src => src.ContasClientes.Select(x => src.Cliente).ToList());
                })
                .ReverseMap();

            CreateMap<FormasDePagamento, FormasDePagamentoDto> ().ReverseMap();
            CreateMap<Fornecedor, FornecedorDto> ().ReverseMap();
            CreateMap<Lojas, LojasDto>().ReverseMap();
            CreateMap<Produto, ProdutosDto> ().ReverseMap();
            //Lancamento
            CreateMap<TipoLancamento, TipoLancamentoDto > ().ReverseMap();
            CreateMap<SubTipoLancamento, SubTipoLancamentosDto>().ReverseMap();

        }
    }
}