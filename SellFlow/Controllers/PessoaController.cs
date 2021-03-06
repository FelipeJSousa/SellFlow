using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SellFlow.Model;
using SellFlow.Model.ApiRequest;
using System;
using System.Collections.Generic;

namespace SellFlow.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public RetornoModel<List<PessoaModel>> GetPessoa(int? id = null) {
            RetornoModel<List<PessoaModel>> ret = new RetornoModel<List<PessoaModel>>();
            try
            {
                PessoaRepository rep = new PessoaRepository();
                if (id.HasValue)
                {  
                    Pessoa pes = rep.Get(id.Value);
                    if(pes is not null)
                    {
                        List<Pessoa> lpes = new List<Pessoa>();
                        lpes.Add(pes);
                        ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PessoaModel>>(lpes);
                    }
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

        [HttpGet("ObterPorUsuario")]
        public RetornoModel<List<PessoaModel>> GetPessoaPorUsuario(int idUsuario)
        {
            RetornoModel<List<PessoaModel>> ret = new RetornoModel<List<PessoaModel>>();
            try
            {
                PessoaRepository rep = new PessoaRepository();
                if (idUsuario > 0)
                {
                    Pessoa pes = rep.GetPorUsuario(idUsuario);
                    if (pes is not null)
                    {
                        List<Pessoa> lpes = new List<Pessoa>();
                        lpes.Add(pes);
                        ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<PessoaModel>>(lpes);
                    }
                }
                if (ret.dados != null)
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
        public RetornoModel<PessoaModel> PostPessoaModel(PessoaPostApiRequest obj)
        {
            RetornoModel<PessoaModel> ret = new ();
            try
            {
                PessoaRepository rep = new PessoaRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());

                var pessoa = mapper.Map<Pessoa>(obj);
                pessoa.ativo = true;

                ret.dados = mapper.Map<PessoaModel>(rep.Add(pessoa));
                ret.dados = mapper.Map<PessoaModel>(rep.Get(pessoa.id));

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
        [Authorize]
        public RetornoModel<PessoaModel> DeletePessoaModel(long id)
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
                        ret.mensagem = $"Pessoa {id} excluído com sucesso!";
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
        [Authorize]
        public RetornoModel<PessoaModel> PutPessoaModel(PessoaModel PessoaModel)
        {
            RetornoModel<PessoaModel> ret = new RetornoModel<PessoaModel>();
            try
            {
                if (PessoaModel.id>0)
                {
                    PessoaRepository rep = new PessoaRepository();
                    var obj = rep.Get(PessoaModel.id);

                    Pessoa update = new()
                    {
                        id = PessoaModel.id,
                        ativo = PessoaModel.ativo == null ? obj.ativo : PessoaModel.ativo.Value,
                        usuario = PessoaModel.usuario == null ? obj.usuario : PessoaModel.usuario.Value,
                        dataNascimento = PessoaModel.dataNascimento == null ? obj.dataNascimento : PessoaModel.dataNascimento.Value,
                        cpf = string.IsNullOrWhiteSpace(PessoaModel.cpf) ? obj.cpf : PessoaModel.cpf,
                        nome = string.IsNullOrWhiteSpace(PessoaModel.nome) ? obj.cpf : PessoaModel.nome,
                        sobrenome = string.IsNullOrWhiteSpace(PessoaModel.sobrenome) ? obj.cpf : PessoaModel.sobrenome
                    };

                    Pessoa pes = rep.Edit(update);
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
