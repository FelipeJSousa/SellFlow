using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellFlow.Model;
using Entity;
using SellFlow.Model.ApiRequest;
using SellFlow.Model.ApiResponse;

namespace SellFlow
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Pessoa, PessoaModel>().ReverseMap();
                cfg.CreateMap<Pessoa, PessoaPostApiRequest>().ReverseMap();

                cfg.CreateMap<Endereco, EnderecoModel>().ReverseMap();

                cfg.CreateMap<Usuario, UsuarioModel>().ReverseMap();
                cfg.CreateMap<Usuario, ApiResponseAcesso>().ReverseMap();
                cfg.CreateMap<Usuario, ApiResponseUsuario>().ReverseMap();
                cfg.CreateMap<UsuarioModel, ApiResponseUsuario>().ReverseMap();

                cfg.CreateMap<Permissao, PermissaoModel>().ReverseMap();

                cfg.CreateMap<PermissaoPagina, PermissaoPaginaModel>().ReverseMap();

                cfg.CreateMap<Pagina, PaginaModel>().ReverseMap();

                cfg.CreateMap<Categoria, CategoriaModel>().ReverseMap();

                cfg.CreateMap<Produto, ProdutoModel>()
                   .ForMember(dest => dest.usuario, opt => opt.MapFrom(src => src.usuario))
                   .ReverseMap()
                   .ForMember(dest => dest.usuario, opt => opt.MapFrom(src => src.usuario));

                cfg.CreateMap<Anuncio, AnuncioModel>()
                    .ForMember(dest => dest.valor, opt => opt.MapFrom(src => src.valor))
                    .AfterMap((src, dest) => dest.percentPromocao = dest.CalculaPercentPromocao())
                    .ReverseMap();

                cfg.CreateMap<Anuncio, AnuncioApiResponse>().ReverseMap();

                cfg.CreateMap<Imagens, ImagensModel>().ReverseMap();

                cfg.CreateMap<AnuncioSituacao, AnuncioSituacaoModel>().ReverseMap();

                cfg.CreateMap<Anuncio, AnuncioApiResponse>().ReverseMap();

            });

            return config;
        }

    }
}
