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
    public class PaginaController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<PaginaModel>> GetPagina(int? id = null)
        {
            RetornoModel<List<PaginaModel>> ret = new RetornoModel<List<PaginaModel>>();
            try
            {
                PaginaRepository rep = new PaginaRepository();
                if (id.HasValue)
                {
                    Pagina pag = rep.Get(id.Value);
                    List<Pagina> lpag = new List<Pagina>();
                    lpag.Add(pag);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PaginaModel>>(lpag);
                }
                else
                {
                    List<Pagina> pag = new List<Pagina>();
                    pag = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PaginaModel>>(pag);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a Pagina!";
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
        public RetornoModel<PaginaModel> PostPaginaModel(PaginaModel Pagina)
        {
            RetornoModel<PaginaModel> ret = new RetornoModel<PaginaModel>();
            try
            {
                PaginaRepository rep = new PaginaRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.dados = mapper.Map<PaginaModel>(rep.Add(mapper.Map<Pagina>(Pagina)));
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Pagina!";
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
        public RetornoModel<PaginaModel> DeletePaginaModel(long id)
        {
            RetornoModel<PaginaModel> ret = new RetornoModel<PaginaModel>();
            try
            {
                PaginaRepository rep = new PaginaRepository();

                Pagina pag = rep.Get(id);
                if (pag != null)
                {
                    if (rep.Delete(pag))
                    {
                        ret.status = true;
                        ret.mensagem = $"Pagina {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o Pagina {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Pagina não encontrada";
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
        public RetornoModel<PaginaModel> PutPaginaModel(PaginaModel PaginaModel)
        {
            RetornoModel<PaginaModel> ret = new RetornoModel<PaginaModel>();
            try
            {
                PaginaRepository rep = new PaginaRepository();
                Pagina pag = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Pagina>(PaginaModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<PaginaModel>(pag);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Pagina!";
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
