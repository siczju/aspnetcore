using HeroisJWT.Autenticacao;
using HeroisJWT.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeroisJWT.Controllers; 

    [ApiController]
    [Route("[controller]")] // quanto ta só o controller na rota indica que o endpoint vai se chamar somente "missao" q vem de MissaoController
    public sealed class MissaoController : ControllerBase
    {
        private readonly ITokenManager _tokenManager;
        public MissaoController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        [HttpGet("Hello-world")]
        public string HelloWorld() => "Hello World from MissaoController!";

        // Obter o heroi que está logado (autenticado)
        [Authorize]
        [HttpGet("somente-heroi")]
        public string SomenteHeroi() => "Você é heroi";
    

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request) // [FromBody] indica que vai vir no body da requisição
        {
            // Verificar se veio o heroi
            if(string.IsNullOrWhiteSpace(request.Heroi))
                return NotFound();

            // (Se veio) -> Tentar obter o heroi
            var heroi = BancoHerois.Herois.FirstOrDefault(x => x.Nome == request.Heroi);

            if(heroi is null)
                return NotFound();

        // Gerar token para esse heroi (dependendo do token ele terá permissões diferentes)
        // Para isso, baixar um pacote NuGet: Microsoft.AspNetCore.Authentication.JwtBearer
        
            var token = _tokenManager.GenerateToken(heroi);

            return Ok(new LoginResponse(token));
    }

}

public record LoginRequest(string Heroi);
public record LoginResponse(string Token);