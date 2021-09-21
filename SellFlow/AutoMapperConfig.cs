using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellFlow.Model;
using Entity;

namespace SellFlow
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Pessoa, PessoaModel>().ReverseMap();

                cfg.CreateMap<Usuario, UsuarioModel>().ReverseMap();

                cfg.CreateMap<Permissao, PermissaoModel>().ReverseMap();

                cfg.CreateMap<Pagina, PaginaModel>().ReverseMap();

                cfg.CreateMap<Produto, ProdutoModel>().ReverseMap();

                cfg.CreateMap<Anuncio, AnuncioModel>().ReverseMap();

                cfg.CreateMap<Imagens, ImagensModel>().ReverseMap();
            });

            return config;
        }
    }
}
