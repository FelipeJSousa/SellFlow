using System;
using Repository;
using System.Text;
using SellFlow.Model;
using Microsoft.AspNetCore.Mvc;
using SellFlow.Model.ApiResponse;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;


namespace SellFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private IConfiguration _config;
        public AcessoController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost("Login")]
        public RetornoModel<ApiResponseAcesso> ValidarUsuario(UsuarioModel UsuarioModel)
        {
            RetornoModel<ApiResponseAcesso> ret = new ();
            try
            {
                UsuarioRepository rep = new UsuarioRepository();
                var usu = rep.Validar(UsuarioModel.email, UsuarioModel.senha);
                ret.dados = new AutoMapper.Mapper(AutoMapperConfig.RegisterMappings()).Map<ApiResponseAcesso>(usu);
                if (ret.dados != null)
                {
                    ret.status = true;
                    ret.dados.token = GerarTokenJWT();
                }
                else
                {
                    ret.mensagem = "Não foi encontrado o Usuario!";
                }
            }
            catch (Exception ex)
            {
                ret.status = false;
                ret.erro = ex.Message;
            }

            return ret;
        }

        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
                                             expires: expiry,
                                             signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

    }
}
