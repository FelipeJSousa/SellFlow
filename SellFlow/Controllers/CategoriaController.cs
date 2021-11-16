using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using System;
using System.Collections.Generic;

namespace SellFlow.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<CategoriaModel>> GetCategoria(int? id = null)
        {
            RetornoModel<List<CategoriaModel>> ret = new RetornoModel<List<CategoriaModel>>();
            try
            {
                CategoriaRepository rep = new CategoriaRepository();
                if (id.HasValue)
                {
                    Categoria cat = rep.Get(id.Value);
                    List<Categoria> lcat = new List<Categoria>();
                    lcat.Add(cat);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<CategoriaModel>>(lcat);
                }
                else
                {
                    List<Categoria> cat = new List<Categoria>();
                    cat = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<CategoriaModel>>(cat);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Categoria!";
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
        [Authorize]
        public RetornoModel<CategoriaModel> PostCategoria(CategoriaModel cat)
        {
            RetornoModel<CategoriaModel> ret = new RetornoModel<CategoriaModel>();
            try
            {
                CategoriaRepository rep = new CategoriaRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.dados = mapper.Map<CategoriaModel>(rep.Add(mapper.Map<Categoria>(cat)));
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Categoria!";
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
        [Authorize]
        public RetornoModel<CategoriaModel> DeleteCategoria(long id)
        {
            RetornoModel<CategoriaModel> ret = new RetornoModel<CategoriaModel>();
            try
            {
                CategoriaRepository rep = new CategoriaRepository();

                Categoria cat = rep.Get(id);
                if (cat != null)
                {
                    if (rep.Delete(cat))
                    {
                        ret.status = true;
                        ret.mensagem = $"Categoria {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o Categoria {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Categoria não encontrada";
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
        [Authorize]
        public RetornoModel<CategoriaModel> PutCategoria(CategoriaModel CategoriaModel)
        {
            RetornoModel<CategoriaModel> ret = new RetornoModel<CategoriaModel>();
            try
            {
                CategoriaRepository rep = new CategoriaRepository();
                Categoria cat = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Categoria>(CategoriaModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<CategoriaModel>(cat);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Categoria!";
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
