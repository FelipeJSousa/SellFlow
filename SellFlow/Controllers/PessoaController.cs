using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<PessoaModel>> GetPessoa(int? id = null) {
            RetornoModel<List<PessoaModel>> ret = new RetornoModel<List<PessoaModel>>();
            try
            {
                PessoaRepository rep = new PessoaRepository();
                if (id.HasValue)
                {  
                    Pessoa pes = rep.Get(id.Value);
                    List<Pessoa> lpes = new List<Pessoa>();
                    lpes.Add(pes);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PessoaModel>>(lpes);
                }
                else
                {
                    List<Pessoa> pes = new List<Pessoa>();
                    pes = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PessoaModel>>(pes);
                }
                if(ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a PessoaModel!";
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
        public RetornoModel<PessoaModel> PostPessoaModel(PessoaModel pessoa)
        {
            RetornoModel<PessoaModel> ret = new RetornoModel<PessoaModel>();
            try
            {
                PessoaRepository rep = new PessoaRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.dados = mapper.Map<PessoaModel>(rep.Add(mapper.Map<Pessoa>(pessoa)));
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o PessoaModel!";
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
        public RetornoModel<PessoaModel> DeletePessoaModel(int id)
        {
            RetornoModel<PessoaModel> ret = new RetornoModel<PessoaModel>();
            try
            {
                PessoaRepository rep = new PessoaRepository();

                Pessoa pes = rep.Get(id);
                if(pes != null)
                {
                    if (rep.Delete(pes))
                    {
                        ret.status = true;
                        ret.mensagem = $"PessoaModel {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o PessoaModel {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Pessoa não encontrada";
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
        public RetornoModel<PessoaModel> PutPessoaModel(PessoaModel PessoaModel)
        {
            RetornoModel<PessoaModel> ret = new RetornoModel<PessoaModel>();
            try
            {
                PessoaRepository rep = new PessoaRepository();
                Pessoa pes = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Pessoa>(PessoaModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<PessoaModel>(pes);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o PessoaModel!";
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
