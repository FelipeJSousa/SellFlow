using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<AnuncioModel>> GetAnuncio(int? id = null)
        {
            RetornoModel<List<AnuncioModel>> ret = new RetornoModel<List<AnuncioModel>>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                if (id.HasValue)
                {
                    Anuncio anun = rep.Get(x => x.id.Equals(id.Value));
                    List<Anuncio> lanun = new List<Anuncio>();
                    lanun.Add(anun);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<AnuncioModel>>(lanun);
                }
                else
                {
                    List<Anuncio> anun = new List<Anuncio>();
                    anun = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<AnuncioModel>>(anun);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Anuncio!";
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
        public RetornoModel<AnuncioModel> PostAnuncio(AnuncioModel anun)
        {
            RetornoModel<AnuncioModel> ret = new RetornoModel<AnuncioModel>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _anuncio = mapper.Map<Anuncio>(anun);
                _anuncio.NovoAnuncio();
                ret.dados = mapper.Map<AnuncioModel>(rep.Add(_anuncio));
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Anuncio!";
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
        public RetornoModel<AnuncioModel> DeleteAnuncio(long id)
        {
            RetornoModel<AnuncioModel> ret = new RetornoModel<AnuncioModel>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();

                Anuncio anun = rep.Get(id);
                if (anun != null)
                {
                    if (rep.Delete(anun))
                    {
                        ret.status = true;
                        ret.mensagem = $"Anuncio {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o Anuncio {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Anuncio não encontrada";
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
        public RetornoModel<AnuncioModel> PutAnuncio(AnuncioModel AnuncioModel)
        {
            RetornoModel<AnuncioModel> ret = new RetornoModel<AnuncioModel>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                Anuncio anun = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Anuncio>(AnuncioModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<AnuncioModel>(anun);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Anuncio!";
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
