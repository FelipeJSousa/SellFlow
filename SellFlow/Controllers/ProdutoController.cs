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
        //[HttpGet]
        //public RetornoModel<List<ProdutoModel>> GetProduto(int? id = null)
        //{
        //    RetornoModel<List<ProdutoModel>> ret = new RetornoModel<List<ProdutoModel>>();
        //    try
        //    {
        //        ProdutoRepository rep = new ProdutoRepository();
        //        if (id.HasValue)
        //        {
        //            Produto pro = rep.Get(id.Value);
        //            List<Produto> lpro = new List<Produto>();
        //            lpro.Add(pro);
        //            ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ProdutoModel>>(lpro);
        //        }
        //        else
        //        {
        //            List<Produto> pro = new List<Produto>();
        //            pro = rep.GetAll();
        //            ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ProdutoModel>>(pro);
        //        }
        //        if (ret.dados != null)
        //        {
        //            ret.status = true;
        //        }
        //        else
        //        {
        //            ret.mensagem = "Não foi encontrado a Produto!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ret.status = false;
        //        ret.erro = ex.Message;
        //    }
        //    return ret;
        //}


        [HttpGet]
        public RetornoModel<List<ProdutoModel>> GetProdutoPorEmpresa(int? id = null, int? idUsuario = null)
        {
            RetornoModel<List<ProdutoModel>> ret = new RetornoModel<List<ProdutoModel>>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();
                if (id.HasValue)
                {
                    Produto pro = rep.Get(id.Value, idUsuario);
                    List<Produto> lpro = new List<Produto>();
                    lpro.Add(pro);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ProdutoModel>>(lpro);
                }
                else
                {
                    List<Produto> pro = new List<Produto>();
                    pro = rep.GetAll(idUsuario);
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
        public RetornoModel<ProdutoModel> PostProduto(ProdutoModel Produto)
        {
            RetornoModel<ProdutoModel> ret = new RetornoModel<ProdutoModel>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _produto = mapper.Map<Produto>(Produto);
                ret.dados = mapper.Map<ProdutoModel>(rep.Add(_produto));
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
        public RetornoModel<ProdutoModel> DeleteProduto(long id)
        {
            RetornoModel<ProdutoModel> ret = new RetornoModel<ProdutoModel>();
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
        public RetornoModel<ProdutoModel> PutProduto(ProdutoModel ProdutoModel)
        {
            RetornoModel<ProdutoModel> ret = new RetornoModel<ProdutoModel>();
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
        public RetornoModel<ProdutoModel> PostCurtirProduto(long id)
        {
            RetornoModel<ProdutoModel> ret = new RetornoModel<ProdutoModel>();
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
