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
        [HttpPost]
        public RetornoModel<PermissaoPaginaModel> PostPermissaoPagina(PermissaoPaginaModel obj)
        {
            RetornoModel<PermissaoPaginaModel> ret = new RetornoModel<PermissaoPaginaModel>();
            try
            {
                PermissaoPaginaRepository rep = new PermissaoPaginaRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _PermissaoPagina = mapper.Map<PermissaoPagina>(obj);
                if (Validar(_PermissaoPagina))
                {
                    ret.status = false;
                    ret.erro = "Não é possível inserir permissoes duplicadas.";
                    return ret;
                }
                rep.Add(_PermissaoPagina);
                ret.status = true;
                ret.dados = mapper.Map<PermissaoPaginaModel>(_PermissaoPagina);
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }
            return ret;
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