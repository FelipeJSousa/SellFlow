using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using System;
using System.Collections.Generic;

namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioSituacaoController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<AnuncioSituacaoModel>> GetAnuncioSituacao(int? id = null)
        {
            RetornoModel<List<AnuncioSituacaoModel>> ret = new RetornoModel<List<AnuncioSituacaoModel>>();
            try
            {
                AnuncioSituacaoRepository rep = new AnuncioSituacaoRepository();
                if (id.HasValue)
                {
                    AnuncioSituacao asit = rep.Get(x => x.id.Equals(id.Value));
                    List<AnuncioSituacao> lasit = new List<AnuncioSituacao>();
                    lasit.Add(asit);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<AnuncioSituacaoModel>>(lasit);
                }
                else
                {
                    List<AnuncioSituacao> asit = new List<AnuncioSituacao>();
                    asit = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<AnuncioSituacaoModel>>(asit);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o AnuncioSituacao!";
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
        public RetornoModel<AnuncioSituacaoModel> PostAnuncioSituacao(AnuncioSituacaoModel asit)
        {
            RetornoModel<AnuncioSituacaoModel> ret = new RetornoModel<AnuncioSituacaoModel>();
            try
            {
                AnuncioSituacaoRepository rep = new AnuncioSituacaoRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _AnuncioSituacao = mapper.Map<AnuncioSituacao>(asit);
                _AnuncioSituacao = rep.Add(_AnuncioSituacao);
                _AnuncioSituacao = rep.Get(x => x.id.Equals(_AnuncioSituacao.id));
                
                ret.dados = mapper.Map<AnuncioSituacaoModel>(_AnuncioSituacao);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o AnuncioSituacao!";
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
        public RetornoModel<AnuncioSituacaoModel> DeleteAnuncioSituacao(long id)
        {
            RetornoModel<AnuncioSituacaoModel> ret = new RetornoModel<AnuncioSituacaoModel>();
            try
            {
                AnuncioSituacaoRepository rep = new AnuncioSituacaoRepository();

                AnuncioSituacao asit = rep.Get(id);
                if (asit != null)
                {
                    if (rep.Delete(asit))
                    {
                        ret.status = true;
                        ret.mensagem = $"AnuncioSituacao {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o AnuncioSituacao {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "AnuncioSituacao não encontrada";
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
        public RetornoModel<AnuncioSituacaoModel> PutAnuncioSituacao(AnuncioSituacaoModel AnuncioSituacaoModel)
        {
            RetornoModel<AnuncioSituacaoModel> ret = new RetornoModel<AnuncioSituacaoModel>();
            try
            {
                AnuncioSituacaoRepository rep = new AnuncioSituacaoRepository();
                AnuncioSituacao asit = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<AnuncioSituacao>(AnuncioSituacaoModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<AnuncioSituacaoModel>(asit);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o AnuncioSituacao!";
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
