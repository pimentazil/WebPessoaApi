using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPiPessoa.Application.Autenticacao;
using WebPessoaAPII.Repository;

namespace WebPessoaAPII.Application.Autenticacao
{
    public class AutenticacaoService
    {

        private readonly PessoaContext _context;

        public AutenticacaoService(PessoaContext context)
        {
            _context = context;
        }

        public string Autenticar(AutenticacaoRequest request)
        {
            if (request.UserName == "var" && request.Password == "var")
            {
                var tokenString = GerarTokenJwt();
                return tokenString;
            }
            else
            {
                return null;
            }
        }
        private string GerarTokenJwt()
        {
            var issuer = "var";
            var audience = "var";
            var key = "5a23ea79-0f83-44d5-80d1-ad5a072e13a8";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;

        }
    }
}
