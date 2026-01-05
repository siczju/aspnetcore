using HeroisJWT.Db;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HeroisJWT.Autenticacao;

    public sealed class TokenManager : ITokenManager
    {
    private readonly IConfiguration _configuration;
    public TokenManager(IConfiguration configuration)
    {
            _configuration = configuration;
    }
    public string GenerateToken(Heroi heroi)
        {
            // Token caracteristicas ->  Tempo de vida, emissor do token (nossa api),
            // audiencia e a chave secreta do token para identificar (se foi a nossa api
            // msm q fez o token). Essas info são pertinentes a gente colocar dentro do
            // appsettings.json

            // 1º Passo: Obter todas info que estão no appsettings do token
            var jwtSettings = _configuration.GetSection("JwtSettings");
        // Gerar uma chave secreta:
        var secretKey = new SymmetricSecurityKey( // precisa estar em bytes então:
            Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? string.Empty));

            // Informações contidas no token (token,usuario, email...), famoso claims
            // Claim é Chave e valor 
        var claims = new List<Claim>()
        {
                new(JwtRegisteredClaimNames.Sub, heroi.Nome), // Sub é onde bota informações como nome do usuario
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Jti é o id do token
        };

        // qnd vc coloca Role vc consegue usar na controller, para dizer pra quem acessar esse endpoint tem q ter essa role
        foreach (var poder in heroi.Poderes)
        {
            claims.Add(new Claim(ClaimTypes.Role, poder.Descricao)); 
        }

        // Informação de tempo de expiração do token
        var tempoExpiracaoInMinutes = jwtSettings.GetValue<int>("ExpirationTimeInMinutes");

        // Pronto, agora finalmente vamos montar o nosso token
        var token = new JwtSecurityToken(
            issuer: jwtSettings.GetValue<string>("Issuer"), // Quem emite
            audience: jwtSettings.GetValue<string>("Audience"), // Quem consume (podendo ter mais de um valor ai seria um array)
            claims: claims, // onde está as info do user e oq o usuario pode fazer (roles)
            expires: DateTime.UtcNow.AddMinutes(tempoExpiracaoInMinutes),// tem q ser com base no UTC e não no valor de agora
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256) // segredo
            );

        return new JwtSecurityTokenHandler().WriteToken(token); // vai gerar uma string com as info do token la dentro


    }
}

