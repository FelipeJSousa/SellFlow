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
    public class ImagensController : ControllerBase
    {
        [HttpGet]
        public Retorno<List<ImagensModel>> GetImagens(int? id = null)
        {
            Retorno<List<ImagensModel>> ret = new Retorno<List<ImagensModel>>();
            try
            {
                ImagensRepository rep = new ImagensRepository();
                if (id.HasValue)
                {
                    Imagens img = rep.Get(id.Value);
                    List<Imagens> limg = new List<Imagens>();
                    limg.Add(img);
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ImagensModel>>(limg);
                }
                else
                {
                    List<Imagens> img = new List<Imagens>();
                    img = rep.GetAll();
                    ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<List<ImagensModel>>(img);
                }
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a Imagem!";
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
        public Retorno<ImagensModel> PostImagens(ImagensModel img)
        {
            Retorno<ImagensModel> ret = new Retorno<ImagensModel>();
            try
            {
                ImagensRepository rep = new ImagensRepository();
                var mapper = new Mapper(AutoMapperConfig.RegisterMappings());
                ret.dados = mapper.Map<ImagensModel>(rep.Add(mapper.Map<Imagens>(img)));
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a Imagem!";
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
        public Retorno<ImagensModel> DeleteImagens(int id)
        {
            Retorno<ImagensModel> ret = new Retorno<ImagensModel>();
            try
            {
                ImagensRepository rep = new ImagensRepository();

                Imagens img = rep.Get(id);
                if (img != null)
                {
                    if (rep.Delete(img))
                    {
                        ret.status = true;
                        ret.mensagem = $"Imagem {id} excluído com sucesso!";
                    }
                    else
                    {
                        ret.status = false;
                        ret.mensagem = $"Não foi possível excluir a Imagem {id}";
                    }
                }
                else
                {
                    ret.status = false;
                    ret.erro = "Imagens não encontrada";
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
        public Retorno<ImagensModel> PutImagens(ImagensModel ImagensModel)
        {
            Retorno<ImagensModel> ret = new Retorno<ImagensModel>();
            try
            {
                ImagensRepository rep = new ImagensRepository();
                Imagens img = rep.Edit(new Mapper(AutoMapperConfig.RegisterMappings()).Map<Imagens>(ImagensModel));
                ret.dados = new Mapper(AutoMapperConfig.RegisterMappings()).Map<ImagensModel>(img);
                if (ret.dados != null)
                {
                    ret.status = true;
                }
                else
                {
                    ret.mensagem = "Não foi encontrado a Imagem!";
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
