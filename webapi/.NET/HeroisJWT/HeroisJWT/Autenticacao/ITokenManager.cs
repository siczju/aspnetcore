using HeroisJWT.Db;

namespace HeroisJWT.Autenticacao;

     public interface ITokenManager // Responsável por gerenciar a criação e validação de tokens JWT
    {
        string GenerateToken(Heroi heroi);
    }

