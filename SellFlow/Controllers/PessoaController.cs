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
        public Retorno<List<PessoaModel>> GetPessoa(int? id = null) {
            Retorno<List<PessoaModel>> ret = new Retorno<List<PessoaModel>>();
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
        public Retorno<PessoaModel> PostPessoaModel(PessoaModel pessoa)
        {
            Retorno<PessoaModel> ret = new Retorno<PessoaModel>();
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
        public Retorno<PessoaModel> DeletePessoaModel(int id)
        {
            Retorno<PessoaModel> ret = new Retorno<PessoaModel>();
            try
            {
                PessoaRepository rep = new PessoaRepository();

                ret.mensagem = rep.Delete(id) == true ? $"PessoaModel {id} excluído com sucesso!" : $"Não foi possível excluir o PessoaModel {id}";

            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }
            return ret;
        }

        [HttpPut]
        public Retorno<PessoaModel> PutPessoaModel(PessoaModel PessoaModel)
        {
            Retorno<PessoaModel> ret = new Retorno<PessoaModel>();
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
