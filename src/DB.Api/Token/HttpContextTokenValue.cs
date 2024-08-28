using DB.Domain.Token;

namespace DB.Api.Token;

// Implementação de ITokenProvider que obtém o token do contexto HTTP
public class HttpContextTokenValue : ITokenProvider
{
    public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // Acesso ao contexto HTTP para ler os headers da solicitação
    private readonly IHttpContextAccessor _httpContextAccessor;

    // Obtém o valor do token a partir do header Authorization da solicitação HTTP
    public string Value()
    {
        // Obtém o valor do header Authorization
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
            
        // Remove o prefixo "Bearer " e retorna o token
        return authentication["Bearer ".Length..].ToString();
    }
}