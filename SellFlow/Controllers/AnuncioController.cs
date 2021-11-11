using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using SellFlow.Model.ApiResponse;
using System;
using System.Collections.Generic;

namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public RetornoModel<List<AnuncioModel>> GetAnuncio(int? id = null, int? idUsuario = null)
        {
            RetornoModel<List<AnuncioModel>> ret = new RetornoModel<List<AnuncioModel>>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                if (id.HasValue)
                {
                    Anuncio anun = rep.Get(id.Value, idUsuario);
                    List<Anuncio> lanun = new ();
                    lanun.Add(anun);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<AnuncioModel>>(lanun);
                }
                else
                {
                    List<Anuncio> anun = new List<Anuncio>();
                    anun = rep.GetAll(idUsuario);
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

        
        [HttpGet("Situacao")]
        public RetornoModel<List<AnuncioApiResponse>> GetAnuncioPorSituacao(int idSituacao)
        {
            RetornoModel<List<AnuncioApiResponse>> ret = new ();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                List<Anuncio> lanun = rep.GetPorSituacao(idSituacao);
                PessoaRepository reppessoa = new PessoaRepository();
                var retobj = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<AnuncioApiResponse>>(lanun);
                foreach (var item in retobj)
                {
                    var pes = reppessoa.GetPorUsuario(item.produtoObj.usuario);
                    item.vendedor = pes.nome + " " + pes.sobrenome;
                }
                ret.dados = retobj;

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
        [Authorize]
        public RetornoModel<AnuncioModel> PostAnuncio(AnuncioModel anun)
        {
            RetornoModel<AnuncioModel> ret = new RetornoModel<AnuncioModel>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _anuncio = mapper.Map<Anuncio>(anun);
                _anuncio.NovoAnuncio();
                _anuncio = rep.Add(_anuncio);
                _anuncio = rep.Get(x => x.id.Equals(_anuncio.id));
                
                ret.dados = mapper.Map<AnuncioModel>(_anuncio);
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
        [Authorize]
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
        [Authorize]
        public RetornoModel<AnuncioModel> PutAnuncio(AnuncioModel AnuncioModel)
        {
            RetornoModel<AnuncioModel> ret = new RetornoModel<AnuncioModel>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                Anuncio anun = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Anuncio>(AnuncioModel));
                anun = rep.Get(anun.id);
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
