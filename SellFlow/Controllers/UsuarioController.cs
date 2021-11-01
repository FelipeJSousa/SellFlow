using AutoMapper;
using Microsoft.Extensions.Configuration;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using SellFlow.Model.ApiResponse;

namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public RetornoModel<List<ApiResponseUsuario>> GetUsuario(int? id = null)
        {
            RetornoModel<List<ApiResponseUsuario>> ret = new RetornoModel<List<ApiResponseUsuario>>();
            try
            {
                UsuarioRepository rep = new UsuarioRepository();
                if (id.HasValue)
                {
                    Usuario usu = rep.Get(id.Value);
                    List<Usuario> lpes = new();
                    lpes.Add(usu);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ApiResponseUsuario>>(lpes);
                }
                else
                {
                    List<Usuario> usu = new List<Usuario>();
                    usu = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ApiResponseUsuario>>(usu);
                }

                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a Usuario!";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }

            return ret;
        }

        [Authorize]
        [HttpPost]
        public RetornoModel<ApiResponseUsuario> PostUsuario(UsuarioModel usuario)
        {
            RetornoModel<ApiResponseUsuario> ret = new RetornoModel<ApiResponseUsuario>();
            try
            {
                if (usuario.permissao == 0)
                {
                    ret.mensagem = ("Informe o nível de permissão do usuário!");
                    ret.status = false;
                    return ret;
                }
                UsuarioRepository rep = new UsuarioRepository();
                Usuario usu = rep.Get(x => x.email == usuario.email);
                if (usu is {ativo: true})
                {
                    ret.mensagem = ("E-mail já cadastrado!");
                    ret.status = false;
                    return ret;
                }
                else if (usu is {ativo: false})
                {
                    usuario.ativo = true;
                    usuario.id = usu.id;
                    usu = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Usuario>(usuario));
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ApiResponseUsuario>(usu);
                    if (ret.dados != null)
                    {
                        ret.status = true;
                    }
                    else
                    {
                        ret.mensagem = "Não foi encontrado o Usuario!";
                    }
                }
                else
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                    ret.dados = mapper.Map<ApiResponseUsuario>(rep.Add(mapper.Map<Usuario>(usuario)));
                    if (ret.dados != null)
                    {
                        ret.status = true;
                    }
                    else
                    {
                        ret.mensagem = "Não foi encontrado o UsuarioModel!";
                    }
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }

            return ret;
        }

        [Authorize]
        [HttpDelete]    
        public RetornoModel<ApiResponseUsuario> DeleteUsuario(long id)
        {
            RetornoModel<ApiResponseUsuario> ret = new RetornoModel<ApiResponseUsuario>();
            try
            {
                UsuarioRepository rep = new UsuarioRepository();

                Usuario usu = rep.Get(id);
                if (usu != null)
                {
                    if (rep.Delete(usu))
                    {
                        ret.status = true;
                        ret.mensagem = $"Usuario {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o Usuario {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Usuario não encontrada";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }

            return ret;
        }

        [Authorize]
        [HttpPut]
        public RetornoModel<ApiResponseUsuario> PutUsuario(UsuarioModel obj)
        {
            RetornoModel<ApiResponseUsuario> ret = new RetornoModel<ApiResponseUsuario>();
            try
            {
                if (obj.id > 0)
                {
                    UsuarioRepository rep = new UsuarioRepository();

                    var _ret = rep.Get(obj.id.Value);

                    Usuario update = new()
                    {
                        id = obj.id.Value,
                        ativo = obj.ativo == null ? _ret.ativo : obj.ativo.Value,
                        email = string.IsNullOrWhiteSpace(obj.email) ? _ret.email : obj.email,
                        permissao = obj.permissao == null ? _ret.permissao : obj.permissao.Value,
                        senha = obj.senha
                    };

                    Usuario usu = rep.Edit(update);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ApiResponseUsuario>(usu);
                    if (ret.dados != null)
                    {
                        ret.status = true;
                    }
                    else
                    {
                        ret.mensagem = "Não foi encontrado o Usuario!";
                    } 
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }

            return ret;
        }

    }
}