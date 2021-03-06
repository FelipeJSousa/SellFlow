using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using SellFlow.Model.ApiRequest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SellFlow.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoPaginaController : ControllerBase
    {
        [HttpGet("Permissao/{idPermissao}")]
        [Authorize]
        public RetornoModel<IEnumerable<long>> GetPaginaPorPermissao(int idPermissao)
        {
            RetornoModel<IEnumerable<long>> ret = new ();

            PermissaoPaginaRepository rep = new PermissaoPaginaRepository();

            var paginas = rep.GetAll(x => x.permissao == idPermissao);

            if (paginas.Any())
            {
                ret.status = true;
                ret.dados = paginas.Select(x => x.pagina);
            }
            else
            {
                ret.status = false;
                ret.erro = "Não foi encontrado nenhuma pagina.";
            }

            return ret;
        }

        [HttpGet("Pagina/{idPagina}")]
        [Authorize]
        public RetornoModel<IEnumerable<long>> GetPermissaoPorPagina(int idPagina)
        {
            RetornoModel<IEnumerable<long>> ret = new ();

            PermissaoPaginaRepository rep = new PermissaoPaginaRepository();

            var paginas = rep.GetAll(x => x.pagina == idPagina);

            if (paginas.Any())
            {
                ret.dados = paginas.Select(x => x.permissao);
            }
            else
            {
                ret.erro = "Não foi encontrado nenhuma permissão.";
            }

            return ret;
        }


        [HttpPost]
        [Authorize]
        public IActionResult PostPermissaoPagina(ApiRequestPermissaoPagina list)
        {
            RetornoModel<List<PermissaoPaginaModel>> ret = new RetornoModel<List<PermissaoPaginaModel>>();
            try
            {
                if (list.permissao?.Any() != true && list.pagina?.Any() != true)
                {
                    ret.erro = "Informe os elementos.";
                    ret.status = false;
                    return BadRequest(ret);
                }
                PermissaoPaginaRepository rep = new PermissaoPaginaRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                List<PermissaoPagina> _permissaoPaginaList = new();
                if (list.pagina?.Any() == true)
                {
                    _permissaoPaginaList = mapper.Map<List<PermissaoPagina>>(list.pagina);
                    var resp = rep.GetAll(x => x.pagina == list.pagina.FirstOrDefault().pagina);
                    foreach (var pag in resp)
                    {
                        rep.Delete(pag);
                    }
                }
                else
                {
                    _permissaoPaginaList = mapper.Map<List<PermissaoPagina>>(list.permissao);
                    var resp = rep.GetAll(x => x.permissao == list.permissao.FirstOrDefault().permissao);
                    foreach (var per in resp)
                    {
                        rep.Delete(per);
                    }
                }


                foreach (var item in _permissaoPaginaList)
                {
                    ret.status = true;
                    rep.Add(item);
                }

                ret.dados = mapper.Map<List<PermissaoPaginaModel>>(_permissaoPaginaList);
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
                return BadRequest(ret);
            }
            return Ok(ret);
        }

        [HttpGet("Pagina/Validar")]
        public IActionResult ValidaPermissaoPagina(string caminhoPagina, long idPermissao)
        {
            RetornoModel<PermissaoPaginaModel> ret = new RetornoModel<PermissaoPaginaModel>();
            try
            {
                PermissaoPaginaRepository rep = new PermissaoPaginaRepository();
                var obj = rep.Get(x => x.paginaObj.caminho == caminhoPagina && x.permissao == idPermissao);
                if(obj is null)
                {
                    return Forbid();
                }
                ret.status = true;
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }
            return Ok(ret);
        }


        [HttpPost("/Validar")]
        public RetornoModel<PermissaoPaginaModel> ValidaPermissaoPagina(PermissaoPaginaModel obj)
        {
            RetornoModel<PermissaoPaginaModel> ret = new RetornoModel<PermissaoPaginaModel>();
            try
            {
                ret.status = Validar(new Mapper(AutoMapperConfig.RegisterMappings()).Map<PermissaoPagina>(obj));
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }
            return ret;
        }

        [HttpDelete]
        [Authorize]
        public RetornoModel<PermissaoPaginaModel> DeletePermissaoPaginaModel(PermissaoPaginaModel obj)
        {
            RetornoModel<PermissaoPaginaModel> ret = new RetornoModel<PermissaoPaginaModel>();
            try
            {
                PermissaoPaginaRepository rep = new PermissaoPaginaRepository();

                if (rep.Delete(new Mapper(AutoMapperConfig.RegisterMappings()).Map<PermissaoPagina>(obj)))
                {
                    ret.status = true;
                    ret.mensagem = $"PermissaoPagina excluído com sucesso!";
                }
                else
                {
                    ret.status = false;
                    ret.mensagem = $"Não foi possível excluir o PermissaoPagina";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }
            return ret;
        }


        protected bool Validar(PermissaoPagina obj)
        {
            PermissaoPaginaRepository rep = new PermissaoPaginaRepository();
            var _PermissaoPagina = rep.Get(x => x.pagina == obj.pagina && x.permissao == obj.permissao);
            if(_PermissaoPagina is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
