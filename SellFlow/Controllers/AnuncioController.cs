using AutoMapper;
using Entity;
using LinqKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using SellFlow.Model.ApiResponse;
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
        public RetornoModel<List<AnuncioApiResponse>> GetAnuncio(int? id = null, int? idUsuario = null, string busca = null, int? categoria = null)
        {
            RetornoModel<List<AnuncioApiResponse>> ret = new RetornoModel<List<AnuncioApiResponse>>();
            try
            {
                AnuncioRepository rep = new AnuncioRepository();
                Expression<Func<Anuncio, bool>> _predicate = PredicateBuilder.New<Anuncio>(true);
                _predicate = _predicate.And(x => x.anuncioSituacao == 2);

                if(id is not null)
                {
                    _predicate = _predicate.And(x => x.id == id);
                }

                if (idUsuario is not null)
                {
                    _predicate = _predicate.And(x => x.produtoObj.usuario == idUsuario);
                }

                if (!string.IsNullOrWhiteSpace(busca))
                {
                    _predicate = _predicate.And(x => x.nome.ToLower().Contains(busca.ToLower()) ||
                                                     x.descricao.ToLower().Contains(busca.ToLower()) ||
                                                     x.produtoObj.nome.ToLower().Contains(busca.ToLower()) ||
                                                     x.produtoObj.descricao.ToLower().Contains(busca.ToLower()));
                }

                if (categoria is not null)
                {
                    _predicate = _predicate.And(x => x.produtoObj.categoria == categoria);
                }


                if (id.HasValue)
                {
                    var anun = new Mapper(AutoMapperConfig.RegisterMappings()).Map<AnuncioApiResponse>(rep.Get(_predicate));
                    anun.vendedor = getVendedor(anun.produtoObj.usuario);
                    List<AnuncioApiResponse> lanun = new ();
                    lanun.Add(anun);
                    ret.dados = lanun;
                }
                else
                {
                    var anun = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<AnuncioApiResponse>>(rep.GetAll(_predicate));
                    foreach (var item in anun)
                    {
                        item.vendedor = getVendedor(item.produtoObj.usuario);
                    }
                    ret.dados = anun;
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.status = false;
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
                    item.vendedor = getVendedor(item.produtoObj.usuario);
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

        private string getVendedor(long usuario) => new PessoaRepository().GetPorUsuario(usuario).nome;
    }
}
