using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPiPessoa.Application.Autenticacao;
using WebPessoaAPII.Application.Autenticacao;
using WebPessoaAPII.Repository;

namespace WebPessoaAPII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase

    private readonly PessoaContext _context;

    public AutenticacaoController(PessoaContext context)
    {
        _context = context;
    }


    [HttpPost]

    public IActionResult Login([FromBody] AutenticacaoRequest request)
    {
        var autenticacaoService = new AutenticacaoService(_context);
        var tokenString = autenticacaoService.Autenticar(request);

        if (string.IsNullOrWhiteSpace(tokenString))
        {
            return Unauthorized();
        }
        else
        {
            return Ok(new { token = tokenString });
        }



    }
}
}
