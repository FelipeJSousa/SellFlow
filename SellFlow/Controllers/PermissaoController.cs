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
    public class PermissaoController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<PermissaoModel>> GetPermissao(int? id = null)
        {
            RetornoModel<List<PermissaoModel>> ret = new RetornoModel<List<PermissaoModel>>();
            try
            {
                PermissaoRepository rep = new PermissaoRepository();
                if (id.HasValue)
                {
                    Permissao pag = rep.Get(id.Value);
                    List<Permissao> lpag = new List<Permissao>();
                    lpag.Add(pag);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PermissaoModel>>(lpag);
                }
                else
                {
                    List<Permissao> pag = new List<Permissao>();
                    pag = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PermissaoModel>>(pag);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a Permissao!";
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
        public RetornoModel<PermissaoModel> PostPermissaoModel(PermissaoModel Permissao)
        {
            RetornoModel<PermissaoModel> ret = new RetornoModel<PermissaoModel>();
            try
            {
                PermissaoRepository rep = new PermissaoRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _permissao = rep.Add(mapper.Map<Permissao>(Permissao));
                ret.dados = mapper.Map<PermissaoModel>(_permissao);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Permissao!";
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
        public IActionResult DeletePermissaoModel(long id)
        {
            RetornoModel<PermissaoModel> ret = new RetornoModel<PermissaoModel>();
            try
            {
                PermissaoRepository rep = new PermissaoRepository();

                Permissao pag = rep.Get(id);
                if (pag.id == 1)
                {
                    ret.erro = "Não é possível excluir a Permissão de Administrador.";
                    ret.status = false;
                    return BadRequest(ret);
                }
                if (pag != null)
                {
                    if (rep.Delete(pag))
                    {
                        ret.status = true;
                        ret.mensagem = $"Permissao {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o Permissao {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Permissao não encontrada";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }
            return Ok(ret);
        }

        [HttpPut]
        public RetornoModel<PermissaoModel> PutPermissaoModel(PermissaoModel PermissaoModel)
        {
            RetornoModel<PermissaoModel> ret = new RetornoModel<PermissaoModel>();
            try
            {
                PermissaoRepository rep = new PermissaoRepository();
                Permissao pag = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Permissao>(PermissaoModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<PermissaoModel>(pag);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Permissao!";
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
