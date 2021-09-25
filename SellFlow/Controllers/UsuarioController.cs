using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<UsuarioModel>> GetUsuario(int? id = null)
        {
            RetornoModel<List<UsuarioModel>> ret = new RetornoModel<List<UsuarioModel>>();
            try
            {
                UsuarioRepository rep = new UsuarioRepository();
                if (id.HasValue)
                {
                    Usuario usu = rep.Get(id.Value);
                    List<Usuario> lpes = new List<Usuario>();
                    lpes.Add(usu);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<UsuarioModel>>(lpes);
                }
                else
                {
                    List<Usuario> usu = new List<Usuario>();
                    usu = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<UsuarioModel>>(usu);
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

        [HttpPost]
        public RetornoModel<UsuarioModel> PostUsuario(UsuarioModel usuario)
        {
            RetornoModel<UsuarioModel> ret = new RetornoModel<UsuarioModel>();
            try
            {
                UsuarioRepository rep = new UsuarioRepository();
                Usuario usu = rep.Get(x => x.email == usuario.email);
                if(usu != null && usu.ativo)
                {
                    throw new Exception("E-mail já cadastrado!");
                }
                else if(usu != null && !usu.ativo)
                {
                    usuario.ativo = true;
                    usuario.id = usu.id;
                    usu = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Usuario>(usuario));
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<UsuarioModel>(usu);
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
                    ret.dados = mapper.Map<UsuarioModel>(rep.Add(mapper.Map<Usuario>(usuario)));
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

        [HttpDelete]
        public RetornoModel<UsuarioModel> DeleteUsuario(int id)
        {
            RetornoModel<UsuarioModel> ret = new RetornoModel<UsuarioModel>();
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

        [HttpPut]
        public RetornoModel<UsuarioModel> PutUsuario(UsuarioModel UsuarioModel)
        {
            RetornoModel<UsuarioModel> ret = new RetornoModel<UsuarioModel>();
            try
            {
                UsuarioRepository rep = new UsuarioRepository();
                Usuario usu = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Usuario>(UsuarioModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<UsuarioModel>(usu);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Usuario!";
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
