﻿using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using SellFlow.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public RetornoModel<List<ProdutoModel>> GetProduto(int? id = null)
        {
            RetornoModel<List<ProdutoModel>> ret = new RetornoModel<List<ProdutoModel>>();
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
        public async Task<RetornoModel<ProdutoModel>> PostProduto([FromForm] string json,  [FromForm] IFormFile imagem)
        {
            RetornoModel<ProdutoModel> ret = new RetornoModel<ProdutoModel>();
            try
            {
                ProdutoRepository rep = new();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                var _obj = JsonConvert.DeserializeObject<Produto>(json);
                var _produto = mapper.Map<Produto>(_obj);
                ret.dados = mapper.Map<ProdutoModel>(rep.Add(_produto));
                if (ret.dados != null)
                {
                    ret.status = true;

                    if(imagem.Length > 0)
                    {
                        var currDir = Directory.GetCurrentDirectory() + "\\imagens\\produtos\\" + _produto.id;
                        if (!Directory.Exists(currDir))
                        {
                            Directory.CreateDirectory(currDir);
                        }
                        using (FileStream fileStream = System.IO.File.Create(currDir + "\\" + imagem.FileName))
                        {
                            await imagem.CopyToAsync(fileStream);
                            fileStream.Flush();
                            var repImagem = new ImagensRepository();
                            var objImagem = new Imagens()
                            {
                                ativo = true,
                                diretorio = currDir + "\\" + imagem.FileName,
                                produto = _produto.id
                            };
                            repImagem.Add(objImagem);
                        }
                    }
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
        public async Task<RetornoModel<ProdutoModel>> PutProdutoAsync([FromForm] string json, [FromForm] IFormFile imagem = null)
        {
            RetornoModel<ProdutoModel> ret = new RetornoModel<ProdutoModel>();
            try
            {
                ProdutoRepository rep = new ProdutoRepository();
                var _obj = JsonConvert.DeserializeObject<Produto>(json);
                Produto pro = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Produto>(_obj));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ProdutoModel>(pro);
                if (ret.dados != null)
                {
                    ret.status = true;
                    if (imagem?.Length > 0)
                    {
                        var currDir = Directory.GetCurrentDirectory() + "\\imagens\\produtos\\" + pro.id;
                        if (!Directory.Exists(currDir))
                        {
                            Directory.CreateDirectory(currDir);
                        }
                        using (FileStream fileStream = System.IO.File.Create(currDir + "\\" + imagem.FileName))
                        {
                            await imagem.CopyToAsync(fileStream);
                            fileStream.Flush();
                            var repImagem = new ImagensRepository();
                            var objImagem = new Imagens()
                            {
                                ativo = true,
                                diretorio = currDir + "\\" + imagem.FileName,
                                produto = pro.id
                            };
                            repImagem.Add(objImagem);
                        }
                    }
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
