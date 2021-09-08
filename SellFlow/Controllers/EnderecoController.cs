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
    public class EnderecoController : ControllerBase
    {
        [HttpGet]
        public Retorno<List<EnderecoModel>> GetEndereco(int? id = null)
        {
            Retorno<List<EnderecoModel>> ret = new Retorno<List<EnderecoModel>>();
            try
            {
                EnderecoRepository rep = new EnderecoRepository();
                if (id.HasValue)
                {
                    Endereco end = rep.Get(id.Value);
                    List<Endereco> lend = new List<Endereco>();
                    lend.Add(end);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<EnderecoModel>>(lend);
                }
                else
                {
                    List<Endereco> end = new List<Endereco>();
                    end = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<EnderecoModel>>(end);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Endereco!";
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
        public Retorno<EnderecoModel> PostEndereco(EnderecoModel end)
        {
            Retorno<EnderecoModel> ret = new Retorno<EnderecoModel>();
            try
            {
                EnderecoRepository rep = new EnderecoRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.dados = mapper.Map<EnderecoModel>(rep.Add(mapper.Map<Endereco>(end)));
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Endereco!";
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
        public Retorno<EnderecoModel> DeleteEndereco(int id)
        {
            Retorno<EnderecoModel> ret = new Retorno<EnderecoModel>();
            try
            {
                EnderecoRepository rep = new EnderecoRepository();

                Endereco end = rep.Get(id);
                if (end != null)
                {
                    if (rep.Delete(end))
                    {
                        ret.status = true;
                        ret.mensagem = $"Endereco {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o Endereco {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Endereco não encontrada";
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
        public Retorno<EnderecoModel> PutEndereco(EnderecoModel EnderecoModel)
        {
            Retorno<EnderecoModel> ret = new Retorno<EnderecoModel>();
            try
            {
                EnderecoRepository rep = new EnderecoRepository();
                Endereco end = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Endereco>(EnderecoModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<EnderecoModel>(end);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Endereco!";
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
