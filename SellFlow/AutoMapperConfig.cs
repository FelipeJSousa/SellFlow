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
                cfg.CreateMap<Pessoa, PessoaModel>();
                cfg.CreateMap<PessoaModel, Pessoa>();

                cfg.CreateMap<UsuarioModel, Usuario>();
                cfg.CreateMap<Usuario, UsuarioModel>();

                cfg.CreateMap<Permissao, PermissaoModel>();
                cfg.CreateMap<PermissaoModel, Permissao>();

                cfg.CreateMap<Pagina, PaginaModel>();
                cfg.CreateMap<PaginaModel, Pagina>();
            });

            return config;
        }
    }
}
