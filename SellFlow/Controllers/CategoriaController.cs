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
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public Retorno<List<CategoriaModel>> GetCategoria(int? id = null)
        {
            Retorno<List<CategoriaModel>> ret = new Retorno<List<CategoriaModel>>();
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
        public Retorno<CategoriaModel> PostCategoria(CategoriaModel cat)
        {
            Retorno<CategoriaModel> ret = new Retorno<CategoriaModel>();
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
        public Retorno<CategoriaModel> DeleteCategoria(int id)
        {
            Retorno<CategoriaModel> ret = new Retorno<CategoriaModel>();
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
        public Retorno<CategoriaModel> PutCategoria(CategoriaModel CategoriaModel)
        {
            Retorno<CategoriaModel> ret = new Retorno<CategoriaModel>();
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
