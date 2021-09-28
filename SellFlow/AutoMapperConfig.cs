﻿using AutoMapper;
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

                cfg.CreateMap<Categoria, CategoriaModel>().ReverseMap();

                cfg.CreateMap<Produto, ProdutoModel>()
                   .ForMember(dest => dest.usuarioVendedor, opt => opt.MapFrom(src => src.usuario))
                   .ReverseMap()
                   .ForMember(dest => dest.usuario, opt => opt.MapFrom(src => src.usuarioVendedor));

                cfg.CreateMap<Anuncio, AnuncioModel>()
                   .ForMember(dest => dest.AnuncioSituacao, opt => opt.MapFrom(src => src.anuncioSituacaoObj))
                   .ReverseMap();

                cfg.CreateMap<Imagens, ImagensModel>().ReverseMap();

                cfg.CreateMap<AnuncioSitucao, AnuncioSituacaoModel>().ReverseMap();
            });

            return config;
        }

    }
}
