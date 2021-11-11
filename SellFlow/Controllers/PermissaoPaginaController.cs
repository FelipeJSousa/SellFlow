﻿using AutoMapper;
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
    public class PermissaoPaginaController : ControllerBase
    {

        [HttpGet("Permissao/{idPermissao}")]
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
        public IActionResult PostPermissaoPagina(List<PermissaoPaginaModel> list)
        {
            RetornoModel<List<PermissaoPaginaModel>> ret = new RetornoModel<List<PermissaoPaginaModel>>();
            try
            {
                if (!list.Any())
                {
                    ret.erro = "Informe os elementos.";
                    ret.status = false;
                    return BadRequest(ret);
                }
                PermissaoPaginaRepository rep = new PermissaoPaginaRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _permissaoPaginaList = mapper.Map<List<PermissaoPagina>>(list);
                var resp = list.Select(x => x.permissao).Distinct().Count() == 1 ? rep.GetAll(x => x.permissao == list.FirstOrDefault().permissao) : rep.GetAll(x => x.pagina == list.FirstOrDefault().pagina);
                foreach (var item in resp)
                {
                    rep.Delete(item);
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

        [HttpPost("/PermissaoPagina/Validar")]
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
