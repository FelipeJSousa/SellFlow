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
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public Retorno<List<ProdutoModel>> GetProduto(int? id = null)
        {
            Retorno<List<ProdutoModel>> ret = new Retorno<List<ProdutoModel>>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();
                if (id.HasValue)
                {
                    Produto pro = rep.Get(id.Value);
                    List<Produto> lpro = new List<Produto>();
                    lpro.Add(pro);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ProdutoModel>>(lpro);
                }
                else
                {
                    List<Produto> pro = new List<Produto>();
                    pro = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ProdutoModel>>(pro);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a Produto!";
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
        public Retorno<ProdutoModel> PostProduto(ProdutoModel Produto)
        {
            Retorno<ProdutoModel> ret = new Retorno<ProdutoModel>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.dados = mapper.Map<ProdutoModel>(rep.Add(mapper.Map<Produto>(Produto)));
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Produto";
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
        public Retorno<ProdutoModel> DeleteProduto(int id)
        {
            Retorno<ProdutoModel> ret = new Retorno<ProdutoModel>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();

                Produto pro = rep.Get(id);
                if (pro != null)
                {
                    if (rep.Delete(pro))
                    {
                        ret.status = true;
                        ret.mensagem = $"ProdutoModel {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir o Produto {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Produto não encontrado";
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
        public Retorno<ProdutoModel> PutProduto(ProdutoModel ProdutoModel)
        {
            Retorno<ProdutoModel> ret = new Retorno<ProdutoModel>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();
                Produto pro = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Produto>(ProdutoModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ProdutoModel>(pro);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Produto!";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }
            return ret;
        }

        [HttpPost("curtir/{id}")]
        public Retorno<ProdutoModel> PostCurtirProduto(int id)
        {
            Retorno<ProdutoModel> ret = new Retorno<ProdutoModel>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();
                Produto pro = rep.Get(id);
                if(pro != null && pro.ativo)
                {
                    pro.Curtir();
                    pro = rep.Edit(pro);
                    ProdutoModel model = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ProdutoModel>(pro);
                    ret.status = true;
                    ret.dados = model;
                }
                else
                {
                    ret.status = false;
                    ret.mensagem = "Não foi encontrado o produto!";
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
